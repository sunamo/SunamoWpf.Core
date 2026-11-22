/// <summary>
/// Represents the i text blocks log type.
/// </summary>
public interface ITextBlocksLog
{
    /// <summary>
    /// Gets the tb last error or warning.
    /// </summary>
    TextBlock TbLastErrorOrWarning { get; }
    /// <summary>
    /// Gets the tb last other message.
    /// </summary>
    TextBlock TbLastOtherMessage { get; }

}
