namespace SunamoWpf.SunamoDebugging;

/// <summary>
/// Slouží k tomu když nechci používat plné FoundedFilesUC abych zároveň mohl vybírat soubory
/// </summary>
/// <typeparam name="SearchInUC"></typeparam>
public class FoundedFilesD<SearchInUC> //: IFoundedFilesUCCombine<SearchInUC>
{
    /// <summary>
    /// Gets or sets the txt filter.
    /// </summary>
    public SearchInUC txtFilter { get; set; }

    /// <summary>
    /// Gets the items.
    /// </summary>
    public List<IFoundedFileUC> Items => new List<IFoundedFileUC>();

    /// <summary>
    /// Gets the selected item.
    /// </summary>
    public string SelectedItem => null;

    /// <summary>
    /// The selected.
    /// </summary>
    public event VoidString Selected;


    //public void AddFoundedFile(string item, TUListWpf<string, Brush> p, ref int i)
    //{

    //}

    //public void AddFoundedFiles(List<string> foundedList, TUListWpf<string, Brush> p)
    //{

    //}

    //public void AddFoundedResults(bool clear, TUListWpf<string, Brush> p, List<TWithNameTWpf<string>> foundedResult)
    //{

    //}

    /// <summary>
    /// Clear founded result.
    /// </summary>
    public void ClearFoundedResult()
    {

    }

    /// <summary>
    /// Default brushes.
    /// </summary>
    /// <param name="green">The green.</param>
    /// <param name="red">The red.</param>
    /// <returns>The default brushes result.</returns>
    public TUListWpf<string, Brush> DefaultBrushes(/*string green = "", string red = ""*/)
    {
        return new TUListWpf<string, Brush>();
    }

    //public bool? Filter(string text)
    //{
    //    return false;
    //}

    /// <summary>
    /// Founded file selected.
    /// </summary>
    /// <param name="path">The path.</param>
    public void FoundedFile_Selected(string path)
    {
        if (Selected != null)
        {
            Selected(path);
        }
    }



    /// <summary>
    /// Initialize component.
    /// </summary>
    public void InitializeComponent()
    {

    }

    //public void OnSelected(string p)
    //{

    //}

    //public string PathOfFirstFile()
    //{
    //    return null;
    //}

    //public void SelectFile(string file)
    //{

    //}

    //public IFoundedFileUC GetFoundedFileByPath(string path)
    //{
    //    return null;
    //}

    //public void Init(params string[] basePath)
    //{

    //}
}