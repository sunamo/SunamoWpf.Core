#define ASYNC
namespace SunamoWpf.Controls.Controls;

/// <summary>
/// Represents the two states toggle button type.
/// </summary>
public static partial class TwoStatesToggleButton
{
    
    /// <summary>
    /// The count.
    /// </summary>
    public static int Count
    {
        get
        {
            return previousCheched.Count;
        }
    }

    /// <summary>
    /// Set initial checked.
    /// </summary>
    /// <param name="toggleButton">The toggle button.</param>
    /// <param name="check">The check.</param>
    public static void SetInitialChecked(ToggleButton toggleButton, bool check)
    {
        toggleButton.IsChecked = check;
        if (!previousCheched.ContainsKey(toggleButton))
        {
            previousCheched.Add(toggleButton, check);
        }
        else
        {
            ThrowEx.Custom("You cannot call set initial checked twice for the same toggle button");
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