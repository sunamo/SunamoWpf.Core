#define ASYNC
namespace SunamoWpf.Controls.Controls;

public static partial class TwoStatesToggleButton
{
    
    public static int Count
    {
        get
        {
            return previousCheched.Count;
        }
    }

    public static void SetInitialChecked(ToggleButton toggleButton, bool check)
    {
        toggleButton.IsChecked = check;
        if (!previousCheched.ContainsKey(toggleButton))
        {
            previousCheched.Add(toggleButton, check);
        }
        else
        {
            ThrowEx.Custom(Translate.FromKey(XlfKeys.YouCannotCallSetInitialCheckedTwiceForTheSameToggleButton));
        }
    }

    static Type type = typeof(TwoStatesToggleButton);

    /// <summary>
    /// musí se volat vždy jako první věc v metodě Click
    /// </summary>
    /// <param name = "toggleButton"></param>
    public static void AfterClick(ToggleButton toggleButton)
    {
        bool save = !((bool)previousCheched[toggleButton]);
        previousCheched[toggleButton] = save;
        //}
        toggleButton.IsChecked = save;
    }

}