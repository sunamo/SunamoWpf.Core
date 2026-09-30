namespace SunamoWpf.Extensions.SIze;

public static partial class SunamoSizeExtensions
{
    public static System.Drawing.Size ToSystemDrawing(this SunamoSize ss)
    {
        return new System.Drawing.Size((int)ss.Width, (int)ss.Height);
    }
}