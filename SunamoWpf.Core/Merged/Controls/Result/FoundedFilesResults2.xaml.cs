#define ASYNC
namespace SunamoWpf.Controls.Result;

public partial class FoundedFilesResults2 : UserControl//, IFoundedFilesUC<FoundedFileUC>, IFoundedResultsUC<IFoundedFileUC>, ISelectedT<string>
{
    /// <summary>
    /// The base paths.
    /// </summary>
    public static List<string> basePaths = CA.ToListString();
    List<FoundedResultDataWrapper> d = new List<FoundedResultDataWrapper>();
    /// <summary>
    /// Gets the selected item.
    /// </summary>
    public string SelectedItem => selectedItem;
    /// <summary>
    /// The selected item.
    /// </summary>
    protected string selectedItem = null;
    /// <summary>
    /// The items.
    /// </summary>
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
    /// <summary>
    /// Initializes a new instance of the founded files results 2 class.
    /// </summary>
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
    /// <summary>
    /// The selected.
    /// </summary>
    public event VoidString Selected;
    /// <summary>
    /// Add founded file.
    /// </summary>
    /// <param name="item">The item.</param>
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
    /// <summary>
    /// Add founded files.
    /// </summary>
    /// <param name="foundedList">The founded list.</param>
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
    /// <summary>
    /// Clear founded result.
    /// </summary>
    public void ClearFoundedResult()
    {
        d.Clear();
    }
    /// <summary>
    /// Default brushes.
    /// </summary>
    /// <param name="green">The green.</param>
    /// <param name="red">The red.</param>
    /// <returns>The default brushes result.</returns>
    public TUListWpf<string, Brush> DefaultBrushes(string green = "", string red = "")
    {
        TUListWpf<string, Brush> result = new TUListWpf<string, Brush>();
        result.Add(TUWpf<string, Brush>.Get(green, Brushes.Green));
        result.Add(TUWpf<string, Brush>.Get(red, Brushes.Red));
        return result;
    }
    /// <summary>
    /// Filter.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <returns>The filter result.</returns>
    public bool? Filter(string text)
    {
        bool cancel = string.IsNullOrWhiteSpace(text);
        return cancel;
    }
    /// <summary>
    /// Founded file selected.
    /// </summary>
    /// <param name="path">The path.</param>
    public void FoundedFile_Selected(string path)
    {
        selectedItem = path;
        OnSelected(path);
    }
    /// <summary>
    /// Get founded file by path.
    /// </summary>
    /// <param name="path">The path.</param>
    /// <returns>The get founded file by path result.</returns>
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
    /// <summary>
    /// Init.
    /// </summary>
    /// <param name="basePath">The base path.</param>
    public void Init(params string[] basePath)
    {
        if (tbNoResultsFound != null)
        {
            tbNoResultsFound.Text = "NoResultsFound";
        }
        basePaths = basePath.ToList();
        SunamoComparerICompare.StringLength.Desc comparer = new SunamoComparerICompare.StringLength.Desc(SunamoComparer.StringLength.Instance);
        basePaths.Sort(comparer);
        CA.WithEndSlash(basePaths);
    }
    /// <summary>
    /// On selected.
    /// </summary>
    /// <param name="path">The path.</param>
    public void OnSelected(string path)
    {
        Selected(path);
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
    /// <summary>
    /// Select file.
    /// </summary>
    /// <param name="file">The file.</param>
    public void SelectFile(string file)
    {
        Selected(file);
    }
    private void FoundedFilesResults2_Loaded(object sender, RoutedEventArgs eventArgs)
    {
    }
}
