namespace SunamoWpf.Data;

/// <summary>
/// Represents the font args type.
/// </summary>
public class FontArgs
{
    /// <summary>
    /// Initializes a new instance of the font args class.
    /// </summary>
    public FontArgs()
    {
        
    }

    /// <summary>
    /// Initializes a new instance of the font args class.
    /// </summary>
    /// <param name="fontFamily">The font family.</param>
    /// <param name="fontSize">The font size.</param>
    /// <param name="fontStyle">The font style.</param>
    /// <param name="fontStretch">The font stretch.</param>
    /// <param name="fontWeight">The font weight.</param>
    public FontArgs(FontFamily fontFamily, double fontSize, System.Windows.FontStyle fontStyle, FontStretch fontStretch, System.Windows.FontWeight fontWeight)
    {
        this.fontFamily = fontFamily;
        this.fontSize = fontSize;
        this.fontStretch = fontStretch;
        this.fontStyle = fontStyle;
        this.fontWeight = fontWeight;
    }

    /// <summary>
    /// Initializes a new instance of the font args class.
    /// </summary>
    /// <param name="fontArgs">The font args.</param>
    public FontArgs(FontArgs fontArgs)
    {
        this.fontFamily = fontArgs.fontFamily;
        this.fontSize = fontArgs.fontSize;
        this.fontStretch = fontArgs.fontStretch;
        this.fontStyle = fontArgs.fontStyle;
        this.fontWeight = fontArgs.fontWeight;
    }

    /// <summary>
    /// The font family.
    /// </summary>
    public FontFamily fontFamily = null;
    /// <summary>
    /// The font size.
    /// </summary>
    public double fontSize = 0;
    /// <summary>
    /// The font style.
    /// </summary>
    public FontStyle fontStyle = FontStyles.Normal;
    /// <summary>
    /// Hodnota mezi 1-9, průměrná je 5
    /// </summary>
    public FontStretch fontStretch = FontStretch.FromOpenTypeStretch(5);
    /// <summary>
    /// The font weight.
    /// </summary>
    public System.Windows.FontWeight fontWeight = new System.Windows.FontWeight();

    /// <summary>
    /// Default run.
    /// </summary>
    /// <returns>The default run result.</returns>
    public static FontArgs DefaultRun()
    {
        Run run = new Run();
        return new FontArgs(run.FontFamily, run.FontSize, run.FontStyle, run.FontStretch, run.FontWeight);
    }
}