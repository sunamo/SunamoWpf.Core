namespace SunamoWpf._.Animation;

/// <summary>
/// Represents the limited timer type.
/// </summary>
public class LimitedTimer : SunamoTimer
{
    int pocet = 0;
    int odbylo = 0;

    /// <summary>
    /// Initializes a new instance of the limited timer class.
    /// </summary>
    /// <param name="milliseconds">The milliseconds.</param>
    /// <param name="pocet">The pocet.</param>
    /// <param name="action">The action.</param>
    public LimitedTimer(int milliseconds, int pocet, Action action) : base(milliseconds, action, false)
    {
        Tick += LimitedTimer_Tick;
        this.pocet = pocet;
    }

    private void LimitedTimer_Tick()
    {
        odbylo++;

        if (pocet == odbylo)
        {
            //////////DebugLogger.Instance.WriteLine(pocet.ToString());
            t.Stop();
        }
    }

    void t_Elapsed(object sender, System.Timers.ElapsedEventArgs eventArgs)
    {
        odbylo++;

        if (pocet == odbylo)
        {
            //////////DebugLogger.Instance.WriteLine(pocet.ToString());
            t.Stop();
        }


    }
}