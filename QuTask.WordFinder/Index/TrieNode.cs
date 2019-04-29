using System.Collections.Generic;

namespace QuTask
{
    public class TrieNode
    {
        /// <summary>
        /// The actual character stored at this node
        /// </summary>
        /// <value></value>
        public char Value { get; set; }

        /// <summary>
        /// How many levels into the trie is this node located at
        /// </summary>
        /// <value></value>
        public int Level { get; set; }

        /// <summary>
        /// All children nodes
        /// </summary>
        /// <value></value>
        public List<TrieNode> Children { get; set; }

        /// <summary>
        /// Only on leaf ndoes, the amount of occurrences a finalized string was stored in the trie
        /// </summary>
        /// <value></value>
        public int Count { get; set; }

        /// <summary>
        /// A trie node
        /// </summary>
        /// <param name="value">A character from a string</param>
        /// <param name="depth">How many levels into the trie is this node located at</param>
        public TrieNode(char value, int depth)
        {
            Value = value;
            Children = new List<TrieNode>();
            Level = depth;
        }

        /// <summary>
        /// Find the first child node that matches a given character
        /// </summary>
        /// <param name="character">The character to find</param>
        /// <returns>The node found, null if no match was found</returns>
        public TrieNode FindChildNode(char character)
        {
            foreach (var childNode in Children)
                if (childNode.Value == character)
                {
                    return childNode;
                }

            return null;
        }
    }
}
