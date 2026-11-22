#define ASYNC
namespace SunamoWpf.Helpers.Controls;

/// <summary>
/// Represents the WRTBH type.
/// </summary>
public class WRTBH : InlineBuilderBase
{
    FontArgs fa = null;
    Thickness margin = new Thickness(0);
    Thickness padding = new Thickness(0, 1, 5, 1);
    double maxWidth = 0;
    double paddingLeftFirst = 0;
    bool nextIsFirts = true;
    double width = 0;
    /// <summary>
    /// The uis.
    /// </summary>
    public List<StackPanel> uis = new List<StackPanel>();
    /// <summary>
    /// Initializes a new instance of the WRTBH class.
    /// </summary>
    /// <param name="maxWidth">The max width.</param>
    /// <param name="paddingLeftFirst">The padding left first.</param>
    /// <param name="fontArgs">The font args.</param>
    public WRTBH(double maxWidth, double paddingLeftFirst, FontArgs fontArgs)
    {
        this.fa = fontArgs;
        this.paddingLeftFirst = paddingLeftFirst;
        this.maxWidth = maxWidth;
        uis.Add(NewStackPanel());
    }
    private StackPanel NewStackPanel()
    {
        StackPanel stackPanel = new StackPanel();
        stackPanel.Orientation = Orientation.Horizontal;
        return stackPanel;
    }
    /// <summary>
    /// Run.
    /// </summary>
    /// <param name="text">The text.</param>
    public void Run(string text)
    {
        var slova = GetWords(text);
        foreach (var item in slova)
        {
            Add(GetTextBlock(GetRun(item, fa)));
        }
    }
    private List<string> GetWords(string text)
    {
        return SHSplit.SplitNone(text, " ");
    }
    /// <summary>
    /// Automaticky přidá jednomezerový run za hyperlink
    /// </summary>
    /// <param name="text"></param>
    /// <param name="uri"></param>
    public void Hyperlink(string text, string uri)
    {
        Add(GetTextBlock(GetHyperlink(text, uri, fa)));
        //Add(GetRichTextBlock( GetHyperlink(text, uri, margin, padding, fa)));
        Add(GetTextBlock(GetRun(" ", fa)));
    }
    /// <summary>
    /// Bold.
    /// </summary>
    /// <param name="text">The text.</param>
    public void Bold(string text)
    {
        var slova = GetWords(text);
        foreach (var item in slova)
        {
            Add(GetTextBlock(GetBold(item + "  ", fa)));
        }
    }
    private TextBlock GetTextBlock(Inline inline)
    {
        TextBlock txt = new TextBlock();
        txt.Inlines.Add(inline);
        txt.Padding = padding;
        txt.Margin = margin;
        return txt;
    }
    private void Add(TextBlock textBlock)
    {
        MeasureStringArgs msa = texts[texts.Count - 1];
        double width2 = SHWithControls.MeasureString(msa.fontFamily, msa.fontSize, msa.fontStyle, msa.fontStretch, msa.fontWeight, msa.text, new Size(textBlock.ActualWidth, textBlock.ActualHeight));
        double width3 = width + width2 + padding.Right;
        if (nextIsFirts)
        {
            textBlock.Padding = new Thickness(textBlock.Padding.Left + paddingLeftFirst, textBlock.Padding.Top, textBlock.Padding.Right, textBlock.Padding.Bottom);
            nextIsFirts = false;
        }
        if (maxWidth < width3)
        {
            width = 0;
            uis.Add(NewStackPanel());
            textBlock.Padding = new Thickness(textBlock.Padding.Left + paddingLeftFirst, textBlock.Padding.Top, textBlock.Padding.Right, textBlock.Padding.Bottom);
        }
        else
        {
            width = width3;
        }
        var last = uis[uis.Count - 1];
        last.Children.Add(textBlock);
    }
    /// <summary>
    /// Line break.
    /// </summary>
    public void LineBreak()
    {
        nextIsFirts = true;
        uis.Add(NewStackPanel());
        //Add(GetTextBlock(GetLineBreak()));
    }
    /// <summary>
    /// Italic.
    /// </summary>
    /// <param name="text">The text.</param>
    public void Italic(string text)
    {
        var slova = GetWords(text);
        foreach (var item in slova)
        {
            Add(GetTextBlock(GetItalic(item + "  ", fa)));
        }
    }
}