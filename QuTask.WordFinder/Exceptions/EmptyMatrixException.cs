namespace QuTask.Exceptions
{
    [System.Serializable]
    public class EmptyMatrixException : System.Exception
    {
        public EmptyMatrixException() { }
        public EmptyMatrixException(string message) : base(message) { }
        public EmptyMatrixException(string message, System.Exception inner) : base(message, inner) { }
        protected EmptyMatrixException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}