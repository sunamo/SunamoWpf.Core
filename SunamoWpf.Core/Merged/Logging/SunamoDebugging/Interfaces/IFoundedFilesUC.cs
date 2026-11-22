namespace SunamoWpf.SunamoDebugging.Interfaces;

/// <summary>
/// Represents the i founded files UC combine search in UC type.
/// </summary>
public interface IFoundedFilesUCCombine<SearchInUC> : IFoundedFilesUCXaml<SearchInUC>, IFoundedResultsUC<IFoundedFileUC>, ISelectedTWpf<string>
{

}

/// <summary>
/// Represents the i founded files UC xaml search in UC type.
/// </summary>
public interface IFoundedFilesUCXaml<SearchInUC> : IFoundedFilesUC<SearchInUC>
{
    /// <summary>
    /// Gets or sets the txt filter.
    /// </summary>
    SearchInUC txtFilter { get; set; }
}

/// <summary>
/// nemůžu dědit přímo z IFoundedResultsUC protože jak bych poté FoundedFilesUC dědil z tohoto kombinovaného rozhraní, musel bych implementovat metody jež jsou už v FoundedResultsUC
/// </summary>
/// <typeparam name="SearchInUC"></typeparam>
public interface IFoundedFilesUC<SearchInUC> : IFoundedResultsUC<IFoundedFileUC>, ISelectedTWpf<string>
{
    //event VoidString Selected;
    /// <summary>
    /// Add founded file.
    /// </summary>
    /// <param name="item">The item.</param>
    /// <param name="colors">The colors.</param>
    /// <param name="index">The index.</param>
    void AddFoundedFile(string item, TUListWpf<string, Brush> colors, ref int index);
    /// <summary>
    /// Add founded files.
    /// </summary>
    /// <param name="foundedList">The founded list.</param>
    /// <param name="colors">The colors.</param>
    void AddFoundedFiles(List<string> foundedList, TUListWpf<string, Brush> colors);
    /// <summary>
    /// Filter.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <returns>The filter result.</returns>
    bool? Filter(string text);
    /// <summary>
    /// Founded file selected.
    /// </summary>
    /// <param name="path">The path.</param>
    void FoundedFile_Selected(string path);
    /// <summary>
    /// Attach selected.
    /// </summary>
    /// <param name="act">The act.</param>
    void AttachSelected(VoidString act);
}