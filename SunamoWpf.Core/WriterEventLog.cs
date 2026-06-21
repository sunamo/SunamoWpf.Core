namespace SunamoWpf;

public static partial class WriterEventLog
{
    /// <summary>
    /// EN: Requires admin rights. Name parameter is required.
    /// CZ: Potřebuje admin práva. Parametr name je povinný.
    /// </summary>
    public static void DeleteMainAppLog(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Event log name cannot be null or empty", nameof(name));
        }

        if (EventLog.Exists(name))
        {
            EventLog.Delete(name);
        }
    }
}