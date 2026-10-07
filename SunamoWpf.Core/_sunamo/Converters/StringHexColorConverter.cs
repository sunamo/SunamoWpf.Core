namespace SunamoWpf.Core._sunamo;

internal static partial class StringHexColorConverter //: ISimpleConverter<string, Color>
{
    public static string ConvertTo(System.Drawing.Color color)
    {
        return string.Format("#{0:X2}{1:X2}{2:X2}{3:X2}", color.A, color.R, color.G, color.B);
    }
}
