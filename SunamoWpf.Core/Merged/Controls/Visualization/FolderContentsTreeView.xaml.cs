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
    private void Tv_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
    {
        if (e.NewValue != null)
        {
            var tv = (e.NewValue as TreeViewItem);
            var fse = tv.Tag as FileSystemEntryWpf;
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
    private void Expand(ItemCollection ic)
    {
        foreach (TreeViewItem item in ic)
        {
            item.ExpandSubtree();
            Expand(item.Items);
        }
    }
    public void AddTviFolderTo(string s)
    {
        AddTviFolderTo(s, tv);
    }
    private void AddTviFolderTo(string s, ItemsControl to)
    {
        TreeViewItem subfolder = new TreeViewItem();
        s = s.TrimEnd('\\');
        subfolder.Header = s.Substring(s.LastIndexOf("\\") + 1);
        subfolder.Tag = new FileSystemEntryWpf { file = false, path = s }; ;
        subfolder.FontWeight = System.Windows.FontWeights.Normal;
        subfolder.Items.Add(dummyNode);
        subfolder.Expanded += new RoutedEventHandler(folder_Expanded);
        if (useDictionary)
        {
            folders.Add(s, subfolder);
        }
        to.Items.Add(subfolder);
    }
    private void AddTviFileTo(string s, ItemsControl to)
    {
        TreeViewItem subfiles = new TreeViewItem();
        subfiles.Header = s.Substring(s.LastIndexOf("\\") + 1);
        subfiles.Tag = new FileSystemEntryWpf { file = true, path = s };
        subfiles.FontWeight = System.Windows.FontWeights.Normal;
        if (useDictionary)
        {
            files.Add(s, subfiles);
        }
        to.Items.Add(subfiles);
    }
    void folder_Expanded(object sender, RoutedEventArgs e)
    {
        TreeViewItem item = (TreeViewItem)sender;
        if (item.Items.Count == 1 && item.Items[0] == dummyNode)
        {
            item.Items.Clear();
            try
            {
                string folder = ((FileSystemEntryWpf)item.Tag).path.ToString();
                foreach (string s in FSGetFolders.GetFoldersEveryFolder(logger, folder))
                {
                    AddTviFolderTo(s, item);
                }
                if (args.addFiles)
                {
                    List<string> d = FSGetFiles.GetFilesEveryFolder(logger, folder);
                    foreach (string s in d)
                    {
                        AddTviFileTo(s, item);
                    }
                }
            }
            catch (Exception) { }
        }
    }
    #endregion
}
