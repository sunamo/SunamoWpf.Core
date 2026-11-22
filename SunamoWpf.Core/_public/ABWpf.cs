namespace SunamoWpf._public;

/// <summary>
/// Represents the AB wpf type.
/// </summary>
public class ABWpf
{
    /// <summary>
    /// The type.
    /// </summary>
    public static Type type = typeof(ABWpf);
    /// <summary>
    /// The a.
    /// </summary>
    public string A;
    /// <summary>
    /// The b.
    /// </summary>
    public object B;

    /// <summary>
    /// Initializes a new instance of the AB wpf class.
    /// </summary>
    /// <param name="first">The first.</param>
    /// <param name="second">The second.</param>
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

    /// <summary>
    /// To string.
    /// </summary>
    /// <returns>The to string result.</returns>
    public override string ToString()
    {
        return A + ":" + B;
    }
}