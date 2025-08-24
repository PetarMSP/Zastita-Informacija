using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoFileTransferApp.Crypto
{
    public static class PlayfairCipher
    {
        private static char[,] GenerateMatrix(string key)
        {
            key = key.ToUpper().Replace("J", "I");
            string alphabet = "ABCDEFGHIKLMNOPQRSTUVWXYZ";

            string fullKey = new string((key + alphabet)
                .Where(char.IsLetter)
                .Distinct()
                .ToArray());

            char[,] matrix = new char[5, 5];
            for (int i = 0; i < 25; i++)
                matrix[i / 5, i % 5] = fullKey[i];

            return matrix;
        }

        private static string PrepareInput(string input)
        {
            input = input.ToUpper().Replace("J", "I");
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                if (!char.IsLetter(input[i]))
                    continue;

                char first = input[i];
                char second = (i + 1 < input.Length && char.IsLetter(input[i + 1])) ? input[i + 1] : 'X';

                if (first == second)
                {
                    result.Append(first);
                    result.Append('X');
                }
                else
                {
                    result.Append(first);
                    result.Append(second);
                    i++; // preskoči drugo slovo
                }
            }

            if (result.Length % 2 != 0)
                result.Append('X');

            return result.ToString();
        }

        private static (int row, int col) FindPosition(char[,] matrix, char c)
        {
            for (int row = 0; row < 5; row++)
                for (int col = 0; col < 5; col++)
                    if (matrix[row, col] == c)
                        return (row, col);
            throw new ArgumentException("Slovo nije pronađeno u matrici");
        }

        public static string Encrypt(string input, string key)
        {
            char[,] matrix = GenerateMatrix(key);
            string prepared = PrepareInput(input);
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < prepared.Length; i += 2)
            {
                char a = prepared[i];
                char b = prepared[i + 1];
                var (row1, col1) = FindPosition(matrix, a);
                var (row2, col2) = FindPosition(matrix, b);

                if (row1 == row2)
                {
                    result.Append(matrix[row1, (col1 + 1) % 5]);
                    result.Append(matrix[row2, (col2 + 1) % 5]);
                }
                else if (col1 == col2)
                {
                    result.Append(matrix[(row1 + 1) % 5, col1]);
                    result.Append(matrix[(row2 + 1) % 5, col2]);
                }
                else
                {
                    result.Append(matrix[row1, col2]);
                    result.Append(matrix[row2, col1]);
                }
            }

            return result.ToString();
        }

        public static string Decrypt(string input, string key)
        {
            char[,] matrix = GenerateMatrix(key);
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < input.Length; i += 2)
            {
                char a = input[i];
                char b = input[i + 1];
                var (row1, col1) = FindPosition(matrix, a);
                var (row2, col2) = FindPosition(matrix, b);

                if (row1 == row2)
                {
                    result.Append(matrix[row1, (col1 + 4) % 5]);
                    result.Append(matrix[row2, (col2 + 4) % 5]);
                }
                else if (col1 == col2)
                {
                    result.Append(matrix[(row1 + 4) % 5, col1]);
                    result.Append(matrix[(row2 + 4) % 5, col2]);
                }
                else
                {
                    result.Append(matrix[row1, col2]);
                    result.Append(matrix[row2, col1]);
                }
            }

            return result.ToString();
        }
    }
}
