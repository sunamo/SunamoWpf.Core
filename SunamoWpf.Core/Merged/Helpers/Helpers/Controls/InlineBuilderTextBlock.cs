#define ASYNC
namespace SunamoWpf.Helpers.Controls;

public class InlineBuilderTextBlock : InlineBuilder
{
    public TextBlock tb = null;

    public InlineBuilderTextBlock(TextBlock textBlock) : base(textBlock.Inlines)
    {
        this.tb = textBlock;
    }

    public InlineBuilderTextBlock()
    {
        tb = new TextBlock();
        inlines = tb.Inlines;
    }
}