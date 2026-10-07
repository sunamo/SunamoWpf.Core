#define ASYNC
namespace SunamoWpf;
public class FSWin //: IFSWin
{
    public static FSWin ci = new FSWin();

    private static void Terminate(List<Process> processes)
    {
        foreach (var item in processes)
        {
            Terminate(item);
        }
    }


    private static void Terminate(Process item)
    {
        //Thread.Sleep(10000);
        Task.Factory.StartNew(() => { item.Kill(); });
        item.WaitForExit();
    }

    public static void DeleteFileMaybeLocked(string path)
    {
        var processes = FileUtil.WhoIsLocking(path);
        Terminate(processes);
        FS.TryDeleteFile(path);
    }

    public static void DeleteFileOrFolderMaybeLocked(string path)
    {
        Console.WriteLine("DeleteFileOrFolderMaybeLocked: " + path);
        if (File.Exists(path))
        {
            DeleteFileMaybeLocked(path);
            if (File.Exists(path))
            {
                WpfLogger.Error(path + " could not be deleted! Press enter to continue!");
                Console.ReadLine();
            }
            else
            {
                WpfLogger.Success(path + " was deleted completely!");
            }
        }
        else if (Directory.Exists(path))
        {
            var files = Directory.GetFiles(path, "*", SearchOption.AllDirectories);

            foreach (var item in files)
            {
                //if (RandomHelper.RandomBool())
                //{
                //    continue;
                //}
                DeleteFileMaybeLocked(item);
            }
            files = Directory.GetFiles(path, "*", SearchOption.AllDirectories);
            if (files.Length == 0)
            {
                Directory.Delete(path, true);
                WpfLogger.Success(path + " was deleted completely!");
            }
            else
            {
                WpfLogger.Error(path + " could not be deleted completely! Press enter to continue!");
                Console.ReadLine();
            }
        }
        else
        {
            // Only warning, not exc with stacktrace cecause is using in Quadient
            WpfLogger.Warning("Doesnt exists as file / folder:" + path);
            //ThrowEx.FileDoesntExists(p);
        }
    }

    public static Type type = typeof(FSWin);

    /// <summary>
    /// Nedařilo se mi s tímhle mazat git složky
    /// 
    /// řešením bylo otevřít git bash a rm -rf .git
    /// </summary>
    /// <param name="p"></param>


    /// <summary>
    /// <summary>
    /// Jednodušší bude si udělat push a celou složku smazat
    /// V Azuru poté uvidím všechny změny, to bych sice viděl i ve forku ale musel bych to přidávat
    /// </summary>
    /// <param name="arg1"></param>
    /// <param name="replacement"></param>
    public static void MoveFolderMaybeLocked(string arg1, string replacement)
    {
        FS.WithEndSlash(ref arg1);
        FS.WithEndSlash(ref replacement);

        var files = Directory.GetFiles(arg1, "*", SearchOption.AllDirectories);
        foreach (var item in files)
        {
            var newPath = item.Replace(arg1, replacement);
            var processes = FileUtil.WhoIsLocking(item, false);
            Terminate(processes);

            FS.CreateUpfoldersPsysicallyUnlessThere(newPath);
            if (File.Exists(item))
            {
                File.Move(item, newPath);
            }
        }

        files = Directory.GetFiles(arg1, "*", SearchOption.AllDirectories);
        if (files.Length == 0)
        {
            Directory.Delete(arg1, true);
        }
        else
        {
            WpfLogger.Error("Not all files was moved! " + arg1);
            Console.ReadLine();
        }
    }
}