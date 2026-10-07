#define ASYNC
namespace SunamoWpf.Controls;

public partial class FolderContentsTreeView : UserControl
{
    #region Rewrite to pure cs. With xaml is often problems without building
    private object dummyNode = null;
    public event VoidT<FileSystemEntryWpf> Selected;
    public Dictionary<string, TreeViewItem> folders = new Dictionary<string, TreeViewItem>();
    public Dictionary<string, TreeViewItem> files = new Dictionary<string, TreeViewItem>();
    public FolderContentsTreeViewArgs args = new FolderContentsTreeViewArgs();
    ILogger logger;
    public FolderContentsTreeView(ILogger logger)
    {
        this.logger = logger;
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
    bool useDictionary = false;
    public bool UseDictionary
    {
        set
        {
            useDictionary = value;
        }
    }
    /// <summary>
    /// A1 can be null
    /// </summary>
    /// <param name="folder"></param>
    /// <param name="args"></param>
    public void Initialize(string folder, FolderContentsTreeViewArgs args = null)
    {
        if (args != null)
        {
            this.args = args;
        }
        if (folder != null)
        {
            AddTviFolderTo(folder, tv);
        }
        tv.SelectedItemChanged += Tv_SelectedItemChanged;
    }
    private void Tv_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> eventArgs)
    {
        if (eventArgs.NewValue != null)
        {
            var treeViewItem = (eventArgs.NewValue as TreeViewItem);
            var fse = treeViewItem.Tag as FileSystemEntryWpf;
            if (Selected != null)
            {
                Selected(fse);
            }
        }
    }
    public void ExpandAll()
    {
        var exp = tv.Items;
        Expand(exp);
    }
    private void Expand(ItemCollection items)
    {
        foreach (TreeViewItem item in items)
        {
            item.ExpandSubtree();
            Expand(item.Items);
        }
    }
    public void AddTviFolderTo(string folder)
    {
        AddTviFolderTo(folder, tv);
    }
    private void AddTviFolderTo(string folder, ItemsControl parent)
    {
        TreeViewItem subfolder = new TreeViewItem();
        folder = folder.TrimEnd('\\');
        subfolder.Header = folder.Substring(folder.LastIndexOf("\\") + 1);
        subfolder.Tag = new FileSystemEntryWpf { file = false, path = folder }; ;
        subfolder.FontWeight = System.Windows.FontWeights.Normal;
        subfolder.Items.Add(dummyNode);
        subfolder.Expanded += new RoutedEventHandler(folder_Expanded);
        if (useDictionary)
        {
            folders.Add(folder, subfolder);
        }
        parent.Items.Add(subfolder);
    }
    private void AddTviFileTo(string filePath, ItemsControl parent)
    {
        TreeViewItem subfiles = new TreeViewItem();
        subfiles.Header = filePath.Substring(filePath.LastIndexOf("\\") + 1);
        subfiles.Tag = new FileSystemEntryWpf { file = true, path = filePath };
        subfiles.FontWeight = System.Windows.FontWeights.Normal;
        if (useDictionary)
        {
            files.Add(filePath, subfiles);
        }
        parent.Items.Add(subfiles);
    }
    void folder_Expanded(object sender, RoutedEventArgs eventArgs)
    {
        TreeViewItem item = (TreeViewItem)sender;
        if (item.Items.Count == 1 && item.Items[0] == dummyNode)
        {
            item.Items.Clear();
            try
            {
                string folder = ((FileSystemEntryWpf)item.Tag).path.ToString();
                foreach (string subfolder in FSGetFolders.GetFoldersEveryFolder(logger, folder))
                {
                    AddTviFolderTo(subfolder, item);
                }
                if (args.addFiles)
                {
                    List<string> files = FSGetFiles.GetFilesEveryFolder(logger, folder);
                    foreach (string file in files)
                    {
                        AddTviFileTo(file, item);
                    }
                }
            }
            catch (Exception) { }
        }
    }
    #endregion
}
