namespace SunamoWpf._shared;

internal class SunamoComparerICompare
{
    internal class StringLength
    {
        internal class Asc : IComparer<string>
        {
            private readonly ISunamoComparer<string> _sc;

            /// <summary>
            ///     As parameter I can insert SunamoComparer.IListCharLength or SunamoComparer.StringLength
            /// </summary>
            /// <param name="comparer"></param>
            public Asc(ISunamoComparer<string> comparer)
            {
                _sc = comparer;
            }


            public int Compare(string left, string right)
            {
                return _sc.Asc(left, right);
            }
        }

        internal class Desc : IComparer<string>
        {
            private readonly ISunamoComparer<string> _sc;

            /// <summary>
            ///     As parameter I can insert SunamoComparer.IListCharLength or SunamoComparer.StringLength
            /// </summary>
            /// <param name="comparer"></param>
            internal Desc(ISunamoComparer<string> comparer)
            {
                _sc = comparer;
            }


            public int Compare(string left, string right)
            {
                return _sc.Desc(left, right);
            }
        }
    }
}