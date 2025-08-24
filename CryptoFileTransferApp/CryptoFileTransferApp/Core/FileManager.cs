using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoFileTransferApp.Core
{
    public static class FileManager
    {
        public static void SaveToFile(string path, string content)
        {
            try
            {
                File.WriteAllText(path, content);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving to file: {ex.Message}");
                throw;
            }
        }

        public static string LoadFromFile(string path)
        {
            try
            {
                if (!File.Exists(path))
                    throw new FileNotFoundException("File not found", path);

                return File.ReadAllText(path);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading from file: {ex.Message}");
                throw;
            }
        }
    }
}


