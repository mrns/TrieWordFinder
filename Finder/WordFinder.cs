using System;
using System.Collections.Generic;
using System.Linq;

namespace quTest
{
    public class WordFinder
    {
        private const int MATRIX_SIZE = 64;
        private Trie _trie;
        private int _totalWords = 0;
        private int _totalChars = 0;
        public WordFinder(IEnumerable<string> matrix)
        {
            if (matrix.Count() != MATRIX_SIZE)
            {
                throw new Exception($"Matrix must contain a maximum of {MATRIX_SIZE} rows");
            }
            char[,] characterMatrix = GenerateCharacterMatrix(matrix);
            PopulateTrie(characterMatrix);
        }

        private void PopulateTrie(char[,] characterMatrix)
        {
            int i = 0;
            int j = 0;
            _trie = new Trie();

            while (i < MATRIX_SIZE)
            {
                while (j < MATRIX_SIZE)
                {
                    IEnumerable<string> words = GetAllWordsFromPosition(characterMatrix, i, j);
                    foreach (string word in words)
                    {
                        _trie.Insert(word);
                        _totalWords++;
                    }
                    j++;
                    _totalChars++;
                }
                j = 0;
                i++;
            }
        }

        private IEnumerable<string> GetAllWordsFromPosition(char[,] characterMatrix, int i, int j)
        {
            List<string> words = new List<string>();
            int row = i;
            int column = j;
            string word = string.Empty;

            while (column < MATRIX_SIZE)
            {
                word += characterMatrix[i, column];
                words.Add(word);

                column++;
            }

            word = string.Empty;
            while (row < MATRIX_SIZE)
            {
                word += characterMatrix[row, j];
                words.Add(word);

                row++;
            }

            return words;
        }

        private char[,] GenerateCharacterMatrix(IEnumerable<string> matrix)
        {
            char[,] characterMatrix = new char[MATRIX_SIZE, MATRIX_SIZE];

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

        public IEnumerable<string> Find(IEnumerable<string> wordstream)
        {
            Dictionary<string, ResultValue> results = new Dictionary<string, ResultValue>();
            foreach (string word in wordstream)
            {
                if (!results.TryGetValue(word, out var result))
                {
                    results.Add(word, new ResultValue() { SearchCount = 1 });
                }
                else
                {
                    result.SearchCount++;
                    if (!result.Found && _trie.Search(word))
                    {
                        result.Found = true;
                    }
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
    }
}