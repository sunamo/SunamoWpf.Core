#define ASYNC
namespace SunamoWpf.Core._sunamo;

internal class FSGetFiles
{
    public static List<string> GetFilesEveryFolder(ILogger logger, string folder, string mask, SearchOption topDirectoryOnly)
    {
        try
        {
            return Directory.GetFiles(folder, mask, topDirectoryOnly).ToList();
        }
        catch (Exception exception)
        {
            logger.LogError(exception.Message);
            return new List<string>();
        }
    }
    public static List<string> GetFilesEveryFolder(ILogger logger, string folder)
    {
        return GetFilesEveryFolder(logger, folder, "*", SearchOption.TopDirectoryOnly);
    }
}
