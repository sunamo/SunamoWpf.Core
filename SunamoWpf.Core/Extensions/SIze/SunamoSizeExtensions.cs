namespace SunamoWpf.Extensions.SIze;

public static partial class SunamoSizeExtensions
{
    public static System.Drawing.Size ToSystemDrawing(this SunamoSize size)
    {
        return new System.Drawing.Size((int)size.Width, (int)size.Height);
    }
}