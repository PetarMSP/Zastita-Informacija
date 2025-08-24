using System;
using System.IO;
using System.Net.Sockets;
using System.Threading.Tasks;
using CryptoFileTransferApp.Crypto; 

namespace CryptoFileTransferApp.Networking
{
    public class Client
    {
        public async Task SendFileAsync(string ipAddress, int port, string filePath,string algorithm,byte[] rc6keyBytes, Action<string> statusCallback)
        {
            try
            {
                using (Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
                {
                    await clientSocket.ConnectAsync(ipAddress, port);
                    statusCallback?.Invoke("Povezan sa serverom");

                    using (NetworkStream networkStream = new NetworkStream(clientSocket))
                    using (BinaryReader reader = new BinaryReader(networkStream))
                    using (BinaryWriter writer = new BinaryWriter(networkStream))
                    {
                        string fileName = Path.GetFileName(filePath);
                        string hashHex;
                        using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                            hashHex = SHA1Helper.Hash(fs);

                        byte[] hashBytes = System.Text.Encoding.UTF8.GetBytes(hashHex);
                        long fileSize = new FileInfo(filePath).Length;

                        // Saljemo metapodatke
                        writer.Write(fileName);
                        writer.Write(fileSize);
                        writer.Write(hashBytes.Length);
                        writer.Write(algorithm);
                        writer.Write(hashBytes);

                        if (algorithm == "RC6" && !(rc6keyBytes.Length == 0))
                        {
                            writer.Write(rc6keyBytes.Length);  // prvo dužinu kljuca
                            writer.Write(rc6keyBytes);         // pa sam kljuc
                        }
                        // Saljemo fajl po blokovima
                        byte[] buffer = new byte[8192];
                        using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                        {
                            int bytesRead;
                            while ((bytesRead = await fs.ReadAsync(buffer, 0, buffer.Length)) > 0)
                            {
                                await networkStream.WriteAsync(buffer, 0, bytesRead);
                            }
                        }

                        // Ceka se potvrda servera
                        string response = reader.ReadString();
                        statusCallback?.Invoke($"Server: {response}");
                    }
                }
            }
            catch (Exception ex)
            {
                statusCallback?.Invoke("Greska klijenta: " + ex.Message);
            }
        }
    }
}
