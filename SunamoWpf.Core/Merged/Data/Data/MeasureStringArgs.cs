namespace SunamoWpf.Data;

public class MeasureStringArgs : FontArgs
{
    public MeasureStringArgs(FontFamily fontFamily, double fontSize, FontStyle fontStyle, FontStretch fontStretch, FontWeight fontWeight, string text)
    {
        this.fontFamily = fontFamily;
        this.fontSize = fontSize;
        this.fontStretch = fontStretch;
        this.fontStyle = fontStyle;
        this.fontWeight = fontWeight;
        this.text = text;
    }


    public string text = "";
    //Size maxSize = Constants.maxSize;
}