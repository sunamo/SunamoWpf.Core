namespace SunamoWpf;

public class StatusesLogger
{
    // TODO: Merge with public class ThisApp

    TextBlock tb = null;
    public StatusesLogger(TextBlock textBlock)
    {
        this.tb = textBlock;
    }

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