#define ASYNC
namespace SunamoWpf.Helpers;

/// <summary>
/// Represents the display helper type.
/// </summary>
public class DisplayHelper
{
    /// <summary>
    /// Get scale factor.
    /// </summary>
    /// <returns>The get scale factor result.</returns>
    public static double GetScaleFactor()
    {
        //DisplayInformation.GetForCurrentView().RawPixelsPerViewPixel
        return 1;
    }
}