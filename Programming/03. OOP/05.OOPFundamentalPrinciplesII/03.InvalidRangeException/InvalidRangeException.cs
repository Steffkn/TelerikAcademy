// library for InvalidRangeException
using System;
[Serializable()]
public class InvalidRangeException<T> : ArgumentOutOfRangeException
{
    public T MinValue { get; private set; }
    public T MaxValue { get; private set; }

    // 4 constructors
    public InvalidRangeException() : base() { }

    public InvalidRangeException(string msg, T minValue, T maxValue)
        : base(msg)
    {
        this.MinValue = minValue;
        this.MaxValue = maxValue;
    }

    public InvalidRangeException(string msg, T minValue, T maxValue, Exception innerEx)
        : base(msg, innerEx)
    {
        this.MinValue = minValue;
        this.MaxValue = maxValue;
    }

    // A constructor is needed for serialization when an 
    // exception propagates from a remoting server to the client.  
    protected InvalidRangeException(System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) { }
}
