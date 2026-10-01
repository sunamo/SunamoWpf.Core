public class CheckBoxListHelper
{
    public static IList<int> CheckedIndexes(IList<CheckBox> chbs)
    {
        //chbs[0].IsChecked = true;
        var indexes = chbs.Select((v, i) => new { v, i });
        var where = indexes.Where(x => BTS.GetValueOfNullable(x.v.IsChecked));
        List<int> v2 = new List<int>();
        foreach (var item in where)
        {
            v2.Add(item.i);
        }
        //var select = where.Select(x => x.i);
        //where.SelectMany<int>(d => d.;
        return v2;
    }

    //
    public static Dictionary<StackPanel, bool> CheckedContentDict(IList<CheckBox> chbs)
    {
        var unticked = UncheckedContent(chbs);
        var ticked = CheckedContent(chbs);

        Dictionary<StackPanel, bool> result = new Dictionary<StackPanel, bool>();

        foreach (var item in unticked)
        {
            result.Add(item, false);
        }

        foreach (var item in ticked)
        {
            result.Add(item, true);
        }

        return result;
    }

    /// <summary>
    /// Return StackPanel which have as only one child TextBlock
    /// </summary>
    /// <param name="chbs"></param>
    public static IList<StackPanel> UncheckedContent(IList<CheckBox> chbs)
    {
        //chbs[0].IsChecked = true;
        var indexes = chbs.Select((v, i) => new { v, i });
        var where = indexes.Where(x => !BTS.GetValueOfNullable(x.v.IsChecked));
        return where.Select(d => d.v.Content).Cast<StackPanel>().ToList();
    }

    /// <summary>
    /// Return StackPanel which have as only one child TextBlock
    /// </summary>
    /// <param name="chbs"></param>
    public static IList<StackPanel> CheckedContent(IList<CheckBox> chbs)
    {
        //chbs[0].IsChecked = true;
        var indexes = chbs.Select((v, i) => new { v, i });
        var where = indexes.Where(x => BTS.GetValueOfNullable(x.v.IsChecked));
        return where.Select(d => d.v.Content).Cast<StackPanel>().ToList();
    }

    /// <summary>
    /// Return StackPanel which have as only one child TextBlock
    /// </summary>
    /// <param name="chbs"></param>
    public static List<string> CheckedStrings(IList<CheckBox> chbs)
    {
        //chbs[0].IsChecked = true;
        var indexes = chbs.Select((v, i) => new { v, i });
        var where = indexes.Where(x => CheckBoxHelper.IsChecked(x.v));

        var sp = where.Select(d => ContentControlHelper.Content(d.v)).Cast<StackPanel>().ToList();
        List<string> result = new List<string>(sp.Count);
        foreach (var item in sp)
        {
            result.Add(CheckBoxListUC.ContentOfTextBlock(item));
        }
        return result;
    }

    /// <summary>
    /// Return StackPanel which have as only one child TextBlock
    /// </summary>
    /// <param name="chbs"></param>
    public static List<StackPanel> AllContent(IList<CheckBox> chbs)
    {
        List<StackPanel> d = null;

        if (chbs.Count() > 0)
        {
            d = chbs.Select(e => (StackPanel)e.Dispatcher.Invoke(() => { return (StackPanel)e.Content; })).ToList();

            //Nevím proč to převádím na string když o řádek níže to dávám na StackPanel
            //var result = CA.ToListString(d);
            return d.Cast<StackPanel>().ToList();
        }
        return new List<StackPanel>();
    }
}
