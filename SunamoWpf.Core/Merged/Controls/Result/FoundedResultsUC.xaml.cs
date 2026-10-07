#define ASYNC
namespace SunamoWpf.Controls.Result;

public partial class FoundedResultsUC : UserControl, ISelectedTWpf<string>//, IFoundedResultsUC<FoundedFileUC>
{
    #region Rewrite to pure cs. With xaml is often problems without building
    public static Type type = typeof(FoundedResultsUC);
    public event VoidString Selected;
    protected string selectedItem = null;
    public string SelectedItem => selectedItem;
    public static List<string> basePaths = [];
    //public SearchInUC txtFilter = null;
    //public StackPanel sp = null;
    //public ScrollViewer sv = null;
    //public TextBlock tbNoResultsFound = null;
    public FoundedResultsUC()
    {
        try
        {
            InitializeComponent();
        }
        catch (Exception)
        {
#if DEBUG
            Debugger.Break();
#endif
        }
        Loaded += FoundedResultsUC_Loaded;
        SizeChanged += FoundedResultsUC_SizeChanged;
    }
    private void FoundedResultsUC_SizeChanged(object sender, SizeChangedEventArgs eventArgs)
    {
#if DEBUG
        //FrameworkElementDebug.ActualSize(this);
        //FrameworkElementDebug.ActualSize(sv);
        //FrameworkElementDebug.ActualSize(sp);
#endif
    }
    private void FoundedResultsUC_Loaded(object sender, RoutedEventArgs eventArgs)
    {
        //DataContext = new FoundedResultViewModel();
        //if (txtFilter != null)
        //{
        //    txtFilter.BorderBrush = Brushes.Tomato;
        //    txtFilter.tb.Text = sess.i18n(XlfKeys.Filter) + " (" + sess.i18n(XlfKeys.alsoWildcard) + "): ";
        //}
        ////miCopyToClipboardFounded.Header = sess.i18n(XlfKeys.CopyToClipboardFounded);
        //FoundedResultViewModel.Do += FoundedResultViewModel_Do;
    }
    private void FoundedResultViewModel_Do(FoundedResultActions obj)
    {
        if (obj == FoundedResultActions.CopyToClipboardFounded)
        {
            if (sp != null)
            {
                StringBuilder stringBuilder = new StringBuilder();
                foreach (FoundedFileUC item in sp.Children)
                {
                    if (item.Visibility == Visibility.Visible)
                    {
                        stringBuilder.AppendLine(item.fileFullPath);
                    }
                }
                ClipboardService.SetText(stringBuilder.ToString());
            }
        }
        else
        {
            ThrowEx.NotImplementedCase(obj);
        }
    }
    /// <summary>
    /// A1 is used to trim when start with them
    /// </summary>
    /// <param name="basePath"></param>
    public void Init(params string[] basePath)
    {
        if (tbNoResultsFound != null)
        {
            tbNoResultsFound.Text = Translate.FromKey(XlfKeys.NoResultsFound);
        }
        basePaths = basePath.ToList();
        SunamoComparerICompare.StringLength.Desc comparer = new SunamoComparerICompare.StringLength.Desc(SunamoComparer.StringLength.Instance);
        basePaths.Sort(comparer);
        CA.WithEndSlash(basePaths);
    }
    public TUListWpf<string, Brush> DefaultBrushes(string green = "", string red = "")
    {
        TUListWpf<string, Brush> result = new TUListWpf<string, Brush>();
        result.Add(TUWpf<string, Brush>.Get(green, Brushes.Green));
        result.Add(TUWpf<string, Brush>.Get(red, Brushes.Red));
        return result;
    }
    protected void HideTbNoResultsFound()
    {
        if (sv != null && tbNoResultsFound != null)
        {
            tbNoResultsFound.Visibility = Visibility.Collapsed;
            sv.Visibility = Visibility.Visible;
        }
    }
    public void AddFoundedResults(bool clear, TUListWpf<string, Brush> colors, List<TWithNameTWpf<string>> foundedResult)
    {
        if (sp != null && sv != null)
        {
            int index = 1;
            if (clear)
            {
                ClearFoundedResult();
            }
            if (foundedResult.Count > 0)
            {
                HideTbNoResultsFound();
                sv.Visibility = Visibility.Visible;
            }
            foreach (var item in foundedResult)
            {
                FoundedResultUC resultControl = new FoundedResultUC(item.name, colors, index++);
                resultControl.Selected += OnSelected;
                TextBlock textBlock = TextBlockHelper.Get(new ControlInitData { text = item.t });
                resultControl.SecondRow = textBlock;
                sp.Children.Add(resultControl);
            }
        }
    }
    /// <summary>
    ///  Can be use only getting, not for removing due to from lb wont be removed
    /// </summary>
    public List<FoundedFileUC> Items
    {
        get
        {
            List<FoundedFileUC> founded = new List<FoundedFileUC>(sp != null ? 0 : sp.Children.Count);
            if (sp != null)
            {
                foreach (FoundedFileUC item in sp.Children)
                {
                    founded.Add(item);
                }
            }
            return founded;
        }
    }
    public FoundedFileUC GetFoundedFileByPath(string path)
    {
        if (sp != null)
        {
            foreach (FoundedFileUC item in sp.Children)
            {
                if (item.fileFullPath == path)
                {
                    return (FoundedFileUC)item;
                }
            }
        }
        return null;
    }
    public void SelectFile(string file)
    {
        Selected(file);
    }
    public void ClearFoundedResult()
    {
        if (sp != null && sv != null && tbNoResultsFound != null)
        {
            sp.Children.Clear();
            sv.Visibility = Visibility.Collapsed;
            tbNoResultsFound.Visibility = Visibility.Visible;
        }
    }
    public void OnSelected(string path)
    {
        Selected(path);
    }
    /// <summary>
    /// return null if there is no element
    /// </summary>
    public string PathOfFirstFile()
    {
        #region TODO: fixing Everyline not searching
        if (Items.Count != 0)
        {
            return Items[0].tbFileName2.Text;
        }
        #endregion
        return null;
    }
    #endregion
}
