using System;
using System.Collections.Generic;
using System.Linq;

namespace QuTask
{
    /// <summary>
    /// Creates an index optimzed for search based on a given Enumerable of strings
    /// </summary>
    public class WordFinder
    {
        private const int MAX_MATRIX_SIZE = 64;
        private Trie _trie;
        private int _totalWords = 0;
        private int _totalChars = 0;
        private int _totalRows;
        private int _totalColumns;

        /// <summary>
        /// Generate a WordFinder instance and populate its index
        /// </summary>
        /// <param name="matrix"></param>
        public WordFinder(IEnumerable<string> matrix)
        {
            if (matrix.Count() > MAX_MATRIX_SIZE)
            {
                throw new Exception($"Matrix must contain a maximum of {MAX_MATRIX_SIZE} rows");
            }

            if (matrix.Count() == 0)
            {
                throw new Exception($"Matrix must contain at list one string");
            }

            _totalRows = matrix.Count();
            _totalColumns = matrix.ElementAt(0).Length;

            // [DM] a real character matrix is created only to make the index creation code more readable
            char[,] characterMatrix = GenerateCharacterMatrix(matrix);
            _trie = CreateIndex(characterMatrix);
        }

        /// <summary>
        /// Searches all given strings in the input matrix
        /// </summary>
        /// <param name="wordstream">The collection of string to look for</param>
        /// <returns>The top 10 most repeatedly searched words that exist in the input matrix</returns>
        public IEnumerable<string> Find(IEnumerable<string> wordstream)
        {
            Dictionary<string, ResultValue> results = new Dictionary<string, ResultValue>();
            foreach (string word in wordstream)
            {
                if (!results.TryGetValue(word, out var result))
                {
                    results.Add(word, new ResultValue() { SearchCount = 1, Found = _trie.Search(word) });
                }
                else
                {
                    result.SearchCount++;
                }
            }

            IEnumerable<string> ranking = new List<string>();
            if (results.Count > 0)
            {
                ranking = (
                    from word in results
                    where word.Value.Found
                    orderby word.Value.SearchCount descending
                    select word.Key).Take(10);
            }

            return ranking;
        }

        /// <summary>
        /// Creates a character based trie structure for all words found on the input matrix
        /// </summary>
        /// <param name="characterMatrix">The character matrix from which words must be extracted</param>
        /// <returns>The character based trie structure</returns>
        private Trie CreateIndex(char[,] characterMatrix)
        {
            int i = 0;
            int j = 0;
            Trie trie = new Trie();

            while (i < _totalRows)
            {
                while (j < _totalColumns)
                {
                    IEnumerable<string> words = GetAllWordsFromPosition(characterMatrix, i, j);
                    foreach (string word in words)
                    {
                        trie.Upsert(word);
                        _totalWords++;
                    }
                    j++;
                    _totalChars++;
                }
                j = 0;
                i++;
            }

            return trie;
        }

        /// <summary>
        /// Gets the list of all possible valid words found in the matrix at a given position
        /// Words of any length are considered valid but only going from left to right and top to bottom.
        /// </summary>
        /// <param name="characterMatrix"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        private IEnumerable<string> GetAllWordsFromPosition(char[,] characterMatrix, int i, int j)
        {
            List<string> words = new List<string>();
            int row = i;
            int column = j;
            string word = string.Empty;

            while (column < _totalColumns)
            {
                word += characterMatrix[i, column];
                words.Add(word);

                column++;
            }

            word = string.Empty;
            while (row < _totalRows)
            {
                word += characterMatrix[row, j];
                words.Add(word);

                row++;
            }

            return words;
        }

        /// <summary>
        /// Generate a proper multidimensional array of characters to represent the incoming collection of strings
        /// </summary>
        /// <param name="matrix">A collection of strings containing words, both horizontally and vertically</param>
        /// <returns>The multidimensional array of characters</returns>
        private char[,] GenerateCharacterMatrix(IEnumerable<string> matrix)
        {
            char[,] characterMatrix = new char[_totalRows, _totalColumns];

            int i = 0;
            int j = 0;
            string rowWord = string.Empty;

            foreach (string row in matrix)
            {
                foreach (char character in row)
                {
                    rowWord += row[j];
                    characterMatrix[i, j] = character;
                    j++;
                }

                i++;
                j = 0;
            }

            return characterMatrix;
        }
    }
}