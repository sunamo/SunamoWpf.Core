#define ASYNC
namespace SunamoWpf.Extensions;

public static class SizeExtensions
{
    public static Size RecalculateSizeWithScaleFactor(this Size unscaledSize)
    {
        var scaleFactor = DisplayHelper.GetScaleFactor();
        var size = new Size(unscaledSize.Width / scaleFactor, unscaledSize.Height / scaleFactor);
        return size;
    }


}