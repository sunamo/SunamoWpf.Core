namespace SunamoWpf._shared;

using Timer = System.Timers.Timer;

/// <summary>
/// Represents the sunamo timer type.
/// </summary>
public class SunamoTimer
{
    private readonly Action a;
    /// <summary>
    /// The t.
    /// </summary>
    protected Timer t;
    internal SunamoTimer(int milliseconds, Action action, bool runImmediately)
    {
        t = new Timer(milliseconds);
        t.Elapsed += t_Elapsed;
        t.AutoReset = true;
        this.a = action;
        t.Start();
        if (runImmediately) t_Elapsed(null, null);
    }
    internal event Action Tick;
    private void t_Elapsed(object sender, ElapsedEventArgs eventArgs)
    {
        try
        {
            a.Invoke();
        }
        catch (Exception)
        {
            // often The calling thread cannot access this object because a different thread owns it.'
        }
        if (Tick != null) Tick();
    }
}