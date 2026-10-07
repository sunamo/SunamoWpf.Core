#define ASYNC
namespace SunamoWpf.StartupHelper;

public class FileTextLogger
{
    /// <summary>
    /// It was be totally nonsense, just do it in memory. Even if I call sw.Close and sw.Dispose app still hold the file
    /// </summary>
    public StreamWriter sw = null;
    public string fn = null;
    public StringBuilder sb = new StringBuilder();

    /// <summary>
    /// Buffer 1MB
    /// </summary>
    /// <param name="fileName"></param>
    public FileTextLogger(string fileName)
    {
        this.fn = fileName;
        FS.CreateUpfoldersPsysicallyUnlessThere(fileName);
        //FileStream fs = new FileStream(fn, FileMode.OpenOrCreate);

        // 1024 * 1024 *
        // cant use, could terminate itself
        //PH.ShutdownProcessWhichOccupyFileHandleExe(fn);

        // It was be totally nonsense, just do it in memory. Even if I call sw.Close and sw.Dispose app still hold the file
        //sw = File.CreateText(fn);//, Encoding.UTF8,  1024 * bufferInMb);
        //sw.AutoFlush = true;
        WriteNewLine(DateTime.Now.ToLongTimeString());
    }

    public void WriteNewLine(string line)
    {
        // Is written StartupHelper.Dispose => just sb here
        //TF.AppendAllText(l + Environment.NewLine, fn);
        sb.AppendLine(line);

        // Umí se to zapsat aji ve StartupHelper.Dispose ale budu to zapisovat aji zde průběřně protože StartupHelper.Dispose to nedosáhne
        File.WriteAllText(fn, sb.ToString());
    }
}