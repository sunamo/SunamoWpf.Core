namespace SunamoWpf._shared;

public partial class StatusHelper
{
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