namespace SunamoWpf.SunamoDebugging.Interfaces;

public interface IFoundedResultUC
{
    UIElement SecondRow { set; }

    event VoidString Selected;

    bool Contains(Regex regex, string text);
    bool Contains(string text);
    // musí to tu být?
    //void InitializeComponent();
}