namespace SunamoWpf.Helpers;

/// <summary>
/// Represents the font weight helper type.
/// </summary>
public class FontWeightHelper
{
    /// <summary>
    /// From enum.
    /// </summary>
    /// <param name="fontWeight">The font weight.</param>
    /// <returns>The from enum result.</returns>
    public static FontWeight FromEnum(SunamoWpf.Enums.FontWeights fontWeight)
    {
        return FontWeight.FromOpenTypeWeight((int)fontWeight);
    }
}