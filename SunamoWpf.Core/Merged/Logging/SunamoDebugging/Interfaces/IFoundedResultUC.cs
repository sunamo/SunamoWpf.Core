namespace SunamoWpf.SunamoDebugging.Interfaces;

public interface IFoundedResultUC
{
    UIElement SecondRow { set; }

    event VoidString Selected;

    bool Contains(Regex r, string text);
    bool Contains(string t);
    // musí to tu být?
    //void InitializeComponent();
}