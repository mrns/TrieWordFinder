using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace QuTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            IEnumerable<string> matrix = MatrixGenerator(64);
            WordFinder wordFinder = new WordFinder(matrix);

            List<string> wordstream = new List<string>();
            Random random = new Random();

            for (int i = 0; i < 10000000; i++)
            {
                wordstream.Add(sampleWords[random.Next(0, 7)]);
            }

            IEnumerable<string> ranking = wordFinder.Find(wordstream);

            foreach (string word in ranking)
            {
                System.Console.WriteLine(word);
            }

            stopwatch.Stop();
            var elapsedTicks = stopwatch.ElapsedTicks;
            var elapsedMilliseconds = stopwatch.ElapsedMilliseconds;

            System.Console.WriteLine($"Elapsed Milliseconds: {elapsedMilliseconds}");
            System.Console.WriteLine($"Elapsed Ticks: {elapsedTicks}");
        }

        private const string CHARS = "abcdefghijklmnopqrstuvwxyz";

        private static string[] sampleWords = new string[7] {
            "hola",
            "como",
            "estas",
            "mi",
            "nombre",
            "es",
            "diego"};

        private static void PrintMatrix(IEnumerable<string> matrix)
        {
            foreach (string word in matrix)
            {
                System.Console.WriteLine(word);
            }
        }
        private static string RowGenerator(int length)
        {
            Random random = new Random();
            string row = string.Empty;

            int index = 0;
            while (index < length)
            {
                row += sampleWords[random.Next(0, 7)];
                index++;
            }

            return row.Substring(0, 64);
        }

        private static IEnumerable<string> MatrixGenerator(int length)
        {
            string[] matrix = new string[length];

            int index = 0;
            string row;

            while (index < length)
            {
                row = RowGenerator(length);
                matrix[index] = row;

                index++;
            }

            return matrix;
        }
    }
}
