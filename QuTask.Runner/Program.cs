using System;
using System.Collections.Generic;
using System.Diagnostics;
using QuTask.Tools;

namespace QuTask.Runner
{
    class Program
    {
        private const int _matrixSize = 64;
        private static char[,] _matrix = MatrixTools.GenerateRandomMatrix(_matrixSize, _matrixSize);
        private static WordFinder _wordFinder = new WordFinder(MatrixTools.GetIEnumerableMatrix(_matrixSize, _matrix));
        static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            List<string> wordstream = new List<string>();
            wordstream.AddRange(WordTools._sampleWordStream);

            for (int i = 0; i < 1000000 - wordstream.Count; i++)
            {
                wordstream.Add(WordTools.GetRandomWord());
            }

            IEnumerable<string> ranking = _wordFinder.Find(wordstream);

            stopwatch.Stop();
            var elapsedTicks = stopwatch.ElapsedTicks;
            var elapsedMilliseconds = stopwatch.ElapsedMilliseconds;

            System.Console.WriteLine();
            System.Console.WriteLine("----------------------------------------------------");
            System.Console.WriteLine("MATRIX:");
            System.Console.WriteLine("----------------------------------------------------");
            System.Console.WriteLine();

            MatrixTools.PrintMatrix(MatrixTools.GetIEnumerableMatrix(_matrixSize, _matrix));

            System.Console.WriteLine();
            System.Console.WriteLine("----------------------------------------------------");
            System.Console.WriteLine("RANKING:");
            System.Console.WriteLine("----------------------------------------------------");
            System.Console.WriteLine();

            foreach (string word in ranking)
            {
                System.Console.WriteLine(word);
            }

            System.Console.WriteLine();
            System.Console.WriteLine("----------------------------------------------------");
            System.Console.WriteLine("STATS:");
            System.Console.WriteLine("----------------------------------------------------");
            System.Console.WriteLine();
            System.Console.WriteLine($"Elapsed Milliseconds: {elapsedMilliseconds}");
            System.Console.WriteLine($"Elapsed Ticks: {elapsedTicks}");
            System.Console.WriteLine();
        }
    }
}
