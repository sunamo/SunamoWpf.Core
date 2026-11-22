namespace SunamoWpf.Data;

/// <summary>
/// Represents the t with size in string t type.
/// </summary>
public class TWithSizeInString<T>
{
    /// <summary>
    /// The size s.
    /// </summary>
    public string sizeS = "";
    /// <summary>
    /// The t.
    /// </summary>
    public T t = default;

    /// <summary>
    /// To string.
    /// </summary>
    /// <returns>The to string result.</returns>
    public override string ToString()
    {
        return t + " (" + sizeS + ")";
    }
}