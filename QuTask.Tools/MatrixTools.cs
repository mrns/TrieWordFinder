
using System.Collections.Generic;

namespace QuTask.Tools
{
    public static class MatrixTools
    {
        public static char[,] GenerateRandomMatrix(int rows, int columns)
        {
            char[,] matrix = new char[rows, columns];
            char c;

            int i = 0;
            int j = 0;

            while (i < rows)
            {
                while (j < columns)
                {
                    c = WordTools.GetRandomChar();
                    matrix[i, j] = c;
                    j++;
                }
                j = 0;
                i++;
            }
            AddSampleWords(matrix);
            return matrix;
        }
        public static void AddSampleWords(char[,] matrix)
        {
            int i = 0;
            int j = 0;
            int wordRow = 0;
            int wordColumn = 0;
            string word;

            while (i < WordTools.SampleWordStream.Length && j < WordTools.SampleWordStream.Length)
            {
                word = WordTools.GetSampleWord(i);
                wordRow = i;
                wordColumn = j;

                foreach (char c in word)
                {
                    matrix[i, wordColumn] = c;
                    matrix[wordRow, j] = c;
                    wordRow++;
                    wordColumn++;
                }

                i++;
                j++;
            }
        }
        public static IEnumerable<string> GetIEnumerableMatrix(int size, char[,] matrix)
        {
            string[] inputMatrix = new string[size];
            int i = 0;
            int j = 0;
            string row = string.Empty;

            while (i < size)
            {
                while (j < size)
                {
                    row += matrix[i, j];
                    j++;
                }
                inputMatrix[i] = row;
                row = string.Empty;
                j = 0;
                i++;
            }

            return inputMatrix;
        }

        public static void PrintMatrix(IEnumerable<string> matrix)
        {
            foreach (string word in matrix)
            {
                System.Console.WriteLine(word);
            }
        }

    }

}

