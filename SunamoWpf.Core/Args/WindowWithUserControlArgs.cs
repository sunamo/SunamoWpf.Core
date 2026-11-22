namespace SunamoWpf.Args;

/// <summary>
/// Represents the window with user control args type.
/// </summary>
public class WindowWithUserControlArgs
{
    /// <summary>
    /// The i user control in window.
    /// </summary>
    public object iUserControlInWindow;
    /// <summary>
    /// The rm.
    /// </summary>
    public ResizeMode rm = ResizeMode.CanResize;
    /// <summary>
    /// Whether use base.DialogResult instead of calling ChangeDialogResult
    /// </summary>
    public bool useResultOfShowDialog = false;
    /// <summary>
    /// only when uc dont have own button!
    /// </summary>
    public bool addDialogButtons = false;
    /// <summary>
    /// Tag which is set to WindowWithUserControl
    /// </summary>
    public string tag = null;
    /// <summary>
    /// The hint.
    /// </summary>
    public string hint = null;
    /// <summary>
    /// The show in title size of window and content.
    /// </summary>
    public bool showInTitleSizeOfWindowAndContent = false;
    /// <summary>
    /// The size window.
    /// </summary>
    public Size sizeWindow; 
}