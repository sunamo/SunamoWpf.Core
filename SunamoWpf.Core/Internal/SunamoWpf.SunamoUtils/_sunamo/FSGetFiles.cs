#define ASYNC
namespace SunamoWpf._sunamo;

internal class FSGetFiles
{
    public static List<string> GetFilesEveryFolder(ILogger logger, string fi, string v, SearchOption topDirectoryOnly)
    {
        try
        {
            return Directory.GetFiles(fi, v, topDirectoryOnly).ToList();
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message);
            return new List<string>();
        }
    }
    public static List<string> GetFilesEveryFolder(ILogger logger, string folder)
    {
        return GetFilesEveryFolder(logger, folder, "*", SearchOption.TopDirectoryOnly);
    }
}