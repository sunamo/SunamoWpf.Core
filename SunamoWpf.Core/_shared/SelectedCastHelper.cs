namespace SunamoWpf._shared;

public class SelectedCastHelper<T> : ISelectedTWpf<T>
{
    private ISelectedTWpf<T> _selected = null;

    internal SelectedCastHelper(ISelectedTWpf<T> selected)
    {
        _selected = selected;
    }

    public T SelectedItem => _selected.SelectedItem;
}