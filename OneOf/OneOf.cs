namespace OneOf;

public class OneOf<T0, T1>
{
    private readonly object? _value;
    private readonly int _index;
    
    private OneOf(T0 value)
    {
        _value = value;
        _index = 0;
    }

    private OneOf(T1 value)
    {
        _value = value;
        _index = 1;
    }
    public static implicit operator OneOf<T0, T1>(T0 value) => new(value);
    
    public static implicit operator OneOf<T0, T1>(T1 value) => new(value);

    public T Match<T>(Func<T0, T> f0, Func<T1, T> f1)
    {
        return _index switch
        {
            0 => f0((T0)_value!),
            1 => f1((T1)_value!),
            _ => throw new InvalidOperationException()
        };
    }
}