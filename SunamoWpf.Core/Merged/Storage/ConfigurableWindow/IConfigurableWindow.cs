#define ASYNC
namespace SunamoWpf.ConfigurableWindow;

public interface IConfigurableWindow
{
    /// <summary>
    /// Derived classes must return the object which exposes 
    /// persisted window settings. This method is only invoked 
    /// once per Window, during construction.
    /// </summary>
    IConfigurableWindowSettings CreateSettings();
    ApplicationDataContainer data { get; set; }
    ConfigurableWindowWrapper configurableWindowWrapper { get; set; }
}