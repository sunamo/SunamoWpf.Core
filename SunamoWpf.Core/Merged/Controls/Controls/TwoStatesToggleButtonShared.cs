#define ASYNC
namespace SunamoWpf.Controls.Controls;

public static partial class TwoStatesToggleButton{

    static Dictionary<ToggleButton, bool?> previousCheched = new Dictionary<ToggleButton, bool?>();
    public static bool IsChecked(ToggleButton tb)
    {
        return previousCheched[tb].Value;
    } 
}