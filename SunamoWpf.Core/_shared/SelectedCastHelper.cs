namespace SunamoWpf._shared;

/// <summary>
/// Represents the selected cast helper t type.
/// </summary>
public class SelectedCastHelper<T> : ISelectedTWpf<T>
{
    private ISelectedTWpf<T> _selected = null;

    internal SelectedCastHelper(ISelectedTWpf<T> selected)
    {
        _selected = selected;
    }

    /// <summary>
    /// Gets the selected item.
    /// </summary>
    public T SelectedItem => _selected.SelectedItem;
}