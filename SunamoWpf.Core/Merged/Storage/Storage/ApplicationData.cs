#define ASYNC
namespace SunamoWpf.Storage;

/// <summary>
/// Create file data.dat in Local and Roaming but in no one app is use
/// </summary>
public class ApplicationData
{
    //static ApplicationData()
    //{
    //    RoamingSettings = new ApplicationDataContainer(AppData.ci.GetFile(AppFolders.Roaming, "data.dat"));
    //    //Path.Combine(SpecialFoldersHelper.ApplicationData(), "Local", Consts.@sunamo, appName, "data.dat")
    //    LocalSettings = new ApplicationDataContainer(AppData.ci.GetFile(AppFolders.Local, "data.dat"));
    //}

    public static ApplicationDataContainer RoamingSettings = null;
    public static ApplicationDataContainer LocalSettings = null;
}