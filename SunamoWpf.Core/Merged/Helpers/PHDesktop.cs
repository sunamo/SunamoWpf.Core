#define ASYNC
namespace SunamoWpf;

public class PHDesktop
{
    public static void OpenFileInTag(object sender, RoutedEventArgs eventArgs)
    {
        var frameworkElement = (FrameworkElement)sender;
        PH.Start();
    }
    private static void KillProcessAndChildren(int pid)
    {
        // Cannot close 'system idle process'.
        if (pid == 0)
        {
            return;
        }
        //ManagementObjectSearcher searcher = new ManagementObjectSearcher
        //        ("Select * From Win32_Process Where ParentProcessID=" + pid);
        //ManagementObjectCollection moc = searcher.Get();
        //foreach (ManagementObject mo in moc)
        //{
        //    KillProcessAndChildren(Convert.ToInt32(mo["ProcessID"]));
        //}
        try
        {
            Process proc = Process.GetProcessById(pid);
            proc.Kill();
        }
        catch (ArgumentException)
        {
            // Process already exited.
        }
    }
    /// <summary>
    /// A1 without extension
    /// </summary>
    /// <param name = "name"></param>
    public static
#if ASYNC
    async Task<int>
#else
    int
#endif
 Terminate(string name)
    {
        int deleted = 0;
        var cmdHandle = "handle.exe |findstr /i ";
        const string pid = "pid:";
        const string pskill = "pskill ";
        var result = (
#if ASYNC
    await
#endif
 PowershellRunner.ci.Invoke(CA.ToListString(cmdHandle + name)))[0];
        var lines = result.Where(line => line.Contains(pid));
        var processid = -1;
        foreach (var item in lines)
        {
            processid = -1;
            List<string> parts = SHSplit.SplitByWhiteSpaces(item, true);
            var index = parts.IndexOf(pid);
            if (index != -1)
            {
                if (parts.Count > index + 1)
                {
                    processid = BTS.ParseInt(parts[index + 1]);
                }
            }
            if (processid != -1)
            {
                var result2 = PowershellRunner.ci.Invoke(CA.ToListString(pskill + processid));
                deleted++;
            }
        }
        //foreach (var process in Process.GetProcessesByName(name))
        //{
        //    process.Kill();
        //    deleted++;
        //}
        return deleted;
    }
}