#define ASYNC
// SunamoWpfControlsInput
namespace SunamoWpf.Controls.Input;

public partial class SelectManyFiles : UserControl
{
    public static Type type = typeof(SelectManyFiles);

    public void Validate(ref ValidateDataWpf d)
    {
        if (d == null)
        {
            d = new ValidateDataWpf();
        }
        foreach (SelectFile item in ControlFinder.StackPanel(this, "spFiles").Children)
        {
            item.Validate(ref d);
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

    private void SelectMoreFiles_Loaded(object sender, RoutedEventArgs e)
    {
        SetAwesomeIcons(); // async Task nelze RunSynchronously (InvalidOperationException); ikony se nastavi pres Dispatcher.InvokeAsync

        AddFile(string.Empty);
    }

    public void AddFile(string File)
    {
        //TextBox sf = new TextBox();
        //sf.Text = File;

        SelectFile sf = new SelectFile();
        sf.SelectedFile = File;
        sf.btnRemoveFile.Visibility = Visibility.Visible;
        sf.FileRemoved += Sf_FileRemoved;
        sf.FileSelected += Sf_FileChanged;

        spFiles.Children.Add(sf);
        if (FileAdded != null)
        {
            FileAdded(this, SelectedFiles());
        }
        // Must be called after sf is on panel and has registered Sf_FileChanged, because control for FileChanged != null
        Sf_FileChanged(File);
    }

    private void Sf_FileChanged(string s)
    {
        if (FileChanged != null)
        {
            FileChanged(this, SelectedFiles());
        }
    }

    public void Sf_FileRemoved(SelectFile t)
    {
        spFiles.Children.Remove(t);
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

    private void BtnAddFile_Click(object sender, RoutedEventArgs e)
    {
        AddFile(string.Empty);
    }





    public void RemoveAllFiles()
    {
        for (int i = spFiles.Children.Count - 1; i >= 0; i--)
        {
            Sf_FileRemoved((SelectFile)spFiles.Children[i]);
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

    private void BtnAddAsTemplate_Click(object sender, RoutedEventArgs e)
    {
        SaveSetAsTemplate();
    }
}
