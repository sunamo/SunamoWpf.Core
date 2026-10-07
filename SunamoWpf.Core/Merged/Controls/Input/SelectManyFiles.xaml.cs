#define ASYNC
// SunamoWpfControlsInput
namespace SunamoWpf.Controls.Input;

public partial class SelectManyFiles : UserControl
{
    public static Type type = typeof(SelectManyFiles);

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

    public static bool validated
    {
        get => ValidationHelper.validated;
        set => ValidationHelper.validated = value;
    }

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

    public event Action SaveSetAsTemplate;
    /// <summary>
    /// Only adding File with empty path
    /// </summary>
    public event Action<object, List<string>> FileAdded;
    public event Action<object, List<string>> FileChanged;
    public event Action<object, List<string>> FileRemoved;

    private void SelectMoreFiles_Loaded(object sender, RoutedEventArgs eventArgs)
    {
        SetAwesomeIcons(); // async Task nelze RunSynchronously (InvalidOperationException); ikony se nastavi pres Dispatcher.InvokeAsync

        AddFile(string.Empty);
    }

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
        await AwesomeFontControls.SetAwesomeFontSymbol(btnAddFile, "\uf07c " + Translate.FromKey(XlfKeys.New));
        await AwesomeFontControls.SetAwesomeFontSymbol(btnAddAsTemplate, "\uf022 Save set as template");
    }

    private void BtnAddFile_Click(object sender, RoutedEventArgs eventArgs)
    {
        AddFile(string.Empty);
    }





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
