#define ASYNC
namespace SunamoWpf.Controls;

public partial class SelectFile : UserControl
{
    /// <summary>
    /// In folder has hame Folder*Changed* but there already exists FileSelected
    /// </summary>
    public event VoidString FileSelected;
    public event VoidT<SelectFile> FileRemoved;

    public SelectFile()
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
        SelectedFile = "";

        btnSelectFile.Content = Translate.FromKey(XlfKeys.SelectFile);

        Loaded += SelectFile_Loaded;
    }

    private void SelectFile_Loaded(object sender, RoutedEventArgs e)
    {
        SetAwesomeIcons(); // async Task nelze RunSynchronously (InvalidOperationException); ikony se nastavi pres Dispatcher.InvokeAsync
    }

    private void BtnRemoveFile_Click(object sender, RoutedEventArgs e)
    {
        if (FileRemoved != null)
        {
            FileRemoved(this);
        }
    }

    async Task SetAwesomeIcons()
    {
        await AwesomeFontControls.SetAwesomeFontSymbol(btnRemoveFile, "\uf00d");
    }

    private void OnFileChanged(string File)
    {
        if (FileSelected != null)
        {
            FileSelected(File);
        }
    }

    string selectedFile;

    private void SetSelectedFile(string v)
    {
        if (v == "")
        {
            v = Translate.FromKey(XlfKeys.None);
        }
        selectedFile = v;
        tbSelectedFile.Text = Translate.FromKey(XlfKeys.SelectedFile) + ": " + v;
    }

    private void btnSelectFile_Click(object sender, RoutedEventArgs e)
    {
        string file = DW.SelectOfFile();
        if (file != null)
        {
            if (FS.ExistsFile(file))
            {
                SelectedFile = file;
                FileSelected(file);
            }
        }
    }

    public string SelectedFile
    {
        get
        {
            return selectedFile;
        }
        set
        {
            OnFileChanged(value);
            SetSelectedFile(value);
        }
    }


    public static Type type = typeof(SelectFile);
    public void Validate(/*object tbNewPath,*/ ref ValidateDataWpf d)
    {
        if (d == null)
        {
            d = new ValidateDataWpf();
        }
        string SelectedFile = RH.GetValueOfPropertyOrField(this, "SelectedFile").ToString();
        validated = FS.ExistsFile(SelectedFile);
        if (!validated)
        {
            //InitApp.TemplateLogger.FileDontExists(SelectedFile);
        }
    }
    public static bool validated
    {
        get => ValidationHelper.validated;
        set => ValidationHelper.validated = value;
    }
}
