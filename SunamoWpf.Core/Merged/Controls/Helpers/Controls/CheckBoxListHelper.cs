public class CheckBoxListHelper
{
    public static IList<int> CheckedIndexes(IList<CheckBox> chbs)
    {
        //chbs[0].IsChecked = true;
        var indexes = chbs.Select((v, i) => new { v, i });
        var where = indexes.Where(entry => BTS.GetValueOfNullable(entry.v.IsChecked));
        List<int> result = new List<int>();
        foreach (var item in where)
        {
            result.Add(item.i);
        }
        //var select = where.Select(x => x.i);
        //where.SelectMany<int>(d => d.;
        return result;
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
        var where = indexes.Where(entry => !BTS.GetValueOfNullable(entry.v.IsChecked));
        return where.Select(entry2 => entry2.v.Content).Cast<StackPanel>().ToList();
    }

    /// <summary>
    /// Return StackPanel which have as only one child TextBlock
    /// </summary>
    /// <param name="chbs"></param>
    public static IList<StackPanel> CheckedContent(IList<CheckBox> chbs)
    {
        //chbs[0].IsChecked = true;
        var indexes = chbs.Select((v, i) => new { v, i });
        var where = indexes.Where(entry => BTS.GetValueOfNullable(entry.v.IsChecked));
        return where.Select(entry2 => entry2.v.Content).Cast<StackPanel>().ToList();
    }

    /// <summary>
    /// Return StackPanel which have as only one child TextBlock
    /// </summary>
    /// <param name="chbs"></param>
    public static List<string> CheckedStrings(IList<CheckBox> chbs)
    {
        //chbs[0].IsChecked = true;
        var indexes = chbs.Select((v, i) => new { v, i });
        var where = indexes.Where(entry => CheckBoxHelper.IsChecked(entry.v));

        var stackPanels = where.Select(entry2 => ContentControlHelper.Content(entry2.v)).Cast<StackPanel>().ToList();
        List<string> result = new List<string>(stackPanels.Count);
        foreach (var item in stackPanels)
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
        List<StackPanel> result = null;

        if (chbs.Count() > 0)
        {
            result = chbs.Select(checkBox => (StackPanel)checkBox.Dispatcher.Invoke(() => { return (StackPanel)checkBox.Content; })).ToList();

            //Nevím proč to převádím na string když o řádek níže to dávám na StackPanel
            //var result = CA.ToListString(d);
            return result.Cast<StackPanel>().ToList();
        }
        return new List<StackPanel>();
    }
}
