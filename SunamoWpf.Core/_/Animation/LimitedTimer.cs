namespace SunamoWpf._.Animation;

public class LimitedTimer : SunamoTimer
{
    int pocet = 0;
    int odbylo = 0;

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