namespace SunamoWpf._public;

public class TUWpf<T, U>
{
    public T Key;
    public U Value;

    public TUWpf()
    {
    }

    public TUWpf(T key, U value)
    {
        Key = key;
        Value = value;
    }

    public static TUWpf<T, U> Get(T key, U value)
    {
        return new TUWpf<T, U>(key, value);
    }
}