namespace SunamoWpf.Data;

/// <summary>
/// Wrapper nemusí implementovat žádné INotifyPropertyChanged aj. Stačí pouze public properta s implicitním get / set
/// </summary>
public class FoundedResultDataWrapper //: INotifyPropertyChanged
{
    /// <summary>
    /// Gets or sets the frd.
    /// </summary>
    public FoundedResultData Frd { get; set; }

    /// <summary>
    /// Initializes a new instance of the founded result data wrapper class.
    /// </summary>
    /// <param name="data">The data.</param>
    public FoundedResultDataWrapper(FoundedResultData data)
    {
        Frd = data;
    }

    /// <summary>
    /// Initializes a new instance of the founded result data wrapper class.
    /// </summary>
    /// <param name="path">The path.</param>
    public FoundedResultDataWrapper(string path)
    {
        Frd = new FoundedResultData { fileFullPath = path };
    }
}

/// <summary>
/// All data which is passed to ctor of FoundedResultUC
/// Dědění z IFoundedFileUC jsem přidal protože v FoundedFilesResults2 se používá u všeho
/// Nicméně IFoundedFileUC je pouze ve SunamoDebugging, to nemůžu mít připojeno věčně, je to jen než vychytám. tedy zakomentuji
/// </summary>
public class FoundedResultData //: IFoundedFileUC
{
    //public string Serie { get;  set; }

    /// <summary>
    /// Gets or sets the p.
    /// </summary>
    public TUListWpf<string, Brush> P { get; set; }

    /// <summary>
    /// Is used for colorful highlighting and Selected event
    /// </summary>
    public string fileFullPath { get; set; }
    /// <summary>
    /// Gets or sets the tb file name 2.
    /// </summary>
    public TextBlock tbFileName2 { get; set; }
}