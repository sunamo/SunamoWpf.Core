namespace SunamoWpf;

/// <summary>
/// Represents the statuses logger type.
/// </summary>
public class StatusesLogger
{
    // TODO: Merge with public class ThisApp

    TextBlock tb = null;
    /// <summary>
    /// Initializes a new instance of the statuses logger class.
    /// </summary>
    /// <param name="textBlock">The text block.</param>
    public StatusesLogger(TextBlock textBlock)
    {
        this.tb = textBlock;
    }

    /// <summary>
    /// Warning.
    /// </summary>
    /// <param name="mes">The mes.</param>
    public void Warning(string mes)
    {
        WriteWithColor(Brushes.Orange, mes);
    }

    private void WriteWithColor(Brush color, string mes)
    {
        string timedMessage = DTHelper.AppendToFrontOnlyTime(mes);
        tb.Foreground = color;
        tb.Text = timedMessage;
    }
}