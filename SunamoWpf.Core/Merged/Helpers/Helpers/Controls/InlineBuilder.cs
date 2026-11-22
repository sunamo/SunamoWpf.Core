#define ASYNC
namespace SunamoWpf.Helpers.Controls;

/// <summary>
/// Represents the inline builder type.
/// </summary>
public class InlineBuilder : InlineBuilderBase, IInlineBuilder
{
    /// <summary>
    /// The inlines.
    /// </summary>
    public InlineCollection inlines = null;
    static Dictionary<int, double> averageNumberWidthOnFontSize = new Dictionary<int, double>();
    static Dictionary<int, double> averageCharWidthOnFontSize = new Dictionary<int, double>();
    /// <summary>
    /// Initializes a new instance of the inline builder class.
    /// </summary>
    /// <param name="inlines">The inlines.</param>
    public InlineBuilder(InlineCollection inlines)
    {
        this.inlines = inlines;
    }
    /// <summary>
    /// Initializes a new instance of the inline builder class.
    /// </summary>
    public InlineBuilder()
    {
    }
    /// <summary>
    /// The fa.
    /// </summary>
    public FontArgs fa = FontArgs.DefaultRun();
    /// <summary>
    /// Divide string to rows.
    /// </summary>
    /// <param name="fontArgs">The font args.</param>
    /// <param name="text">The text.</param>
    /// <param name="maxSize">The max size.</param>
    public void DivideStringToRows(FontArgs fontArgs, string text, Size maxSize)
    {
        List<string> rows = FontHelper.DivideStringToRows(fontArgs.fontFamily, fontArgs.fontSize, fontArgs.fontStyle, fontArgs.fontStretch, fontArgs.fontWeight, text, maxSize);
        foreach (var item in rows)
        {
            inlines.Add(GetRun(item, fontArgs));
            inlines.Add(new LineBreak());
        }
    }
    /// <summary>
    /// Bold.
    /// </summary>
    /// <param name="text">The text.</param>
    public void Bold(string text)
    {
        FontArgs fontArgs = FontArgs.DefaultRun();
        fontArgs.fontWeight = GetFontWeight(SunamoWpf.Enums.FontWeights.bold);
        inlines.Add(GetBold(text, fontArgs));
    }
    /// <summary>
    /// Hyperlink.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <param name="uri">The uri.</param>
    public void Hyperlink(string text, string uri)
    {
        var run = GetHyperlink(text, uri, fa);
        inlines.Add(run);
    }
    /// <summary>
    /// Return null but also add it
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public void Run(string text)
    {
        Run run = GetRun(text, fa);
        inlines.Add(run);
    }
    /// <summary>
    /// H 1.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <param name="maxWidth">The max width.</param>
    public void H1(string text, double maxWidth)
    {
        Bold bold = new Bold();
        FontArgs fontArgs = FontArgs.DefaultRun();
        fontArgs.fontSize = HeaderSize.h1;
        //b.FontSize = 40;
        bold.Inlines.Add(new LineBreak());
        //b.Inlines.Add(GetRun(text, fa));
        DivideStringToRows(fontArgs, text, new Size(maxWidth, double.PositiveInfinity));
        bold.Inlines.Add(new LineBreak());
        bold.Inlines.Add(new LineBreak());
        inlines.Add(bold);
    }
    /// <summary>
    /// H 1.
    /// </summary>
    /// <param name="text">The text.</param>
    public void H1(string text)
    {
        Bold bold = new Bold();
        FontArgs fontArgs = FontArgs.DefaultRun();
        fontArgs.fontSize = HeaderSize.h1;
        //b.FontSize = 40;
        bold.Inlines.Add(new LineBreak());
        bold.Inlines.Add(GetRun(text, fontArgs));
        bold.Inlines.Add(new LineBreak());
        bold.Inlines.Add(new LineBreak());
        inlines.Add(bold);
    }
    /// <summary>
    /// H 2.
    /// </summary>
    /// <param name="text">The text.</param>
    public void H2(string text)
    {
        Bold bold = new Bold();
        FontArgs fontArgs = FontArgs.DefaultRun();
        //fa.fontSize = 50;
        fontArgs.fontSize = HeaderSize.h2;
        bold.Inlines.Add(new LineBreak());
        bold.Inlines.Add(GetRun(text, fontArgs));
        bold.Inlines.Add(new LineBreak());
        bold.Inlines.Add(new LineBreak());
        inlines.Add(bold);
    }
    /// <summary>
    /// H 3.
    /// </summary>
    /// <param name="text">The text.</param>
    public void H3(string text)
    {
        Italic italic = new Italic();
        FontArgs fontArgs = FontArgs.DefaultRun();
        fontArgs.fontSize = HeaderSize.h3;
        //b.FontSize = 30;
        italic.Inlines.Add(new LineBreak());
        italic.Inlines.Add(GetRun(text, fontArgs));
        italic.Inlines.Add(new LineBreak());
        italic.Inlines.Add(new LineBreak());
        inlines.Add(italic);
    }
    /// <summary>
    /// Tato Metoda nefunguje, protože Paragraph je odvozený od Block a ne od Inline 
    /// </summary>
    /// <param name = "italic"></param>
    //public void AddParagraph(Inline italic)
    //{
    //}
    public void LineBreak()
    {
        inlines.Add(new LineBreak());
    }
    /// <summary>
    /// Key value.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <param name="value">The value.</param>
    public void KeyValue(string key, string value)
    {
        if (!string.IsNullOrWhiteSpace(value))
        {
            value = value.Trim();
            key = key.Trim();
            if (value != "" && key != "")
            {
                Bold(key);
                Run(" " + value);
                LineBreak();
            }
        }
    }
    /// <summary>
    /// Error.
    /// </summary>
    /// <param name="text">The text.</param>
    public void Error(string text)
    {
        inlines.Add(GetError(text, FontArgs.DefaultRun()));
        LineBreak();
    }
    /// <summary>
    /// Bullet.
    /// </summary>
    /// <param name="text">The text.</param>
    public void Bullet(string text)
    {
        Inline inline = GetBullet(text, fa);
        //il.Foreground = new SolidColorBrush(Colors.Black);
        inlines.Add(inline);
        LineBreak();
    }
    /// <summary>
    /// Italic.
    /// </summary>
    /// <param name="text">The text.</param>
    public void Italic(string text)
    {
        inlines.Add(GetItalic(text, fa));
    }
    /// <summary>
    /// Divide string to rows.
    /// </summary>
    /// <param name="fontFamily">The font family.</param>
    /// <param name="fontSize">The font size.</param>
    /// <param name="fontStyle">The font style.</param>
    /// <param name="fontStretch">The font stretch.</param>
    /// <param name="fontWeight">The font weight.</param>
    /// <param name="text">The text.</param>
    /// <param name="maxSize">The max size.</param>
    public void DivideStringToRows(FontFamily fontFamily, double fontSize, FontStyle fontStyle, FontStretch fontStretch, System.Windows.FontWeight fontWeight, string text, Size maxSize)
    {
        FontArgs fontArgs = new FontArgs(fontFamily, fontSize, fontStyle, fontStretch, fontWeight);
        DivideStringToRows(fontArgs, text, maxSize);
    }
}