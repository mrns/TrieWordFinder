namespace QuTask.Exceptions
{
    [System.Serializable]
    public class DifferentLengthRowsException : System.Exception
    {
        public DifferentLengthRowsException() { }
        public DifferentLengthRowsException(string message) : base(message) { }
        public DifferentLengthRowsException(string message, System.Exception inner) : base(message, inner) { }
        protected DifferentLengthRowsException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}