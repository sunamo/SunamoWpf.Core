namespace SunamoWpf.Interfaces;

/// <summary>
/// Can use global variable TextBoxState as is in TextBoxBackend
/// </summary>
public interface IShowSearchResults
{
    void SetTbSearchedResult(int actual, int count);
    void SetTextBoxState(string s = null);
}