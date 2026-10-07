#define ASYNC
namespace SunamoWpf.Helpers.Controls;

/// <summary>
/// Have StackPanel and NewTextBlock()
/// </summary>
public class ParagraphBuilderTextBlock : IInlineBuilder
{
    InlineBuilderTextBlock t = null;
    public Thickness padding = new Thickness();
    public Thickness margin = new Thickness();
    public ParagraphBuilderTextBlock()
    {
        sp.Orientation = Orientation.Vertical;
        NewTextBlock();
    }
    StackPanel sp = new StackPanel();
    public void NewTextBlock()
    {
        if (t != null)
        {
            sp.Children.Add(t.tb);
        }
        t = new InlineBuilderTextBlock();
    }
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
    public void Bold(string text)
    {
        t.Bold(text);
    }
    public void Bullet(string text)
    {
        t.Bullet(text);
    }
    public void Error(string text)
    {
        t.Error(text);
    }
    public void H1(string text)
    {
        t.H1(text);
    }
    public void H1(string text, double maxWidth)
    {
        t.H1(text, maxWidth);
    }
    public void H2(string text)
    {
        t.H2(text);
    }
    public void H3(string text)
    {
        t.H3(text);
    }
    public void Hyperlink(string text, string uri)
    {
        t.Hyperlink(text, uri);
    }
    public void Italic(string text)
    {
        t.Italic(text);
    }
    public void KeyValue(string key, string value)
    {
        t.KeyValue(key, value);
    }
    public void LineBreak()
    {
        t.LineBreak();
    }
    public void Run(string text)
    {
        t.Run(text);
    }
    #endregion
}