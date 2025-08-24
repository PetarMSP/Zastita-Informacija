using System;
using System.Security.Cryptography;

namespace CryptoFileTransferApp.Crypto
{
    public class PCBC
    {
        private const int BlockSize = 16;

        private static byte[] Xor(byte[] a, byte[] b)
        {
            var r = new byte[BlockSize];
            for (int i = 0; i < BlockSize; i++) r[i] = (byte)(a[i] ^ b[i]);
            return r;
        }

        private static byte[] Xor(byte[] a, byte[] b, byte[] c)
        {
            var r = new byte[BlockSize];
            for (int i = 0; i < BlockSize; i++) r[i] = (byte)(a[i] ^ b[i] ^ c[i]);
            return r;
        }

        private static byte[] PKCS7Pad(byte[] data)
        {
            int pad = BlockSize - (data.Length % BlockSize);
            if (pad == 0) pad = BlockSize;
            byte[] output = new byte[data.Length + pad];
            Buffer.BlockCopy(data, 0, output, 0, data.Length);
            for (int i = data.Length; i < output.Length; i++) output[i] = (byte)pad;
            return output;
        }

        private static byte[] PKCS7Unpad(byte[] data)
        {
            int pad = data[data.Length - 1];
            if (pad <= 0 || pad > BlockSize) throw new CryptographicException("Neispravan padding.");
            for (int i = data.Length - pad; i < data.Length; i++)
                if (data[i] != pad) throw new CryptographicException("Neispravan padding.");
            byte[] output = new byte[data.Length - pad];
            Buffer.BlockCopy(data, 0, output, 0, output.Length);
            return output;
        }

        public static (byte[] cipher, byte[] iv) Encrypt(byte[] plaintext, byte[] keyBytes, byte[] iv = null)
        {
            if (iv == null)
            {
                iv = new byte[BlockSize];
                using (var rng = RandomNumberGenerator.Create())
                {
                    rng.GetBytes(iv);
                }
            }

            var rc6 = new RC6(keyBytes);

            byte[] padded = PKCS7Pad(plaintext);
            byte[] cipher = new byte[padded.Length];

            byte[] prevP = (byte[])iv.Clone();
            byte[] prevC = (byte[])iv.Clone();

            for (int off = 0; off < padded.Length; off += BlockSize)
            {
                byte[] block = new byte[BlockSize];
                Buffer.BlockCopy(padded, off, block, 0, BlockSize);

                byte[] input = off == 0 ? Xor(block, iv) : Xor(block, prevP, prevC);
                byte[] cBlock = rc6.Encrypt(input);

                Buffer.BlockCopy(cBlock, 0, cipher, off, BlockSize);

                prevP = block;
                prevC = cBlock;
            }

            return (cipher, iv);
        }

        public static byte[] Decrypt(byte[] cipher, byte[] keyBytes, byte[] iv)
        {
            if (iv == null || iv.Length != BlockSize) throw new ArgumentException("IV mora biti 16 bajtova.");

            var rc6 = new RC6(keyBytes);

            byte[] plainWithPad = new byte[cipher.Length];
            byte[] prevP = (byte[])iv.Clone();
            byte[] prevC = (byte[])iv.Clone();

            for (int off = 0; off < cipher.Length; off += BlockSize)
            {
                byte[] cBlock = new byte[BlockSize];
                Buffer.BlockCopy(cipher, off, cBlock, 0, BlockSize);

                byte[] dBlock = rc6.Decrypt(cBlock);

                byte[] pBlock = off == 0 ? Xor(dBlock, iv) : Xor(dBlock, prevP, prevC);
                Buffer.BlockCopy(pBlock, 0, plainWithPad, off, BlockSize);

                prevP = pBlock;
                prevC = cBlock;
            }

            return PKCS7Unpad(plainWithPad);
        }
    }
}
