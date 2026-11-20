namespace SunamoWpf._public;

/// <summary>
/// Represents the t with name wpf type.
/// </summary>
public class TWithNameWpf
{
    /// <summary>
    /// Get.
    /// </summary>
    /// <param name="nameCb">The name cb.</param>
    /// <returns>The get result.</returns>
    public static TWithNameTWpf<object> Get(string nameCb)
    {
        return new TWithNameTWpf<object> { name = nameCb };
    }
}