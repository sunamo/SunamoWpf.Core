#define ASYNC
namespace SunamoWpf.Interfaces;

public interface IUserControlWithSettingsManager
{
    // Picovina, its running automatically while startup and shutdown
    //void LoadSettings();
    //void SaveSettings();
    ApplicationDataContainer data
    {
        get;
    }
}