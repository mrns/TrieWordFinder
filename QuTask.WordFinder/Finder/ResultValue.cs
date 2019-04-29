namespace QuTask
{
    /// <summary>
    /// Result value used by the WordFinder.Find function.
    /// </summary>
    class ResultValue
    {
        /// <summary>
        /// The amount of times a string was searched
        /// </summary>
        /// <value></value>
        public int SearchCount { get; set; }

        /// <summary>
        /// Wether the string was found or not
        /// </summary>
        /// <value></value>
        public bool Found { get; set; }
    }
}