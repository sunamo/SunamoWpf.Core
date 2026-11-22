namespace SunamoWpf._shared;

/// <summary>
/// Represents the status helper type.
/// </summary>
public partial class StatusHelper
{
    /// <summary>
    /// Get background brush of type of message.
    /// </summary>
    /// <param name="typeOfMessage">The type of message.</param>
    /// <returns>The get background brush of type of message result.</returns>
    public static Color GetBackgroundBrushOfTypeOfMessage(TypeOfMessageWpf typeOfMessage)
    {
        //return Colors.White;
        switch (typeOfMessage)
        {
            case TypeOfMessageWpf.Error:
                return Colors.LightCoral;
            case TypeOfMessageWpf.Warning:
                return Colors.LightYellow;
            case TypeOfMessageWpf.Information:
                return Colors.White;
            case TypeOfMessageWpf.Ordinal:
                return Colors.White;
            case TypeOfMessageWpf.Appeal:
                return Colors.LightGray;
            case TypeOfMessageWpf.Success:
                return Colors.LightGreen;
            default:
                return Colors.White;
        }
    }
}