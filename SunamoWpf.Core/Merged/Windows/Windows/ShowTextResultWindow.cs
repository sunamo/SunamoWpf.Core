#define ASYNC
namespace SunamoWpf.Windows;

/// <summary>
/// Represents the show text result window type.
/// </summary>
public class ShowTextResultWindow : Window, IControlWithResultWpf
{
    ShowTextResult s = null;

    /// <summary>
    /// Initializes a new instance of the show text result window class.
    /// </summary>
    /// <param name="text">The text.</param>
    public ShowTextResultWindow(string text)
    {
        s = new ShowTextResult(text);
        Content = s;
        s.ChangeDialogResult += S_ChangeDialogResult;
    }

    /// <summary>
    /// The change dialog result.
    /// </summary>
    public event VoidBoolNullable ChangeDialogResult;

    /// <summary>
    /// Accept.
    /// </summary>
    /// <param name="input">The input.</param>
    public void Accept(object input)
    {
        
    }

    /// <summary>
    /// Focus on main element.
    /// </summary>
    public void FocusOnMainElement()
    {
        s.Focus();
    }

    private void S_ChangeDialogResult(bool? result)
    {
        // It's window, not user control, therefore I have to close, not calling ChangeDialogResult
        Close();
    }
}