public interface ITextBlocksLog
{
    TextBlock TbLastErrorOrWarning { get; }
    TextBlock TbLastOtherMessage { get; }

}
