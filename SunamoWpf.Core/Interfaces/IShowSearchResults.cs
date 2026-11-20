namespace SunamoWpf.Interfaces;

/// <summary>
/// Can use global variable TextBoxState as is in TextBoxBackend
/// </summary>
public interface IShowSearchResults
{
    /// <summary>
    /// Set tb searched result.
    /// </summary>
    /// <param name="actual">The actual.</param>
    /// <param name="count">The count.</param>
    void SetTbSearchedResult(int actual, int count);
    /// <summary>
    /// Set text box state.
    /// </summary>
    /// <param name="text">The text.</param>
    void SetTextBoxState(string text = null);
}