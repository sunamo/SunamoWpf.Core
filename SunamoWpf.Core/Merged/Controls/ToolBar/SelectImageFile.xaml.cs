#define ASYNC
namespace SunamoWpf.Controls;


public partial class SelectImageFile : UserControl
{


    #region Rewrite to pure cs. With xaml is often problems without building
    /// <summary>
    /// Gets or sets the minimal image width.
    /// </summary>
    public int MinimalImageWidth { get; set; }
    /// <summary>
    /// Gets or sets the minimal image height.
    /// </summary>
    public int MinimalImageHeight { get; set; }
    /// <summary>
    /// Gets or sets the square.
    /// </summary>
    public bool Square { get; set; }

    /// <summary>
    /// Initializes a new instance of the select image file class.
    /// </summary>
    public SelectImageFile()
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
    }

    private void SetSelectedFile(string path)
    {
        if (path == "")
        {
            path = "None";
        }
        selectedFile = path;
        tbSelectedFile.Text = "SelectedFile" + ": " + path;
    }

    //public event VoidStringBitmapBitmapImage FileSelected;

    private void btnSelectFile_Click(object sender, RoutedEventArgs eventArgs)
    {
        string file = null;
        file = DW.SelectOfFile();
        if (file != null)
        {
            if (FS.ExistsFile(file))
            {
                SelectedFile = file;
                if (bi == null)
                {
                    if (FS.ExistsFile(file))
                    {
                        bi = new BitmapImage(new Uri(file));
                    }
                }
                //FileSelected(file, null, bi);
            }
        }
    }

    BitmapImage bi = null;



    string selectedFile = "";

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
            SetSelectedFile(value);
        }
    }
    #endregion
}
