namespace SunamoWpf._shared;

/// <summary>
/// Represents the i identificator t t type.
/// </summary>
public interface IIdentificatorT<T>
{
    /// <summary>
    /// Gets or sets the id.
    /// </summary>
    T Id { get; set; }
    /// <summary>
    /// Gets or sets the is checked.
    /// </summary>
    bool IsChecked { get; set; }
    /// <summary>
    /// Gets or sets the is selected.
    /// </summary>
    bool IsSelected { get; set; }
}