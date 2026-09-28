namespace SunamoWpf._public;

public class FoundedCodeElementWpf : IComparable<FoundedCodeElementWpf>
{
    /// <summary>
    ///     Is -1 if location isnt known (search in content and so)
    /// </summary>
    public int From;

    public int Lenght;

    public int Line;

    public FoundedCodeElementWpf(int line, int from, int length)
    {
        Lenght = length;
        Line = line;
        From = from;
    }

    public int CompareTo(FoundedCodeElementWpf other)
    {
        return 0;
        // todo zakomentováno než budu mít vyřešenou hiarchii v nugetech
        //return SunamoComparer.Integer.Instance.Asc(Line, other.Line);
    }
}