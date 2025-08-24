using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace CryptoFileTransferApp.Crypto
{
    public static class SHA1Helper
    {
        // Hash string input
        public static string Hash(string input)
        {
            using (var sha1 = SHA1.Create())
            {
                byte[] hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(input));
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }

        // Hash byte[] input
        public static string Hash(byte[] data)
        {
            using (var sha1 = SHA1.Create())
            {
                byte[] hash = sha1.ComputeHash(data);
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }

        // Hash Stream (fajlovi svih tipova: txt, pdf, jpg, mp4, exe...)
        public static string Hash(Stream stream)
        {
            using (var sha1 = SHA1.Create())
            {
                byte[] hash = sha1.ComputeHash(stream);
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }
    }
}
