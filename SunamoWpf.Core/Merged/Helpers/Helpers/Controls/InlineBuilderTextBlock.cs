#define ASYNC
namespace SunamoWpf.Helpers.Controls;

/// <summary>
/// Represents the inline builder text block type.
/// </summary>
public class InlineBuilderTextBlock : InlineBuilder
{
    /// <summary>
    /// The tb.
    /// </summary>
    public TextBlock tb = null;

    /// <summary>
    /// Initializes a new instance of the inline builder text block class.
    /// </summary>
    /// <param name="textBlock">The text block.</param>
    public InlineBuilderTextBlock(TextBlock textBlock) : base(textBlock.Inlines)
    {
        this.tb = textBlock;
    }

    /// <summary>
    /// Initializes a new instance of the inline builder text block class.
    /// </summary>
    public InlineBuilderTextBlock()
    {
        tb = new TextBlock();
        inlines = tb.Inlines;
    }
}