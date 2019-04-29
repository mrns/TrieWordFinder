using System;
using Xunit;
using Bogus;
using System.Collections.Generic;
using QuTask.Exceptions;
using System.Linq;
using QuTask.Tools;
using System.Diagnostics;

namespace QuTask.Tests
{
    public class WordFinderTests
    {
        private const int _matrixSize = 64;
        private static char[,] _matrix = MatrixTools.GenerateRandomMatrix(_matrixSize, _matrixSize);
        private static WordFinder _wordFinder = new WordFinder(MatrixTools.GetIEnumerableMatrix(_matrixSize, _matrix));

        [Fact]
        public void Should_Throw_If_Matrix_Exceeds_Max_Size()
        {
            Assert.Throws<MatrixSizeExceededException>(() =>
            {
                WordFinder wordFinder = new WordFinder(new string[WordFinder.MAX_MATRIX_SIZE + 1]);
            });
        }

        [Fact]
        public void Should_Throw_If_Matrix_Is_Empty()
        {
            IEnumerable<string> matrix = new List<string>();
            Assert.Throws<EmptyMatrixException>(() =>
            {
                WordFinder wordFinder = new WordFinder(matrix);
            });
        }

        [Fact]
        public void Should_Throw_If_First_Row_IsNull_Or_Empty()
        {
            IEnumerable<string> matrix = new string[] { "", "two", "three" };
            Assert.Throws<NullOrEmptyFirstRowException>(() =>
            {
                WordFinder wordFinder = new WordFinder(matrix);
            });

            matrix = new string[] { null, "two", "three" };
            Assert.Throws<NullOrEmptyFirstRowException>(() =>
            {
                WordFinder wordFinder = new WordFinder(matrix);
            });
        }

        [Fact]
        public void Should_Throw_If_At_Least_One_String_Has_A_Different_Length_Than_The_First()
        {
            IEnumerable<string> matrix = new string[] { "one", "two", "three" };
            Assert.Throws<DifferentLengthRowsException>(() =>
            {
                WordFinder wordFinder = new WordFinder(matrix);
            });
        }

        [Fact]
        public void Find_Returns_At_Most_Ten_Strings()
        {
            IEnumerable<string> results = _wordFinder.Find(WordTools.SampleWordStream);
            Assert.True(results.Count() == 10);
        }

        [Fact]
        public void Find_Returns_Empty_Set_Of_Strings_If_No_Match_Is_Found()
        {
            IEnumerable<string> results = _wordFinder.Find(new string[] { "lorem#", "ipsum#" });
            Assert.True(results.Count() == 0);
        }

        [Fact]
        public void Find_Should_Match_Horizontal_Left_To_Right_Words()
        {
            IEnumerable<string> matrix = new string[] { "one", "owt" };

            WordFinder wordFinder = new WordFinder(matrix);
            IEnumerable<string> results = wordFinder.Find(new string[] { "one", "two" });

            Assert.True(results.Count() == 1 && results.ElementAt(0) == "one");
        }

        [Fact]
        public void Find_Should_Match_Vertical_Top_To_Bottom_Rows()
        {
            IEnumerable<string> matrix = new string[] { "oo", "nw", "et" };

            WordFinder wordFinder = new WordFinder(matrix);
            IEnumerable<string> results = wordFinder.Find(new string[] { "one", "two" });

            Assert.True(results.Count() == 1 && results.ElementAt(0) == "one");
        }

        [Fact]
        public void Find_Should_Count_Only_Once_A_Word_Found_Multiple_Times()
        {
            IEnumerable<string> matrix = new string[] { "one", "one", "two", "six" };

            WordFinder wordFinder = new WordFinder(matrix);
            IEnumerable<string> results = _wordFinder.Find(new string[] { "one", "two", "two", "six", "six", "six" });

            Assert.True(results.ElementAt(2) == "one");
        }

        [Fact]
        public void Find_Should_Return_Results_In_Less_Than_One_Second_For_One_Million_Words()
        {
            List<string> wordstream = new List<string>();
            wordstream.AddRange(WordTools.SampleWordStream);

            for (int i = 0; i < 1000000 - wordstream.Count; i++)
            {
                wordstream.Add(WordTools.GetRandomWord());
            }

            var stopWatch = new Stopwatch();
            stopWatch.Start();
            IEnumerable<string> results = _wordFinder.Find(wordstream);
            stopWatch.Stop();

            Assert.True(stopWatch.ElapsedMilliseconds < 1000);
        }
    }
}
