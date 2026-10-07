namespace SunamoWpf._public;

public class ABWpf
{
    public static Type type = typeof(ABWpf);
    public string A;
    public object B;

    public ABWpf(string first, object second)
    {
        A = first;
        B = second;
    }


    /// <param name="first"></param>
    /// <param name="second"></param>
    public static ABWpf Get(string first, object second)
    {
        return new ABWpf(first, second);
    }

    public override string ToString()
    {
        return A + ":" + B;
    }
}