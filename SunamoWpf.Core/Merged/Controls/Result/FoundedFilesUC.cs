#define ASYNC
namespace SunamoWpf.Controls.Result;

public class FoundedFilesUC : FoundedResultsUC//, IFoundedFilesUC<FoundedFileUC>, IFoundedResultsUC<IFoundedFileUC>
{
    public FoundedFilesUC()
    {
        Loaded += FoundedFilesUC_Loaded;
        SizeChanged += FoundedFilesUC_SizeChanged;
    }
    private void FoundedFilesUC_SizeChanged(object sender, System.Windows.SizeChangedEventArgs eventArgs)
    {
#if DEBUG
        //FrameworkElementDebug.ActualSize(this);
#endif
    }
    private void FoundedFilesUC_Loaded(object sender, System.Windows.RoutedEventArgs eventArgs)
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
    /// <param name="colors"></param>
    public void AddFoundedFiles(List<string> foundedList, TUListWpf<string, System.Windows.Media.Brush> colors)
    {
        HideTbNoResultsFound();
        int index = 0;
        foreach (var item in foundedList)
        {
            AddFoundedFile(item, colors, ref index);
        }
    }
    /// <summary>
    /// A2 is require but is available through FoundedFilesUC.DefaultBrush
    /// Already inserted is not deleted
    /// </summary>
    /// <param name="foundedList"></param>
    /// <param name="colors"></param>
    public void AddFoundedFile(string item, TUListWpf<string, System.Windows.Media.Brush> colors, ref int index)
    {
        if (sp != null)
        {
            HideTbNoResultsFound();
            FoundedFileUC foundedFile = new FoundedFileUC(item, colors, index++);
            foundedFile.Selected += FoundedFile_Selected;
            sp.Children.Add(foundedFile);
        }
    }
    public void FoundedFile_Selected(string path)
    {
        selectedItem = path;
        OnSelected(path);
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
                Regex regex = null;
                if (WildcardHelper.IsWildcard(text))
                {
                    text = Wildcard.WildcardToRegex(text);
                    regex = new Regex(text);
                }
                foreach (FoundedFileUC item in sp.Children)
                {
                    if (item.Contains(regex, text))
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