#define ASYNC
namespace SunamoWpf.Controls.Input;

public partial class SelectFolder : UserControl
{
    //public event VoidString FolderSelected;
    public event Action<object, string> FolderChanged;
    public event VoidT<SelectFolder> FolderRemoved;
    public SelectFolder()
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
#if DEBUG
        ComboBox cbDefaultFolders = new ComboBox();
        cbDefaultFolders.IsEditable = false;
        cbDefaultFolders.ItemsSource = DefaultPaths.All;
        cbDefaultFolders.SelectionChanged += CbDefaultFolders_SelectionChanged;
#endif
        btnSelectFolder.Content = Translate.FromKey(XlfKeys.SelectTheFolder);
        Loaded += SelectFolder_Loaded;
    }
    private void SelectFolder_Loaded(object sender, RoutedEventArgs eventArgs)
    {
        AwesomeFontControls.SetAwesomeFontSymbol(btnRemoveFolder, "\uf00d"); // async Task nelze RunSynchronously (InvalidOperationException); symbol se nastavi pres Dispatcher.InvokeAsync
    }
    private void CbDefaultFolders_SelectionChanged(object sender, SelectionChangedEventArgs eventArgs)
    {
        ComboBox comboBox = sender as ComboBox;
        SelectOfFolder(comboBox.SelectedItem.ToString());
    }
    /// <summary>
    /// Nastaví složku pouze když složka bude existovat na disku
    /// When not, throw ex => musím prvně ověřit zdali ta složka existuje
    /// </summary>
    public string SelectedFolder
    {
        get
        {
            return txtFolder.Text;
        }
        set
        {
            if (!string.IsNullOrEmpty(value))
            {
                OnFolderChanged(value);
                if (FS.ExistsDirectory(value))
                {
                    //FireFolderChanged = false;
                    txtFolder.Text = value;
                    //FireFolderChanged = true;
                }
                else
                {
                    // Have to raise exception. Because setting string.Empty just later won't passed with Validation
                    ThrowEx.DirectoryWasntFound(value);
                    //txtFolder.Text = "";
                }
            }
        }
    }
    private void btnSelectFolder_Click(object sender, RoutedEventArgs eventArgs)
    {
        SelectOfFolder();
    }
    private void txtFolder_MouseDoubleClick(object sender, MouseButtonEventArgs eventArgs)
    {
        SelectOfFolder();
    }
    private void SelectOfFolder()
    {
        string folder = DW.SelectOfFolder();
        SelectOfFolder(folder);
    }
    private void SelectOfFolder(string folder)
    {
        if (folder != null)
        {
            txtFolder.Text = folder;
            OnFolderChanged(folder);
        }
    }
    private void OnFolderChanged(string folder)
    {
        if (FolderChanged != null)
        {
            FolderChanged(this, folder);
        }
    }
    private void BtnRemoveFolder_Click(object sender, RoutedEventArgs eventArgs)
    {
        if (FolderRemoved != null)
        {
            FolderRemoved(this);
        }
    }
}
