#define ASYNC
namespace SunamoWpf.Controls.Result;

/// <summary>
/// Represents the founded file UC type.
/// </summary>
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
    /// <param name="eventArgs"></param>
    public static void Frd3Changed(DependencyObject sender, DependencyPropertyChangedEventArgs eventArgs)
    {
        var control = (FoundedFileUC)sender;
        control.tbFileName.Text = eventArgs.NewValue.ToString();
    }
    /// <summary>
    /// Gets or sets the file full path.
    /// </summary>
    public string FileFullPath { get; set; }
    /// <summary>
    /// Initializes a new instance of the founded file UC class.
    /// </summary>
    /// <param name="filePath">The file path.</param>
    /// <param name="colors">The colors.</param>
    /// <param name="serie">The serie.</param>
    public FoundedFileUC(string filePath, TUListWpf<string, Brush> colors, int serie) : base(filePath, colors, serie)
    {
    }
    /// <summary>
    /// Initializes a new instance of the founded file UC class.
    /// </summary>
    public FoundedFileUC()
    {
    }
    /// <summary>
    /// The txt filter.
    /// </summary>
    public TextBox txtFilter = new TextBox();
    /// <summary>
    /// The file full path.
    /// </summary>
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
    /// <summary>
    /// Gets the tb file name 2.
    /// </summary>
    public TextBlock tbFileName2 { get => tbFileName; set => tbFileName = value; }
}