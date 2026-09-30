#define ASYNC
namespace SunamoWpf.Controls.Result;

public partial class FoundedFilesResults : UserControl /*, IFoundedFilesUC<FoundedFileUC>, IFoundedResultsUC<FoundedFileUC>*/, ISelectedTWpf<string>
{
    #region FoundedFilesUC
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
    #endregion
    #region FoundedResultsUC
    public static Type type = typeof(FoundedResultsUC);
    public event VoidString Selected;
    protected string selectedItem = null;
    public string SelectedItem => selectedItem;
    public static List<string> basePaths = CA.ToListString();
    //public SearchInUC txtFilter = null;
    //public StackPanel sp = null;
    //public ScrollViewer sv = null;
    //public TextBlock tbNoResultsFound = null;
    public FoundedFilesResults()
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
        //Loaded += FoundedFilesUC_Loaded;
        //SizeChanged += FoundedFilesUC_SizeChanged;
        Loaded += FoundedResultsUC_Loaded;
        SizeChanged += FoundedResultsUC_SizeChanged;
    }
    private void FoundedResultsUC_SizeChanged(object sender, SizeChangedEventArgs e)
    {
#if DEBUG
        //FrameworkElementDebug.ActualSize(this);
        //FrameworkElementDebug.ActualSize(sv);
        //FrameworkElementDebug.ActualSize(sp);
#endif
    }
    private void FoundedResultsUC_Loaded(object sender, RoutedEventArgs e)
    {
    }
    //private void FoundedResultViewModel_Do(FoundedResultActions obj)
    //{
    //    if (obj == FoundedResultActions.CopyToClipboardFounded)
    //    {
    //        if (sp != null)
    //        {
    //            StringBuilder sb = new StringBuilder();
    //            foreach (FoundedFileUC item in sp.Children)
    //            {
    //                if (item.Visibility == Visibility.Visible)
    //                {
    //                    sb.AppendLine(item.fileFullPath);
    //                }
    //            }
    //            ClipboardService.SetText(sb.ToString());
    //        }
    //    }
    //    else
    //    {
    //        ThrowEx.NotImplementedCase(obj);
    //    }
    //}
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
        SunamoComparerICompare.StringLength.Desc s = new SunamoComparerICompare.StringLength.Desc(SunamoComparer.StringLength.Instance);
        basePaths.Sort(s);
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
    public void AddFoundedResults(bool clear, TUListWpf<string, Brush> p, List<TWithNameTWpf<string>> foundedResult)
    {
        if (sp != null && sv != null)
        {
            int i = 1;
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
                FoundedResultUC fr = new FoundedResultUC(item.name, p, i++);
                fr.Selected += OnSelected;
                TextBlock tb = TextBlockHelper.Get(new ControlInitData { text = item.t });
                fr.SecondRow = tb;
                sp.Children.Add(fr);
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
    public void OnSelected(string p)
    {
        Selected(p);
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
