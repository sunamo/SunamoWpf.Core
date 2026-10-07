#define ASYNC
/// <summary>
/// Replacement for TextBlockHelperBase
/// Hyperlink is clickable
/// </summary>
public class InlineBuilderBlock : InlineBuilder
{
    /// <summary>
    /// Block put into FlowDocument.Blocks
    /// </summary>
    /// <param name="paragraph"></param>
    public InlineBuilderBlock(Paragraph paragraph) : base(paragraph.Inlines)
    {
    }
}
