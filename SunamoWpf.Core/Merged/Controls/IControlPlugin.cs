#define ASYNC
namespace SunamoWpf.Interfaces;

/// <summary>
/// Represents the i control plugin type.
/// </summary>
public interface IControlPlugin
{
    /// <summary>
    /// Gets the root uc.
    /// </summary>
    List<SuMenuItem> RootUc { get; }
    /// <summary>
    /// Gets the mi uc.
    /// </summary>
    SuMenuItem MiUc { get; }
}