#define ASYNC
namespace SunamoWpf.Controls.Result;

public partial class FoundedResultUC : UserControl//, IFoundedResultUC
{
    public FoundedResultData Frd { get; set; }
    #region Commented - dont know why
    //UIElement previousSecondRow = new UserControl();
    //public FoundedResultUC(string header, int serie)
    //{
    //    try
    //            {
    //                InitializeComponent();
    //            }
    //            catch (Exception ex)
    //            {
    //#if DEBUG
    //                Debugger.Break();
    //#endif
    //            }
    //    ellipseSerie.Stroke = Brushes.Black;
    //    tbHeader.Text = header;
    //    tbSerie.Text = serie.ToString();
    //}
    //public UIElement SecondRow
    //{
    //    set
    //    {
    //        //gridContent.Children.Remove(previousSecondRow);
    //        //Grid.SetRow(value, 1);
    //        //Grid.SetColumn(value, 0);
    //        //gridContent.Children.Add(value);
    //        //gridContent.UpdateLayout();
    //        dp.Children.Clear();
    //        dp.Children.Add(value);
    //        //tbDesc.Content = value;
    //        previousSecondRow = value;
    //    }
    //}
    #endregion
    public event VoidString Selected;
    /// <summary>
    /// Is used for showing visually
    /// </summary>
    public string file = null;
    public string fileFullPath
    {
        get { return Frd.fileFullPath; }
        set { Frd.fileFullPath = value; }
    }
    public bool Contains(string text)
    {
        return Frd.fileFullPath.Contains(text);
    }
    public bool Contains(Regex regex, string text)
    {
        if (regex != null)
        {
            return regex.IsMatch(Frd.fileFullPath);
        }
        return Frd.fileFullPath.Contains(text);
    }
    public FoundedResultUC() : base()
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
        Loaded += FoundedResultUC_Loaded;
    }
    /// <summary>
    /// A2 is require but is available through foundedResultsUC.DefaultBrush
    /// </summary>
    /// <param name="filePath"></param>
    /// <param name="colors"></param>
    /// <param name="serie"></param>
    public FoundedResultUC(string filePath, TUListWpf<string, Brush> colors, int serie)
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
        Frd = new FoundedResultData();
        tbSerie.Text = serie.ToString();
        Frd.fileFullPath = filePath;
        ellipseSerie.Stroke = Brushes.Black;
        Frd.P = colors;
        Loaded += FoundedResultUC_Loaded;
    }
    private void FoundedResultUC_Loaded(object sender, RoutedEventArgs eventArgs)
    {
        this.file = Frd.fileFullPath;
        bool replaced = false;
        foreach (var item in FoundedFilesUC.basePaths)
        {
            file = SHReplace.ReplaceOnceIfStartedWith(file, item, "", out replaced);
            if (replaced)
            {
                break;
            }
        }
        tbFileName.Text = file;
        foreach (var item in Frd.P)
        {
            if (SH.Contains(Frd.fileFullPath, item.Key))
            {
                ellipseSerie.Stroke = item.Value;
                tbFileName.Foreground = item.Value;
                break;
            }
        }
        this.MouseLeftButtonDown += FoundedFileUC_MouseLeftButtonDown;
    }
    public UIElement SecondRow
    {
        set
        {
        }
    }
    protected override void OnGotFocus(RoutedEventArgs eventArgs)
    {
        base.OnGotFocus(eventArgs);
        Selected(Frd.fileFullPath);
    }
    private void FoundedFileUC_MouseLeftButtonDown(object sender, MouseButtonEventArgs eventArgs)
    {
        Selected(Frd.fileFullPath);
    }
}
