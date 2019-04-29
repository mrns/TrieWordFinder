[System.Serializable]
public class RowCannotBeNullException : System.Exception
{
    public RowCannotBeNullException() { }
    public RowCannotBeNullException(string message) : base(message) { }
    public RowCannotBeNullException(string message, System.Exception inner) : base(message, inner) { }
    protected RowCannotBeNullException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}