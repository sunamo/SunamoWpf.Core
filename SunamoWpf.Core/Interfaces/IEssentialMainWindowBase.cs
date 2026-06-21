namespace SunamoWpf.Interfaces;

public interface IEssentialMainWindowBase
{
    void SetMode(object mode);
    string ModeString { get; }
}
