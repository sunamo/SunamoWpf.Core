#define ASYNC
namespace SunamoWpf;

/// <summary>
///     Not include in standard
/// </summary>
[System.Runtime.Versioning.SupportedOSPlatform("windows")]
public partial class PH
{
    public static bool IsAlreadyRunning()
    {
        return false;
    }

    public static void Start()
    {
    }

    private static string GetMainModuleFilepath(int processId)
    {
        var wmiQueryString = "SELECT ProcessId, ExecutablePath FROM Win32_Process WHERE ProcessId = " + processId;
        using (var searcher = new ManagementObjectSearcher(wmiQueryString))
        {
            using (var results = searcher.Get())
            {
                var managementObject = results.Cast<ManagementObject>().FirstOrDefault();
                if (managementObject != null) return (string)managementObject["ExecutablePath"];
            }
        }
        return null;
    }
}