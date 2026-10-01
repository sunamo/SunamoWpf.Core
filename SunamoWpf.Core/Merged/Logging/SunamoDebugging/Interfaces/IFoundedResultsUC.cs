namespace SunamoWpf.SunamoDebugging.Interfaces;

public interface IFoundedResultsUC<FoundedFileUC>
{
    List<FoundedFileUC> Items { get; }
    string SelectedItem { get; }

    event VoidString Selected;
    void AddFoundedResults(bool clear, TUListWpf<string, Brush> p, List<TWithNameTWpf<string>> foundedResult);
    void ClearFoundedResult();
    TUListWpf<string, Brush> DefaultBrushes(string green = "", string red = "");
    FoundedFileUC GetFoundedFileByPath(string path);
    void Init(params string[] basePath);
    // Musí to tu být?
    //void InitializeComponent();
    void OnSelected(string p);
    string PathOfFirstFile();
    void SelectFile(string file);
}