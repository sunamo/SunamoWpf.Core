#define ASYNC
namespace SunamoWpf.Core._sunamo;

internal class FSGetFolders
{
    public static List<string> GetFoldersEveryFolder(ILogger logger, string folder, string mask, SearchOption topDirectoryOnly)
    {
        try
        {
            return Directory.GetDirectories(folder, mask, topDirectoryOnly).ToList();
        }
        catch (Exception exception)
        {
            logger.LogError(exception.Message);
            return new List<string>();
        }
    }
    public static List<string> GetFoldersEveryFolder(ILogger logger, string folder)
    {
        return GetFoldersEveryFolder(logger, folder, "*", SearchOption.TopDirectoryOnly);
    }
}
