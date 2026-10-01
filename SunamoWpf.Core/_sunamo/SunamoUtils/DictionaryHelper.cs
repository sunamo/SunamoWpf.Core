#define ASYNC
namespace SunamoWpf.Core._sunamo;

internal class DictionaryHelper
{
    /// <summary>
    ///     A3 is inner type of collection entries
    ///     dictS => is comparing with string
    ///     As inner must be List, not IList etc.
    ///     From outside is not possible as inner use other class based on IList
    /// </summary>
    /// <typeparam name="Key"></typeparam>
    /// <typeparam name="Value"></typeparam>
    /// <typeparam name="ColType"></typeparam>
    /// <param name="sl"></param>
    /// <param name="key"></param>
    /// <param name="value"></param>
    public static void AddOrCreate<Key, Value, ColType>(IDictionary<Key, List<Value>> dict, Key key, Value value,
    bool withoutDuplicitiesInValue = false, Dictionary<Key, List<string>> dictS = null)
    {
        var compWithString = false;
        if (dictS != null) compWithString = true;
        if (key is IList && typeof(ColType) != typeof(Object))
        {
            var keyE = key as IList<ColType>;
            var contains = false;
            foreach (var item in dict)
            {
                var keyD = item.Key as IList<ColType>;
                if (keyD.SequenceEqual(keyE)) contains = true;
            }
            if (contains)
            {
                foreach (var item in dict)
                {
                    var keyD = item.Key as IList<ColType>;
                    if (keyD.SequenceEqual(keyE))
                    {
                        if (withoutDuplicitiesInValue)
                            if (item.Value.Contains(value))
                                return;
                        item.Value.Add(value);
                    }
                }
            }
            else
            {
                List<Value> ad = new();
                ad.Add(value);
                dict.Add(key, ad);
                if (compWithString)
                {
                    List<string> ad2 = new();
                    ad2.Add(value.ToString());
                    dictS.Add(key, ad2);
                }
            }
        }
        else
        {
            var add = true;
            lock (dict)
            {
                if (dict.ContainsKey(key))
                {
                    if (withoutDuplicitiesInValue)
                    {
                        if (dict[key].Contains(value))
                            add = false;
                        else if (compWithString)
                            if (dictS[key].Contains(value.ToString()))
                                add = false;
                    }
                    if (add)
                    {
                        var val = dict[key];
                        if (val != null) val.Add(value);
                        if (compWithString)
                        {
                            var val2 = dictS[key];
                            if (val != null) val2.Add(value.ToString());
                        }
                    }
                }
                else
                {
                    if (!dict.ContainsKey(key))
                    {
                        List<Value> ad = new();
                        ad.Add(value);
                        dict.Add(key, ad);
                    }
                    else
                    {
                        dict[key].Add(value);
                    }
                    if (compWithString)
                    {
                        if (!dictS.ContainsKey(key))
                        {
                            List<string> ad2 = new();
                            ad2.Add(value.ToString());
                            dictS.Add(key, ad2);
                        }
                        else
                        {
                            dictS[key].Add(value.ToString());
                        }
                    }
                }
            }
        }
    }
    /// <summary>
    ///     Pokud A1 bude obsahovat skupinu pod názvem A2, vložím do této skupiny prvek A3
    ///     Jinak do A1 vytvořím novou skupinu s klíčem A2 s hodnotou A3
    /// </summary>
    /// <typeparam name="Key"></typeparam>
    /// <typeparam name="Value"></typeparam>
    /// <param name="sl"></param>
    /// <param name="key"></param>
    /// <param name="p"></param>
    public static void AddOrCreate<Key, Value>(IDictionary<Key, List<Value>> sl, Key key, Value value,
    bool withoutDuplicitiesInValue = false, Dictionary<Key, List<string>> dictS = null)
    {
        AddOrCreate<Key, Value, object>(sl, key, value, withoutDuplicitiesInValue, dictS);
    }

    public static void AddOrSet<T1, T2>(IDictionary<T1, T2> qs, T1 k, T2 v)
    {
        if (qs.ContainsKey(k))
        {
            qs[k] = v;
        }
        else
        {
            qs.Add(k, v);
        }
    }
}
