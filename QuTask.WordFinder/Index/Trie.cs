using System.Collections.Generic;

namespace QuTask
{
    /// <summary>
    /// A trie implementation to store strings and keep count of their occurrences
    /// </summary>
    public class Trie
    {

        private readonly TrieNode _rootNode;

        public Trie()
        {
            _rootNode = new TrieNode('^', 0);
        }

        /// <summary>
        /// Gets the best matching node for a given string.
        /// </summary>
        /// <param name="s">The string to look for</param>
        /// <returns>The best matching node</returns>
        public TrieNode GetPrefixNode(string s)
        {
            var currentNode = _rootNode;
            var result = currentNode;

            foreach (var c in s)
            {
                currentNode = currentNode.FindChildNode(c);
                if (currentNode == null)
                {
                    // [DM] best matching prefix found
                    break;
                }
                result = currentNode;
            }

            return result;
        }

        /// <summary>
        /// Check if given string exists in the trie 
        /// </summary>
        /// <param name="s">String to search for</param>
        /// <returns>True if found</returns>
        public bool Search(string s)
        {
            var prefix = GetPrefixNode(s);
            return prefix.Level == s.Length && prefix.FindChildNode('$') != null;
        }

        /// <summary>
        /// Insert a new string in the trie or update its leaf node's Count value if it already exists
        /// </summary>
        /// <param name="s">The string to upsert</param>
        public void Upsert(string s)
        {
            var commonPrefix = GetPrefixNode(s);
            var current = commonPrefix;

            if (commonPrefix.Level == s.Length)
            {
                TrieNode endNode = commonPrefix.FindChildNode('$');
                endNode.Count++;
                return;
            }

            for (var i = current.Level; i < s.Length; i++)
            {
                var newNode = new TrieNode(s[i], current.Level + 1);
                current.Children.Add(newNode);
                current = newNode;
            }

            current.Children.Add(new TrieNode('$', current.Level + 1));
        }

    }
}