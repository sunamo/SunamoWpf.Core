#define ASYNC
namespace SunamoWpf.Controls;

public partial class SelectFolderAdvanced : UserControl, IControlWithResultWpf
{
    public bool? DialogResult
    {
        set
        {
            ChangeDialogResult(value);
        }
    }
    public void FocusOnMainElement()
    {
        selectFolder.Focus();
    }
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
    public event VoidBoolNullable ChangeDialogResult;
    public CheckBox chbDontAskAgain
    {
        get
        {
            return FrameworkElementHelper.FindByTag<CheckBox>(cDialogButtons.CustomControl, "chbDontAskAgain");
        }
    }
    public TextBox txtMasc
    {
        get
        {
            return FrameworkElementHelper.FindByTag<TextBox>(cDialogButtons.CustomControl, "txtMasc");
        }
    }
    public CheckBox chbFilesFromSubfolders
    {
        get
        {
            return FrameworkElementHelper.FindByTag<CheckBox>(cDialogButtons.CustomControl, "chbFilesFromSubfolders");
        }
    }
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
    public bool DontAskAgain
    {
        get
        {
            return GetChbDontAskAgain().IsChecked.Value;
        }
    }
    public Visibility VisibilityBtnApply
    {
        set
        {
            cDialogButtons.btnApply.Visibility = value;
        }
    }
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
