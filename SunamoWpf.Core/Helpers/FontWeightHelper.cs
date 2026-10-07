namespace SunamoWpf.Helpers;

public class FontWeightHelper
{
    public static FontWeight FromEnum(SunamoWpf.Enums.FontWeights fontWeight)
    {
        return FontWeight.FromOpenTypeWeight((int)fontWeight);
    }
}