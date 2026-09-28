namespace SunamoWpf.Interfaces;

/// <summary>
/// UC which dynamically change size when windows.
/// </summary>
public interface IUserControlSizeAdaptive
{
    void SetSize(double width, double height);
}