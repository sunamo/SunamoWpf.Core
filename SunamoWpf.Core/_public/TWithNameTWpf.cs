namespace SunamoWpf._public;

public class TWithNameTWpf<T>
{
    /// <summary>
    ///     Just first 5. letters
    /// </summary>
    public string name = string.Empty;

    public T t;

    public TWithNameTWpf()
    {
    }

    public TWithNameTWpf(string name, T t)
    {
        this.name = name;
        this.t = t;
    }

    public override string ToString()
    {
        return name;
    }

    public static TWithNameTWpf<T> Get(string nameCb)
    {
        return new TWithNameTWpf<T> { name = nameCb };
    }
}