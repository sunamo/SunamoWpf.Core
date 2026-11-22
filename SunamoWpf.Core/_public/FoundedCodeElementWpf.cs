namespace SunamoWpf._public;

/// <summary>
/// Represents the founded code element wpf type.
/// </summary>
public class FoundedCodeElementWpf : IComparable<FoundedCodeElementWpf>
{
    /// <summary>
    ///     Is -1 if location isnt known (search in content and so)
    /// </summary>
    public int From;

    /// <summary>
    /// The lenght.
    /// </summary>
    public int Lenght;

    /// <summary>
    /// The line.
    /// </summary>
    public int Line;

    /// <summary>
    /// Initializes a new instance of the founded code element wpf class.
    /// </summary>
    /// <param name="line">The line.</param>
    /// <param name="from">The from.</param>
    /// <param name="length">The length.</param>
    public FoundedCodeElementWpf(int line, int from, int length)
    {
        Lenght = length;
        Line = line;
        From = from;
    }

    /// <summary>
    /// Compare to.
    /// </summary>
    /// <param name="other">The other.</param>
    /// <returns>The compare to result.</returns>
    public int CompareTo(FoundedCodeElementWpf other)
    {
        return 0;
        // todo zakomentováno než budu mít vyřešenou hiarchii v nugetech
        //return SunamoComparer.Integer.Instance.Asc(Line, other.Line);
    }
}