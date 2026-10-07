#define ASYNC
namespace SunamoWpf.Extensions;

public static class SizeExtensions
{
    public static Size RecalculateSizeWithScaleFactor(this Size size2)
    {
        var scaleFactor = DisplayHelper.GetScaleFactor();
        var size = new Size(size2.Width / scaleFactor, size2.Height / scaleFactor);
        return size;
    }


}