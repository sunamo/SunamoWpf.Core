namespace SunamoWpf._public;

/// <summary>
/// Represents the TU list wpf t u type.
/// </summary>
public class TUListWpf<T, U> : List<TUWpf<T, U>>
{
    /// <summary>
    /// Gets the list.
    /// </summary>
    public List<TUWpf<T, U>> list => this;
}