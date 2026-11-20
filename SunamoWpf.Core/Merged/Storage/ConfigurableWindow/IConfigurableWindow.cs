#define ASYNC
namespace SunamoWpf.ConfigurableWindow;

/// <summary>
/// Represents the i configurable window type.
/// </summary>
public interface IConfigurableWindow
{
    /// <summary>
    /// Derived classes must return the object which exposes 
    /// persisted window settings. This method is only invoked 
    /// once per Window, during construction.
    /// </summary>
    IConfigurableWindowSettings CreateSettings();
    /// <summary>
    /// Gets or sets the data.
    /// </summary>
    ApplicationDataContainer data { get; set; }
    /// <summary>
    /// Gets or sets the configurable window wrapper.
    /// </summary>
    ConfigurableWindowWrapper configurableWindowWrapper { get; set; }
}