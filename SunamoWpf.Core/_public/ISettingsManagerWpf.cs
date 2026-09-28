namespace SunamoWpf._public;

public interface ISettingsManagerWpf<FrameworkElement, DependencyProperty>
{
    void AddFromSavedElements(TUListWpf<FrameworkElement, DependencyProperty> list);
    void LoadSettings(FrameworkElement sender, TUListWpf<FrameworkElement, DependencyProperty> savedElements);
    void SaveSettings(FrameworkElement sender, TUListWpf<FrameworkElement, DependencyProperty> savedElements);
}