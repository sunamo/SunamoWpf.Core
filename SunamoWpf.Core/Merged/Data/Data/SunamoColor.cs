namespace SunamoWpf.Data;

public class SunamoColor
{
    public SunamoColor()
    {
    }

    public SunamoColor(byte alpha, byte red, byte green, byte blue)
    {
        A = alpha;
        R = red;
        G = green;
        B = blue;
    }


    public byte A { get; set; }
    public byte R { get; set; }
    public byte G { get; set; }
    public byte B { get; set; }

    public override string ToString()
    {
        // System.Windows.Media.Color = #00000000
        // System.Drawing.Color = Color [A=0, R=0, G=0, B=0]

        //
        //throw new Exception("StringHexColorConverter jsem musel přesunout protože je na wf a můžu jen wpf");
        return StringHexColorConverter.ConvertTo(this.ToSystemDrawing());
    }
}