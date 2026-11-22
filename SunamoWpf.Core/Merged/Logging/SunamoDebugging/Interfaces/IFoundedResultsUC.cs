namespace SunamoWpf.SunamoDebugging.Interfaces;

/// <summary>
/// Represents the i founded results UC founded file UC type.
/// </summary>
public interface IFoundedResultsUC<FoundedFileUC>
{
    /// <summary>
    /// Gets the items.
    /// </summary>
    List<FoundedFileUC> Items { get; }
    /// <summary>
    /// Gets the selected item.
    /// </summary>
    string SelectedItem { get; }

    /// <summary>
    /// The selected.
    /// </summary>
    event VoidString Selected;
    /// <summary>
    /// Add founded results.
    /// </summary>
    /// <param name="clear">The clear.</param>
    /// <param name="colors">The colors.</param>
    /// <param name="foundedResult">The founded result.</param>
    void AddFoundedResults(bool clear, TUListWpf<string, Brush> colors, List<TWithNameTWpf<string>> foundedResult);
    /// <summary>
    /// Clear founded result.
    /// </summary>
    void ClearFoundedResult();
    /// <summary>
    /// Default brushes.
    /// </summary>
    /// <param name="green">The green.</param>
    /// <param name="red">The red.</param>
    /// <returns>The default brushes result.</returns>
    TUListWpf<string, Brush> DefaultBrushes(string green = "", string red = "");
    /// <summary>
    /// Get founded file by path.
    /// </summary>
    /// <param name="path">The path.</param>
    /// <returns>The get founded file by path result.</returns>
    FoundedFileUC GetFoundedFileByPath(string path);
    /// <summary>
    /// Init.
    /// </summary>
    /// <param name="basePath">The base path.</param>
    void Init(params string[] basePath);
    // Musí to tu být?
    //void InitializeComponent();
    /// <summary>
    /// On selected.
    /// </summary>
    /// <param name="path">The path.</param>
    void OnSelected(string path);
    /// <summary>
    /// Path of first file.
    /// </summary>
    /// <returns>The path of first file result.</returns>
    string PathOfFirstFile();
    /// <summary>
    /// Select file.
    /// </summary>
    /// <param name="file">The file.</param>
    void SelectFile(string file);
}