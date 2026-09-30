#define ASYNC
namespace SunamoWpf.WindowsSettings;

public class WindowsDisplaySettings
{
    public enum DeviceCap
    {
        VERTRES = 10,
        DESKTOPVERTRES = 117,
    }


    //public static double getScalingFactor()
    //{
    //    Graphics g = Graphics.FromHwnd(IntPtr.Zero);
    //    IntPtr SunamoWpf = g.GetHdc();
    //    int LogicalScreenHeight = W32.GetDeviceCaps(SunamoWpf, (int)DeviceCap.VERTRES);
    //    int PhysicalScreenHeight = W32.GetDeviceCaps(SunamoWpf, (int)DeviceCap.DESKTOPVERTRES);

    //    double ScreenScalingFactor = (double)PhysicalScreenHeight / (double)LogicalScreenHeight;

    //    return ScreenScalingFactor; // 1.25 = 125%
    //}

    public static readonly List<string> windowsDisplayResolution = CA.ToListString("2560x1440", "2048x1152", "1920x1440", "1920x1200", "1920x1080", "1856x1392", "1792x1344", "1680x1050", "1600x1200", "1600x900", "1440x1050", "1366x768", "1360x768", "1280x1024", "1280x960", "1280x800", "1280x768", "1280x720", "1280x600", "1200x690", "1152x684", "1024x768", "800x600");
}