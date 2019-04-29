[System.Serializable]
public class NullOrEmptyFirstRowException : System.Exception
{
    public NullOrEmptyFirstRowException() { }
    public NullOrEmptyFirstRowException(string message) : base(message) { }
    public NullOrEmptyFirstRowException(string message, System.Exception inner) : base(message, inner) { }
    protected NullOrEmptyFirstRowException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}