namespace SunamoWpf._public;

/// <summary>
/// Represents the TU wpf t u type.
/// </summary>
public class TUWpf<T, U>
{
    /// <summary>
    /// The key.
    /// </summary>
    public T Key;
    /// <summary>
    /// The value.
    /// </summary>
    public U Value;

    /// <summary>
    /// Initializes a new instance of the TU wpf class.
    /// </summary>
    public TUWpf()
    {
    }

    /// <summary>
    /// Initializes a new instance of the TU wpf class.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <param name="value">The value.</param>
    public TUWpf(T key, U value)
    {
        Key = key;
        Value = value;
    }

    /// <summary>
    /// Get.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <param name="value">The value.</param>
    /// <returns>The get result.</returns>
    public static TUWpf<T, U> Get(T key, U value)
    {
        return new TUWpf<T, U>(key, value);
    }
}