/// <summary>
/// Jediná třída která ho dědí je FoundedFileUC
/// </summary>
public interface IFoundedFileUC
{
    //FoundedResultUC.file se využívá, FoundedFileUC.file ne
    //string file { get; set; }
    /// <summary>
    /// Gets or sets the file full path.
    /// </summary>
    string fileFullPath { get; set; }
    /// <summary>
    /// Proč tu je tohle? ve FoundedResultData to nepotřebuji
    /// Aha, to je proto protože je to UC
    ///
    /// </summary>
    TextBlock tbFileName2 { get; set; }
}
