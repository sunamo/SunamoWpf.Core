namespace SunamoWpf._public;


/// <summary>
/// Represents the i selected t wpf t type.
/// </summary>
public interface ISelectedTWpf<T>
{
    /// <summary>
    /// Gets the selected item.
    /// </summary>
    T SelectedItem { get; }
}