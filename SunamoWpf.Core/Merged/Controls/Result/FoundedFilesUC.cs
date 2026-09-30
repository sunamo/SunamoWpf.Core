#define ASYNC
namespace SunamoWpf.Controls.Result;

public class FoundedFilesUC : FoundedResultsUC//, IFoundedFilesUC<FoundedFileUC>, IFoundedResultsUC<IFoundedFileUC>
{
    public FoundedFilesUC()
    {
        Loaded += FoundedFilesUC_Loaded;
        SizeChanged += FoundedFilesUC_SizeChanged;
    }
    private void FoundedFilesUC_SizeChanged(object sender, System.Windows.SizeChangedEventArgs e)
    {
#if DEBUG
        //FrameworkElementDebug.ActualSize(this);
#endif
    }
    private void FoundedFilesUC_Loaded(object sender, System.Windows.RoutedEventArgs e)
    {
    }
    public void AttachSelected(VoidString act)
    {
        Selected += act;
    }
    /// <summary>
    /// A2 is require but is available through FoundedFilesUC.DefaultBrush
    /// Already inserted is not deleted
    /// </summary>
    /// <param name="foundedList"></param>
    /// <param name="p"></param>
    public void AddFoundedFiles(List<string> foundedList, TUListWpf<string, System.Windows.Media.Brush> p)
    {
        HideTbNoResultsFound();
        int i = 0;
        foreach (var item in foundedList)
        {
            AddFoundedFile(item, p, ref i);
        }
    }
    /// <summary>
    /// A2 is require but is available through FoundedFilesUC.DefaultBrush
    /// Already inserted is not deleted
    /// </summary>
    /// <param name="foundedList"></param>
    /// <param name="p"></param>
    public void AddFoundedFile(string item, TUListWpf<string, System.Windows.Media.Brush> p, ref int i)
    {
        if (sp != null)
        {
            HideTbNoResultsFound();
            FoundedFileUC foundedFile = new FoundedFileUC(item, p, i++);
            foundedFile.Selected += FoundedFile_Selected;
            sp.Children.Add(foundedFile);
        }
    }
    public void FoundedFile_Selected(string s)
    {
        selectedItem = s;
        OnSelected(s);
    }
    public bool? Filter(string text)
    {
        bool cancel = string.IsNullOrWhiteSpace(text);
        if (sp != null)
        {
            if (cancel)
            {
                foreach (FoundedFileUC item in sp.Children)
                {
                    item.Visibility = System.Windows.Visibility.Visible;
                }
            }
            else
            {
                bool someVisible = false;
                Regex r = null;
                if (WildcardHelper.IsWildcard(text))
                {
                    text = Wildcard.WildcardToRegex(text);
                    r = new Regex(text);
                }
                foreach (FoundedFileUC item in sp.Children)
                {
                    if (item.Contains(r, text))
                    {
                        someVisible = true;
                        item.Visibility = System.Windows.Visibility.Visible;
                    }
                    else
                    {
                        item.Visibility = System.Windows.Visibility.Collapsed;
                    }
                }
                if (!someVisible)
                {
                    OnSelected(null);
                }
            }
        }
        return cancel;
    }
}