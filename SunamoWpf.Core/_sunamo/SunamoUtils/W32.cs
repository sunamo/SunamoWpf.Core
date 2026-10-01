#define ASYNC
namespace SunamoWpf.Core._sunamo;

internal class W32
{
    [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true, CallingConvention = CallingConvention.Winapi)]
    internal static extern short GetKeyState(int keyCode);
}
