namespace SunamoWpf._public;

public class ABWpf
{
    public static Type type = typeof(ABWpf);
    public string A;
    public object B;

    public ABWpf(string a, object b)
    {
        A = a;
        B = b;
    }


    /// <param name="a"></param>
    /// <param name="b"></param>
    public static ABWpf Get(string a, object b)
    {
        return new ABWpf(a, b);
    }

    public override string ToString()
    {
        return A + ":" + B;
    }
}