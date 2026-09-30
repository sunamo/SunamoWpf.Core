#define ASYNC
namespace SunamoWpf.Core._sunamo;

/// <summary>
/// </summary>
internal class CyclingCollection<T> //: IStatusBroadcaster
{
    internal static string xUnableToLoadElementAddSomeAndTryAgain = "UnableToLoadElementAddSomeAndTryAgain";
    internal bool back;

    internal CyclingCollection(bool Cycling)
    {
        this.Cycling = Cycling;
    }

    internal CyclingCollection()
    {
    }

    internal int ActualIndex => index;

    internal bool MakesSpaces
    {
        get => _MakesSpaces;
        set
        {
            _MakesSpaces = value;
            OnChange();
        }
    }

    internal T GetIterationSimple
    {
        get
        {
            if (c.Count == 0) return default;
            return c[index];
        }
    }

    /// <summary>
    ///     If can't be obtained, try to get element previous or next.
    /// </summary>
    internal T GetIretation
    {
        get
        {
            T t2 = default;
            var dex = Math.Abs(index);
            if (c.Count > dex && c.Count >= dex)
            {
                t2 = c[dex];
            }
            else
            {
                dex = Math.Abs(++index);
                if (c.Count > dex && c.Count >= dex)
                {
                    t2 = c[dex];
                }
                else
                {
                    index--;
                    dex = Math.Abs(--index);
                    if (c.Count > dex && c.Count >= dex)
                    {
                        t2 = c[dex];
                    }
                    else
                    {
                        if (c.Count > 0)
                            t2 = c[0];
                        else
                            OnNewStatus(xUnableToLoadElementAddSomeAndTryAgain);
                    }
                }
            }

            return t2;
        }
    }

    internal void Add(T t)
    {
        c.Add(t);
        _index++;
        OnChange();
    }

    internal void AddRange(IList<T> k)
    {
        //t.AddRange(k);
        foreach (var item in k)
        {
            c.Add(item);
            _index++;
        }

        OnChange();
    }

    internal void Clear()
    {
        c.Clear();
        _index = 0;
        OnChange();
    }

    internal T SetIretation(int ir)
    {
        index = ValidateIndex(ir);
        OnChange();
        return GetIretation;
    }

    private int ValidateIndex(int ir)
    {
        if (ir < 0)
            ir = c.Count - 1;
        else if (ir >= c.Count) ir = 0;

        return ir;
    }

    internal void SetIretationWithoutEvent(int p)
    {
        index = p;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.Append(ActualIndex + 1);
        if (_MakesSpaces) sb.Append(" ");
        sb.Append("/");
        if (_MakesSpaces) sb.Append(" ");
        sb.Append(c.Count.ToString());
        return sb.ToString();
    }

    internal void ReplaceOnce(T p, T nove)
    {
        var dex = c.IndexOf(p);
        c.RemoveAt(dex);
        c.Insert(dex, nove);
    }

    private static string ReplaceOnce(string input, string what, string zaco)
    {
        if (what == "") return input;

        var pos = input.IndexOf(what);
        if (pos == -1) return input;
        return input.Substring(0, pos) + zaco + input.Substring(pos + what.Length);
    }

    internal List<T> c = new();
    private int _index;

    private int index
    {
        get
        {
            if (_index < 0)
                _index = 0;
            else if (_index > c.Count - 1) _index = c.Count - 1;
            return _index;
        }
        set
        {
            if (value < 0) value = 0;
            _index = value;
        }
    }

    /// <summary>
    ///     Whether make space in formatting actual showing
    /// </summary>
    private bool _MakesSpaces;

    internal event Action Change;

    private EventArgs _ea = EventArgs.Empty;
    internal bool Cycling = true;

    internal T Before()
    {
        back = true;
        if (Cycling)
        {
            if (index == 0)
                index = c.Count - 1;
            else
                index--;

            //OnChange();
        }
        else
        {
            if (index != 0) index--;
            //OnChange();
        }

        OnChange();
        return GetIretation;
    }

    internal T Next()
    {
        back = false;
        if (Cycling)
        {
            if (index == c.Count - 1)
                index = 0;
            else
                index++;
            //OnChange();
        }
        else
        {
            if (index != c.Count - 1) index++;
            //OnChange();
        }

        OnChange();
        return GetIretation;
    }

    internal T Before(int pocet)
    {
        if (pocet > c.Count) return GetIretation;
        index -= pocet;
        var dex = index;

        if (dex == 0)
        {
        }
        else if (dex < 0)
        {
            var odecist = Math.Abs(dex);
            var vNovem = c.Count - odecist;
            index = vNovem;
        }
        else
        {
            //index-= pocet;
            index = dex;
        }

        OnChange();
        return GetIretation;
    }

    internal T Next(int pocet)
    {
        if (pocet > c.Count) return GetIretation;
        index += pocet;
        var dex = index;
        if (dex == 0)
        {
        }
        else if (dex > c.Count)
        {
            // Zjistim o kolik a tolik posunu i v novem
            var vNovem = dex - c.Count;
            index = vNovem;
        }
        else
        {
            //
            index = dex;
        }

        OnChange();
        return GetIretation;
    }

    internal void OnChange()
    {
        if (Change != null) Change();
    }

    internal event Action<string> NewStatus;

    internal void OnNewStatus(string s, params string[] p)
    {
        if (NewStatus != null) NewStatus(string.Format(s, p));
    }

}
