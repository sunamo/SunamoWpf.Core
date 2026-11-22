/// <summary>
/// Represents the i identificator desktop t type.
/// </summary>
public interface IIdentificatorDesktop<T> : IIdentificatorT<T>
{
    /// <summary>
    /// Gets or sets the visibility.
    /// </summary>
    Visibility Visibility { get; set; }
}
