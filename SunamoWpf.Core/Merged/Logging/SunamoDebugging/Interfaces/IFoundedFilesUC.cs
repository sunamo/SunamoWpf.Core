namespace SunamoWpf.SunamoDebugging.Interfaces;

public interface IFoundedFilesUCCombine<SearchInUC> : IFoundedFilesUCXaml<SearchInUC>, IFoundedResultsUC<IFoundedFileUC>, ISelectedTWpf<string>
{

}

public interface IFoundedFilesUCXaml<SearchInUC> : IFoundedFilesUC<SearchInUC>
{
    SearchInUC txtFilter { get; set; }
}

/// <summary>
/// nemůžu dědit přímo z IFoundedResultsUC protože jak bych poté FoundedFilesUC dědil z tohoto kombinovaného rozhraní, musel bych implementovat metody jež jsou už v FoundedResultsUC
/// </summary>
/// <typeparam name="SearchInUC"></typeparam>
public interface IFoundedFilesUC<SearchInUC> : IFoundedResultsUC<IFoundedFileUC>, ISelectedTWpf<string>
{
    //event VoidString Selected;
    void AddFoundedFile(string item, TUListWpf<string, Brush> p, ref int i);
    void AddFoundedFiles(List<string> foundedList, TUListWpf<string, Brush> p);
    bool? Filter(string text);
    void FoundedFile_Selected(string s);
    void AttachSelected(VoidString act);
}