namespace SunamoWpf._shared;



public partial class StatusHelper
{
    /// <summary>
    /// Get foreground brush of type of message.
    /// </summary>
    /// <param name="typeOfMessage">The type of message.</param>
    /// <returns>The get foreground brush of type of message result.</returns>
    public static Color GetForegroundBrushOfTypeOfMessage(TypeOfMessageWpf typeOfMessage)
    {
        switch (typeOfMessage)
        {
            case TypeOfMessageWpf.Error:
                return Colors.DarkRed;
            case TypeOfMessageWpf.Warning:
                return Colors.DarkOrange;
            case TypeOfMessageWpf.Information:
                return Colors.Black;
            case TypeOfMessageWpf.Ordinal:
                return Colors.Black;
            case TypeOfMessageWpf.Appeal:
                return Colors.Gray;
            case TypeOfMessageWpf.Success:
                return Colors.LightGreen;
            default:
                return Colors.White;
        }
    }

}