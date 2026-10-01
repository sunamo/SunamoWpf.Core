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

    public static void SetInitialChecked(ToggleButton tb, bool check)
    {
        tb.IsChecked = check;
        if (!previousCheched.ContainsKey(tb))
        {
            previousCheched.Add(tb, check);
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
    /// <param name = "tb"></param>
    public static void AfterClick(ToggleButton tb)
    {
        bool save = !((bool)previousCheched[tb]);
        previousCheched[tb] = save;
        //}
        tb.IsChecked = save;
    }

}