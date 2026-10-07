#define ASYNC
namespace SunamoWpf.Helpers.Controls;

public class ProgressBarHelperTime
{
    ProgressBarHelper pbh = null;
    public double ai = 0;
    double allSecondsMinusOne = 0;
    System.Timers.Timer t2 = null;
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