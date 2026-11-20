#define ASYNC
namespace SunamoWpf.Controls.Input;

public partial class SelectMoreFolders : UserControl
{

    /// <summary>
    /// The save set as template.
    /// </summary>
    public event Action SaveSetAsTemplate;
    /// <summary>
    /// Only adding folder with empty path
    /// </summary>
    public event Action<object, List<string>> FolderAdded;
    /// <summary>
    /// The folder changed.
    /// </summary>
    public event Action<object, List<string>> FolderChanged;
    /// <summary>
    /// The folder removed.
    /// </summary>
    public event Action<object, List<string>> FolderRemoved;

    /// <summary>
    /// Initializes a new instance of the select more folders class.
    /// </summary>
    public SelectMoreFolders()
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

        Loaded += SelectMoreFolders_Loaded;
    }

    private void SelectMoreFolders_Loaded(object sender, RoutedEventArgs eventArgs)
    {
        SetAwesomeIcons(); // async Task nelze RunSynchronously (InvalidOperationException); ikony se nastavi pres Dispatcher.InvokeAsync

        AddFolder(string.Empty);
    }

    /// <summary>
    /// Remove all folders.
    /// </summary>
    public void RemoveAllFolders()
    {
        for (int index = spFolders.Children.Count - 1; index >= 0; index--)
        {
            Sf_FolderRemoved((SelectFolder)spFolders.Children[index]);
        }
    }

    /// <summary>
    /// Add folder.
    /// </summary>
    /// <param name="folder">The folder.</param>
    public void AddFolder(string folder)
    {
        if (string.IsNullOrEmpty(folder) || (!string.IsNullOrEmpty(folder) && FS.ExistsDirectory(folder))
            )
        {
            //TextBox sf = new TextBox();
            //sf.Text = folder;

            SelectFolder selectFolder = new SelectFolder();
            selectFolder.SelectedFolder = folder;
            selectFolder.btnRemoveFolder.Visibility = Visibility.Visible;
            selectFolder.FolderRemoved += Sf_FolderRemoved;
            selectFolder.FolderChanged += Sf_FolderChanged;

            spFolders.Children.Add(selectFolder);
            if (FolderAdded != null)
            {
                FolderAdded(this, SelectedFolders());
            }
            // Must be called after sf is on panel and has registered Sf_FolderChanged, because control for FolderChanged != null
            Sf_FolderChanged(null, folder);
        }
    }

    private void Sf_FolderChanged(object sender, string folder)
    {
        if (FolderChanged != null)
        {
            FolderChanged(this, SelectedFolders());
        }
    }

    /// <summary>
    /// Sf folder removed.
    /// </summary>
    /// <param name="selectFolder">The select folder.</param>
    public void Sf_FolderRemoved(SelectFolder selectFolder)
    {
        spFolders.Children.Remove(selectFolder);
        if (FolderRemoved != null)
        {
            FolderRemoved(this, SelectedFolders());
        }
    }

    async Task SetAwesomeIcons()
    {
        await AwesomeFontControls.SetAwesomeFontSymbol(btnAddFolder, "\uf07c " + "New2");
        await AwesomeFontControls.SetAwesomeFontSymbol(btnAddAsTemplate, "\uf022 " + "Save set as template");

    }

    private void BtnAddFolder_Click(object sender, RoutedEventArgs eventArgs)
    {
        AddFolder(string.Empty);
    }

    /// <summary>
    /// Validate before call
    /// </summary>
    public List<string> SelectedFolders()
    {
        List<string> result = new List<string>();
        foreach (SelectFolder item in spFolders.Children)
        {
            // Here I can eliminate empty strings, during Validate is calling Validate on every control, not use this method
            if (item.SelectedFolder != string.Empty)
            {
                result.Add(item.SelectedFolder);
            }

        }
        return result;
    }

    private void BtnAddAsTemplate_Click(object sender, RoutedEventArgs eventArgs)
    {
        SaveSetAsTemplate();
    }

    /// <summary>
    /// The type.
    /// </summary>
    public static Type type = typeof(SelectMoreFolders);
    /// <summary>
    /// The validated.
    /// </summary>
    public static bool validated
    {
        get
        {
            return SelectFolder.validated;
        }
        set
        {
            SelectFolder.validated = value;
        }
    }

    /// <summary>
    /// Validate.
    /// </summary>
    /// <param name="control">The control.</param>
    public static void Validate(SelectMoreFolders control)
    {
        var controls = ControlFinder.StackPanel(control, "spFolders").Children;
        foreach (SelectFolder item in controls)
        {
            item.Validate();
        }
    }

    /// <summary>
    /// Validate.
    /// </summary>
    public void Validate()
    {
        Validate(this);
    }

    private void btnSaveChangesToTemplate_Click(object sender, RoutedEventArgs eventArgs)
    {

    }
}
