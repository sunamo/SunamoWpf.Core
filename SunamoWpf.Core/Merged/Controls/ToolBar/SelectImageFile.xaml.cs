#define ASYNC
namespace SunamoWpf.Controls;


public partial class SelectImageFile : UserControl
{


    #region Rewrite to pure cs. With xaml is often problems without building
    public int MinimalImageWidth { get; set; }
    public int MinimalImageHeight { get; set; }
    public bool Square { get; set; }

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

    private void SetSelectedFile(string v)
    {
        if (v == "")
        {
            v = Translate.FromKey(XlfKeys.None);
        }
        selectedFile = v;
        tbSelectedFile.Text = Translate.FromKey(XlfKeys.SelectedFile) + ": " + v;
    }

    //public event VoidStringBitmapBitmapImage FileSelected;

    private void btnSelectFile_Click(object sender, RoutedEventArgs e)
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
