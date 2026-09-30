namespace SunamoWpf.Data;

/// <summary>
/// Wrapper nemusí implementovat žádné INotifyPropertyChanged aj. Stačí pouze public properta s implicitním get / set
/// </summary>
public class FoundedResultDataWrapper //: INotifyPropertyChanged
{
    public FoundedResultData Frd { get; set; }

    public FoundedResultDataWrapper(FoundedResultData f)
    {
        Frd = f;
    }

    public FoundedResultDataWrapper(string f)
    {
        Frd = new FoundedResultData { fileFullPath = f };
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

    public TUListWpf<string, Brush> P { get; set; }

    /// <summary>
    /// Is used for colorful highlighting and Selected event
    /// </summary>
    public string fileFullPath { get; set; }
    public TextBlock tbFileName2 { get; set; }
}