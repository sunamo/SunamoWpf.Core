namespace SunamoWpf._shared;

internal class SunamoComparer
{
    internal class StringLength : ISunamoComparer<string>
    {
        internal static StringLength Instance = new();

        public int Desc(string left, string right)
        {
            var leftLength = left.Length;
            var rightLength = right.Length;
            return leftLength.CompareTo(rightLength) * -1;
        }

        public int Asc(string left, string right)
        {
            var leftLength = left.Length;
            var rightLength = right.Length;
            return leftLength.CompareTo(rightLength);
        }
    }
}