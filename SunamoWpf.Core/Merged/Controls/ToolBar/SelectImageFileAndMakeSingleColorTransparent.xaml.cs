#define ASYNC
namespace SunamoWpf.Controls;

public partial class SelectImageFileAndMakeSingleColorTransparent : UserControl
{
    #region Rewrite to pure cs. With xaml is often problems without building
    public int MinimalImageWidth { get; set; }
    public int MinimalImageHeight { get; set; }
    public bool Square { get; set; }

    public SelectImageFileAndMakeSingleColorTransparent()
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

    //public event VoidStringBitmapBitmapSource FileSelected;
    //public BitmapImage bi = null;
    //public Bitmap bmp = null;
    private void btnSelectFile_Click(object sender, RoutedEventArgs e)
    {
        //    string file = null;
        //    file = DW.SelectOfFile(Environment.SpecialFolder.DesktopDirectory);
        //    if (file != null)
        //    {
        //        if (FS.ExistsFile(file))
        //        {
        //            SelectedFile = file;
        //            bi = new BitmapImage(new Uri(file));
        //            bmp = new Bitmap(file);
        //            System.Drawing.Color first2 = bmp.GetPixel(0, 0);


        //            MemoryStream ms = new MemoryStream();
        //            bmp.Save(ms, ImageFormat.Png);
        //            var arr = ms.ToArray();

        //            bi = new BitmapImage();

        //            bi.BeginInit();
        //            bi.StreamSource = ms;
        //            bi.EndInit();
        //            var bs = bi;
        //            bmp = PicturesDesktop.BitmapImage2Bitmap(bs);
        //            //bmp.MakeTransparent(System.Drawing.Color.FromArgb(pxs[0, 0].Alpha, pxs[0, 0].Red, pxs[0, 0].Green, pxs[0, 0].Blue));
        //            FileSelected(file, bmp, bs);
        //        }
        //    }
    }

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
}
#endregion
