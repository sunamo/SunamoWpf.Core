#define ASYNC
// SunamoWpfControlsInput
namespace SunamoWpf.Controls.Input;

public partial class SelectManyFiles : UserControl
{
    /// <summary>
    /// The type.
    /// </summary>
    public static Type type = typeof(SelectManyFiles);

    /// <summary>
    /// Validate.
    /// </summary>
    /// <param name="validateData">The validate data.</param>
    public void Validate(ref ValidateDataWpf validateData)
    {
        if (validateData == null)
        {
            validateData = new ValidateDataWpf();
        }
        foreach (SelectFile item in ControlFinder.StackPanel(this, "spFiles").Children)
        {
            item.Validate(ref validateData);
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

    /// <summary>
    /// Initializes a new instance of the select many files class.
    /// </summary>
    public SelectManyFiles()
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

        Loaded += SelectMoreFiles_Loaded;
    }

    /// <summary>
    /// The save set as template.
    /// </summary>
    public event Action SaveSetAsTemplate;
    /// <summary>
    /// Only adding File with empty path
    /// </summary>
    public event Action<object, List<string>> FileAdded;
    /// <summary>
    /// The file changed.
    /// </summary>
    public event Action<object, List<string>> FileChanged;
    /// <summary>
    /// The file removed.
    /// </summary>
    public event Action<object, List<string>> FileRemoved;

    private void SelectMoreFiles_Loaded(object sender, RoutedEventArgs eventArgs)
    {
        SetAwesomeIcons(); // async Task nelze RunSynchronously (InvalidOperationException); ikony se nastavi pres Dispatcher.InvokeAsync

        AddFile(string.Empty);
    }

    /// <summary>
    /// Add file.
    /// </summary>
    /// <param name="File">The file.</param>
    public void AddFile(string File)
    {
        //TextBox sf = new TextBox();
        //sf.Text = File;

        SelectFile selectFile = new SelectFile();
        selectFile.SelectedFile = File;
        selectFile.btnRemoveFile.Visibility = Visibility.Visible;
        selectFile.FileRemoved += Sf_FileRemoved;
        selectFile.FileSelected += Sf_FileChanged;

        spFiles.Children.Add(selectFile);
        if (FileAdded != null)
        {
            FileAdded(this, SelectedFiles());
        }
        // Must be called after sf is on panel and has registered Sf_FileChanged, because control for FileChanged != null
        Sf_FileChanged(File);
    }

    private void Sf_FileChanged(string path)
    {
        if (FileChanged != null)
        {
            FileChanged(this, SelectedFiles());
        }
    }

    /// <summary>
    /// Sf file removed.
    /// </summary>
    /// <param name="selectFile">The select file.</param>
    public void Sf_FileRemoved(SelectFile selectFile)
    {
        spFiles.Children.Remove(selectFile);
        if (FileRemoved != null)
        {
            FileRemoved(this, SelectedFiles());
        }
    }

    async Task SetAwesomeIcons()
    {
        await AwesomeFontControls.SetAwesomeFontSymbol(btnAddFile, "\uf07c " + "New");
        await AwesomeFontControls.SetAwesomeFontSymbol(btnAddAsTemplate, "\uf022 Save set as template");
    }

    private void BtnAddFile_Click(object sender, RoutedEventArgs eventArgs)
    {
        AddFile(string.Empty);
    }





    /// <summary>
    /// Remove all files.
    /// </summary>
    public void RemoveAllFiles()
    {
        for (int index = spFiles.Children.Count - 1; index >= 0; index--)
        {
            Sf_FileRemoved((SelectFile)spFiles.Children[index]);
        }
    }

    /// <summary>
    /// Validate before call
    /// </summary>
    public List<string> SelectedFiles()
    {
        List<string> result = new List<string>();
        foreach (SelectFile item in spFiles.Children)
        {
            // Here I can eliminate empty strings, during Validate is calling Validate on every control, not use this method
            if (item.SelectedFile != string.Empty)
            {
                result.Add(item.SelectedFile);
            }

        }
        return result;
    }

    private void BtnAddAsTemplate_Click(object sender, RoutedEventArgs eventArgs)
    {
        SaveSetAsTemplate();
    }
}
