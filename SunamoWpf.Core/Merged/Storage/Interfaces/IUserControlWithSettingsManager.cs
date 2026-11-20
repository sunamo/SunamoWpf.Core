#define ASYNC
namespace SunamoWpf.Interfaces;

/// <summary>
/// Represents the i user control with settings manager type.
/// </summary>
public interface IUserControlWithSettingsManager
{
    // Picovina, its running automatically while startup and shutdown
    //void LoadSettings();
    //void SaveSettings();
    /// <summary>
    /// The data.
    /// </summary>
    ApplicationDataContainer data
    {
        get;
    }
}