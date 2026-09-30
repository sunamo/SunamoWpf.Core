#define ASYNC
namespace SunamoWpf.Controls.Result;

public partial class FoundedFilesResults2 : UserControl//, IFoundedFilesUC<FoundedFileUC>, IFoundedResultsUC<IFoundedFileUC>, ISelectedT<string>
{
    public static List<string> basePaths = CA.ToListString();
    List<FoundedResultDataWrapper> d = new List<FoundedResultDataWrapper>();
    public string SelectedItem => selectedItem;
    protected string selectedItem = null;
    public List<IFoundedFileUC> Items
    {
        get
        {
            List<IFoundedFileUC> founded = new List<IFoundedFileUC>(d.Count);
            foreach (IFoundedFileUC item in d)
            {
                founded.Add(item);
            }
            return founded;
        }
    }
    public FoundedFilesResults2()
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
        Loaded += FoundedFilesResults2_Loaded;
    }
    public event VoidString Selected;
    public void AddFoundedFile(string item)
    {
        HideTbNoResultsFound();
        FoundedResultDataWrapper foundedFile = new FoundedResultDataWrapper(item);
        //foundedFile.Selected += FoundedFile_Selected;
        d.Add(foundedFile);
    }
    private void HideTbNoResultsFound()
    {
        tbNoResultsFound.Visibility = Visibility.Collapsed;
    }
    public void AddFoundedFiles(List<string> foundedList)
    {
        HideTbNoResultsFound();
        foreach (var item in foundedList)
        {
            AddFoundedFile(item);
        }
    }
    /// <summary>
    /// Vypadá to že se to nikde nevolá takže zatím to zakomentuji
    /// </summary>
    /// <param name="clear"></param>
    /// <param name="p"></param>
    /// <param name="foundedResult"></param>
    //public void AddFoundedResults(bool clear, TUListWpf<string, Brush> p, List<TWithNameTWpf<string>> foundedResult)
    //{
    //    ThrowEx.NotImplementedMethod();
    //    //int i = 1;
    //    //if (clear)
    //    //{
    //    //    ClearFoundedResult();
    //    //}
    //    //if (foundedResult.Count > 0)
    //    //{
    //    //    HideTbNoResultsFound();
    //    //    lv.Visibility = Visibility.Visible;
    //    //}
    //    //foreach (var item in foundedResult)
    //    //{
    //    //    d.Add(new FoundedResultDataWrapper(item.))
    //    //    //FoundedResultUC fr = new FoundedResultUC(item.name, p, i++);
    //    //    //fr.Selected += OnSelected;
    //    //    //TextBlock tb = TextBlockHelper.Get(new ControlInitData { text = item.t });
    //    //    //fr.SecondRow = tb;
    //    //    //sp.Children.Add(fr);
    //    //}
    //}
    public void AttachSelected(VoidString act)
    {
        Selected += act;
    }
    public void ClearFoundedResult()
    {
        d.Clear();
    }
    public TUListWpf<string, Brush> DefaultBrushes(string green = "", string red = "")
    {
        TUListWpf<string, Brush> result = new TUListWpf<string, Brush>();
        result.Add(TUWpf<string, Brush>.Get(green, Brushes.Green));
        result.Add(TUWpf<string, Brush>.Get(red, Brushes.Red));
        return result;
    }
    public bool? Filter(string text)
    {
        bool cancel = string.IsNullOrWhiteSpace(text);
        return cancel;
    }
    public void FoundedFile_Selected(string s)
    {
        selectedItem = s;
        OnSelected(s);
    }
    public IFoundedFileUC GetFoundedFileByPath(string path)
    {
        foreach (var item in d)
        {
            if (item.Frd.fileFullPath == path)
            {
                return (IFoundedFileUC)item;
            }
        }
        return null;
    }
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
    public void OnSelected(string p)
    {
        Selected(p);
    }
    /// <summary>
    /// NSN
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public string PathOfFirstFile()
    {
        throw new NotImplementedException();
    }
    public void SelectFile(string file)
    {
        Selected(file);
    }
    private void FoundedFilesResults2_Loaded(object sender, RoutedEventArgs e)
    {
    }
}
