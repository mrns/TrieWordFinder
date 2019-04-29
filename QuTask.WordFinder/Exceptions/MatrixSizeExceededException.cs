namespace QuTask.Exceptions
{
    [System.Serializable]
    public class MatrixSizeExceededException : System.Exception
    {
        public MatrixSizeExceededException() { }
        public MatrixSizeExceededException(string message) : base(message) { }
        public MatrixSizeExceededException(string message, System.Exception inner) : base(message, inner) { }
        protected MatrixSizeExceededException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}