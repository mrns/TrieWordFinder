using System;
using Xunit;
using Bogus;
using System.Collections.Generic;
using QuTask.Exceptions;
using System.Linq;
using QuTask.Tools;

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
            IEnumerable<string> results = _wordFinder.Find(WordTools._sampleWordStream);
            Assert.True(results.Count() == 10);
        }

        [Fact]
        public void Find_Returns_Empty_Set_Of_Strings_If_No_Match_Is_Found()
        {
            IEnumerable<string> results = _wordFinder.Find(new string[] { "lorem#", "ipsum#" });
            Assert.True(results.Count() == 0);
        }
    }
}
