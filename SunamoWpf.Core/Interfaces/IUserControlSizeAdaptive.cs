namespace SunamoWpf.Interfaces;

/// <summary>
/// UC which dynamically change size when windows.
/// </summary>
public interface IUserControlSizeAdaptive
{
    /// <summary>
    /// Set size.
    /// </summary>
    /// <param name="width">The width.</param>
    /// <param name="height">The height.</param>
    void SetSize(double width, double height);
}