namespace SunamoWpf._public;

/// <summary>
/// Represents the t with name t wpf t type.
/// </summary>
public class TWithNameTWpf<T>
{
    /// <summary>
    ///     Just first 5. letters
    /// </summary>
    public string name = string.Empty;

    /// <summary>
    /// The t.
    /// </summary>
    public T t;

    /// <summary>
    /// Initializes a new instance of the t with name t wpf class.
    /// </summary>
    public TWithNameTWpf()
    {
    }

    /// <summary>
    /// Initializes a new instance of the t with name t wpf class.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <param name="value">The value.</param>
    public TWithNameTWpf(string name, T value)
    {
        this.name = name;
        this.t = value;
    }

    /// <summary>
    /// To string.
    /// </summary>
    /// <returns>The to string result.</returns>
    public override string ToString()
    {
        return name;
    }

    /// <summary>
    /// Get.
    /// </summary>
    /// <param name="nameCb">The name cb.</param>
    /// <returns>The get result.</returns>
    public static TWithNameTWpf<T> Get(string nameCb)
    {
        return new TWithNameTWpf<T> { name = nameCb };
    }
}