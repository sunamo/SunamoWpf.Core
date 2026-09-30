#define ASYNC
namespace SunamoWpf.Controls.Result;

public class FoundedFileUC : FoundedResultUC
{
    /// <summary>
    /// Musí to být DependencyProperty jinak bych ji nemohl užít v XAML
    /// </summary>
    public static readonly DependencyProperty FileFullPathProperty = DependencyProperty
.Register("FileFullPath", typeof(string), typeof(FoundedFileUC), new UIPropertyMetadata(Frd3Changed));
    /// <summary>
    /// Toto je jediná cesta jak updatovat element v ListViewItem.
    ///
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public static void Frd3Changed(DependencyObject sender, DependencyPropertyChangedEventArgs e)
    {
        var v = (FoundedFileUC)sender;
        v.tbFileName.Text = e.NewValue.ToString();
    }
    public string FileFullPath { get; set; }
    public FoundedFileUC(string filePath, TUListWpf<string, Brush> p, int serie) : base(filePath, p, serie)
    {
    }
    public FoundedFileUC()
    {
    }
    public TextBox txtFilter = new TextBox();
    public new string fileFullPath
    {
        get { return base.fileFullPath; }
        set { base.fileFullPath = value; }
    }
    /*
     * FoundedResultUC.file se využívá, FoundedFileUC.file ne
     *
     */
    //public string file
    //{
    //    get { return base.file; }
    //    set { base.file = value; }
    //}
    public TextBlock tbFileName2 { get => tbFileName; set => tbFileName = value; }
}