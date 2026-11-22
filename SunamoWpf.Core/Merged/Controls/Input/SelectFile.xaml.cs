#define ASYNC
namespace SunamoWpf.Controls;

public partial class SelectFile : UserControl
{
    /// <summary>
    /// In folder has hame Folder*Changed* but there already exists FileSelected
    /// </summary>
    public event VoidString FileSelected;
    /// <summary>
    /// The file removed.
    /// </summary>
    public event VoidT<SelectFile> FileRemoved;

    /// <summary>
    /// Initializes a new instance of the select file class.
    /// </summary>
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

        btnSelectFile.Content = "SelectFile";

        Loaded += SelectFile_Loaded;
    }

    private void SelectFile_Loaded(object sender, RoutedEventArgs eventArgs)
    {
        SetAwesomeIcons(); // async Task nelze RunSynchronously (InvalidOperationException); ikony se nastavi pres Dispatcher.InvokeAsync
    }

    private void BtnRemoveFile_Click(object sender, RoutedEventArgs eventArgs)
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

    private void SetSelectedFile(string path)
    {
        if (path == "")
        {
            path = "None";
        }
        selectedFile = path;
        tbSelectedFile.Text = "SelectedFile" + ": " + path;
    }

    private void btnSelectFile_Click(object sender, RoutedEventArgs eventArgs)
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

    /// <summary>
    /// The selected file.
    /// </summary>
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


    /// <summary>
    /// The type.
    /// </summary>
    public static Type type = typeof(SelectFile);
    /// <summary>
    /// Validate.
    /// </summary>
    /// <param name="tbNewPath">The tb new path.</param>
    /// <param name="validateData">The validate data.</param>
    public void Validate(/*object tbNewPath,*/ ref ValidateDataWpf validateData)
    {
        if (validateData == null)
        {
            validateData = new ValidateDataWpf();
        }
        string SelectedFile = RH.GetValueOfPropertyOrField(this, "SelectedFile").ToString();
        validated = FS.ExistsFile(SelectedFile);
        if (!validated)
        {
            //InitApp.TemplateLogger.FileDontExists(SelectedFile);
        }
    }
    /// <summary>
    /// The validated.
    /// </summary>
    public static bool validated
    {
        get => ValidationHelper.validated;
        set => ValidationHelper.validated = value;
    }
}
