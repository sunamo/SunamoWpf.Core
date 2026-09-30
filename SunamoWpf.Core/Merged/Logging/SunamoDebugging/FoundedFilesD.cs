namespace SunamoWpf.SunamoDebugging;

/// <summary>
/// Slouží k tomu když nechci používat plné FoundedFilesUC abych zároveň mohl vybírat soubory
/// </summary>
/// <typeparam name="SearchInUC"></typeparam>
public class FoundedFilesD<SearchInUC> //: IFoundedFilesUCCombine<SearchInUC>
{
    public SearchInUC txtFilter { get; set; }

    public List<IFoundedFileUC> Items => new List<IFoundedFileUC>();

    public string SelectedItem => null;

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

    public void ClearFoundedResult()
    {

    }

    public TUListWpf<string, Brush> DefaultBrushes(/*string green = "", string red = ""*/)
    {
        return new TUListWpf<string, Brush>();
    }

    //public bool? Filter(string text)
    //{
    //    return false;
    //}

    public void FoundedFile_Selected(string s)
    {
        if (Selected != null)
        {
            Selected(s);
        }
    }



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