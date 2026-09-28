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
            /// <param name="sc"></param>
            public Asc(ISunamoComparer<string> sc)
            {
                _sc = sc;
            }


            public int Compare(string x, string y)
            {
                return _sc.Asc(x, y);
            }
        }

        internal class Desc : IComparer<string>
        {
            private readonly ISunamoComparer<string> _sc;

            /// <summary>
            ///     As parameter I can insert SunamoComparer.IListCharLength or SunamoComparer.StringLength
            /// </summary>
            /// <param name="sc"></param>
            internal Desc(ISunamoComparer<string> sc)
            {
                _sc = sc;
            }


            public int Compare(string x, string y)
            {
                return _sc.Desc(x, y);
            }
        }
    }
}