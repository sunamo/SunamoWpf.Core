#define ASYNC
namespace SunamoWpf.Helpers.Controls;

/// <summary>
/// Have StackPanel and NewTextBlock()
/// </summary>
public class ParagraphBuilderTextBlock : IInlineBuilder
{
    InlineBuilderTextBlock t = null;
    /// <summary>
    /// The padding.
    /// </summary>
    public Thickness padding = new Thickness();
    /// <summary>
    /// The margin.
    /// </summary>
    public Thickness margin = new Thickness();
    /// <summary>
    /// Initializes a new instance of the paragraph builder text block class.
    /// </summary>
    public ParagraphBuilderTextBlock()
    {
        sp.Orientation = Orientation.Vertical;
        NewTextBlock();
    }
    StackPanel sp = new StackPanel();
    /// <summary>
    /// New text block.
    /// </summary>
    public void NewTextBlock()
    {
        if (t != null)
        {
            sp.Children.Add(t.tb);
        }
        t = new InlineBuilderTextBlock();
    }
    /// <summary>
    /// Final.
    /// </summary>
    /// <returns>The final result.</returns>
    public StackPanel Final()
    {
        sp.Children.Add(t.tb);
        foreach (TextBlock item in sp.Children)
        {
            item.Margin = margin;
            item.Padding = padding;
        }
        return sp;
    }
    #region IInlineBuilder members
    /// <summary>
    /// Bold.
    /// </summary>
    /// <param name="text">The text.</param>
    public void Bold(string text)
    {
        t.Bold(text);
    }
    /// <summary>
    /// Bullet.
    /// </summary>
    /// <param name="text">The text.</param>
    public void Bullet(string text)
    {
        t.Bullet(text);
    }
    /// <summary>
    /// Error.
    /// </summary>
    /// <param name="text">The text.</param>
    public void Error(string text)
    {
        t.Error(text);
    }
    /// <summary>
    /// H 1.
    /// </summary>
    /// <param name="text">The text.</param>
    public void H1(string text)
    {
        t.H1(text);
    }
    /// <summary>
    /// H 1.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <param name="maxWidth">The max width.</param>
    public void H1(string text, double maxWidth)
    {
        t.H1(text, maxWidth);
    }
    /// <summary>
    /// H 2.
    /// </summary>
    /// <param name="text">The text.</param>
    public void H2(string text)
    {
        t.H2(text);
    }
    /// <summary>
    /// H 3.
    /// </summary>
    /// <param name="text">The text.</param>
    public void H3(string text)
    {
        t.H3(text);
    }
    /// <summary>
    /// Hyperlink.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <param name="uri">The uri.</param>
    public void Hyperlink(string text, string uri)
    {
        t.Hyperlink(text, uri);
    }
    /// <summary>
    /// Italic.
    /// </summary>
    /// <param name="text">The text.</param>
    public void Italic(string text)
    {
        t.Italic(text);
    }
    /// <summary>
    /// Key value.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <param name="value">The value.</param>
    public void KeyValue(string key, string value)
    {
        t.KeyValue(key, value);
    }
    /// <summary>
    /// Line break.
    /// </summary>
    public void LineBreak()
    {
        t.LineBreak();
    }
    /// <summary>
    /// Run.
    /// </summary>
    /// <param name="text">The text.</param>
    public void Run(string text)
    {
        t.Run(text);
    }
    #endregion
}