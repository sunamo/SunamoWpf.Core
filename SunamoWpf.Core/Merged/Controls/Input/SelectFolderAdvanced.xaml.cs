#define ASYNC
namespace SunamoWpf.Controls;

public partial class SelectFolderAdvanced : UserControl, IControlWithResultWpf
{
    /// <summary>
    /// The dialog result.
    /// </summary>
    public bool? DialogResult
    {
        set
        {
            ChangeDialogResult(value);
        }
    }
    /// <summary>
    /// Focus on main element.
    /// </summary>
    public void FocusOnMainElement()
    {
        selectFolder.Focus();
    }
    /// <summary>
    /// Initializes a new instance of the select folder advanced class.
    /// </summary>
    public SelectFolderAdvanced()
    {
        try
        {
            InitializeComponent();
        }
        catch (Exception)
        {
#if DEBUG
            Debugger.Break();
#endif
        }
    }
    /// <summary>
    /// The change dialog result.
    /// </summary>
    public event VoidBoolNullable ChangeDialogResult;
    /// <summary>
    /// The chb dont ask again.
    /// </summary>
    public CheckBox chbDontAskAgain
    {
        get
        {
            return FrameworkElementHelper.FindByTag<CheckBox>(cDialogButtons.CustomControl, "chbDontAskAgain");
        }
    }
    /// <summary>
    /// The txt masc.
    /// </summary>
    public TextBox txtMasc
    {
        get
        {
            return FrameworkElementHelper.FindByTag<TextBox>(cDialogButtons.CustomControl, "txtMasc");
        }
    }
    /// <summary>
    /// The chb files from subfolders.
    /// </summary>
    public CheckBox chbFilesFromSubfolders
    {
        get
        {
            return FrameworkElementHelper.FindByTag<CheckBox>(cDialogButtons.CustomControl, "chbFilesFromSubfolders");
        }
    }
    /// <summary>
    /// The selected folder.
    /// </summary>
    public string SelectedFolder
    {
        get
        {
            return selectFolder.SelectedFolder;
        }
        set
        {
            selectFolder.SelectedFolder = value;
            selectFolder_FolderChanged(value);
        }
    }
    CheckBox GetChbDontAskAgain()
    {
        return ((CheckBox)cDialogButtons.CustomControl);
    }
    /// <summary>
    /// The dont ask again.
    /// </summary>
    public bool DontAskAgain
    {
        get
        {
            return GetChbDontAskAgain().IsChecked.Value;
        }
    }
    /// <summary>
    /// The visibility btn apply.
    /// </summary>
    public Visibility VisibilityBtnApply
    {
        set
        {
            cDialogButtons.btnApply.Visibility = value;
        }
    }
    /// <summary>
    /// The visibility chb dont ask again.
    /// </summary>
    public Visibility VisibilityChbDontAskAgain
    {
        set
        {
            GetChbDontAskAgain().Visibility = value;
        }
    }
    private void selectFolder_FolderChanged(string folder)
    {
        if (FS.ExistsDirectory(folder))
        {
            cDialogButtons.btnOk.IsEnabled = true;
        }
        else
        {
            cDialogButtons.btnOk.IsEnabled = false;
        }
    }
    private void cDialogButtons_ChangeDialogResult(bool? result)
    {
        DialogResult = result;
    }
    /// <summary>
    /// A1 = string, cant be null
    /// </summary>
    /// <param name="input"></param>
    public void Accept(object input)
    {
        selectFolder.SelectedFolder = input.ToString();
        ChangeDialogResult(true);
        // Cant be, window must be already showned as dialog
        //DialogResult = true;
    }
}
