#define ASYNC
namespace SunamoWpf.Helpers.Controls;

/// <summary>
/// Represents the progress bar helper time type.
/// </summary>
public class ProgressBarHelperTime
{
    ProgressBarHelper pbh = null;
    /// <summary>
    /// The ai.
    /// </summary>
    public double ai = 0;
    double allSecondsMinusOne = 0;
    System.Timers.Timer t2 = null;
    /// <summary>
    /// Initializes a new instance of the progress bar helper time class.
    /// </summary>
    /// <param name="progressBar">The progress bar.</param>
    /// <param name="allSeconds">The all seconds.</param>
    /// <param name="uiElement">The ui element.</param>
    public ProgressBarHelperTime(System.Windows.Controls.ProgressBar progressBar, double allSeconds, UIElement uiElement)
    {
        pbh = new ProgressBarHelper(progressBar, allSeconds, uiElement);
        allSecondsMinusOne = allSeconds - 1;
        t2 = new System.Timers.Timer();
        t2.AutoReset = true;
        t2.Interval = 1000;
        t2.Elapsed += T2_Elapsed;
        t2.Start();
    }
    private void T2_Elapsed(object sender, System.Timers.ElapsedEventArgs eventArgs)
    {
        pbh.DonePartially();
        ai++;
        if (ai == allSecondsMinusOne)
        {
            t2.Stop();
        }
    }
}