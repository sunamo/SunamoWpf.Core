namespace SunamoWpf.Args;

public class WindowWithUserControlArgs
{
    public object iUserControlInWindow;
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
    public string hint = null;
    public bool showInTitleSizeOfWindowAndContent = false;
    public Size sizeWindow; 
}