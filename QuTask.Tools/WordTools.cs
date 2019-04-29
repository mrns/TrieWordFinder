using System;
using System.Linq;
using Bogus;

namespace QuTask.Tools
{
    public static class WordTools
    {
        private static string CHARS = "abcdefghijklmnopqrstuvwxyz";
        public static string[] _sampleWordStream = new string[15]{
            "one#",
            "two#",
            "two#",
            "three#",
            "three#",
            "three#",
            "four#",
            "five#",
            "six#",
            "seven#",
            "eight#",
            "nine#",
            "ten#",
            "eleven#",
            "twelve#"};
        private static Random _random = new Random();

        private static Randomizer _randomizer = new Randomizer();
        public static string GetRandomSampleWord()
        {
            return GetSampleWord(_random.Next(0, _sampleWordStream.Count()));
        }

        public static string GetSampleWord(int index)
        {
            return _sampleWordStream.ElementAt(index);
        }

        public static char GetRandomChar()
        {
            return CHARS[_random.Next(0, 25)];
        }

        public static string GetRandomWord()
        {
            string randomWord = _randomizer.Word();

            if (randomWord.IndexOf(' ') > 0)
            {
                randomWord = randomWord.Substring(0, randomWord.IndexOf(' '));
            }

            randomWord.Trim(new char[] { ',', '-' });
            return randomWord;
        }
    }
}