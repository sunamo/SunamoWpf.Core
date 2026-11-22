namespace SunamoWpf;

/// <summary>
/// Tento výčet říká kam se mají ukládat uživatelská data aplikace ve formě řetězců
/// </summary>
public enum StorageApplicationData
{
    /// <summary>
    /// The registry value.
    /// </summary>
    Registry,
    /// <summary>
    /// App.Config nebo Web.Config
    /// </summary>
    Config,
    /// <summary>
    /// The ini file value.
    /// </summary>
    IniFile,
    /// <summary>
    /// The text file value.
    /// </summary>
    TextFile,
    /// <summary>
    /// Stejný případ jako publicSaveLogic = false
    /// </summary>
    NoWhere
}