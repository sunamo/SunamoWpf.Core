namespace SunamoWpf._shared;

internal class SunamoComparer
{
    internal class StringLength : ISunamoComparer<string>
    {
        internal static StringLength Instance = new();

        public int Desc(string x, string y)
        {
            var a = x.Length;
            var b = y.Length;
            return a.CompareTo(b) * -1;
        }

        public int Asc(string x, string y)
        {
            var a = x.Length;
            var b = y.Length;
            return a.CompareTo(b);
        }
    }
}