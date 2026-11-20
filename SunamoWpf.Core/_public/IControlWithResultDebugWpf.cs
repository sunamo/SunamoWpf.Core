namespace SunamoWpf._public;

/// <summary>
/// Represents the i control with result debug wpf type.
/// </summary>
public interface IControlWithResultDebugWpf : IControlWithResultWpf
{
    /// <summary>
    /// Count of handlers change dialog result.
    /// </summary>
    /// <returns>The count of handlers change dialog result result.</returns>
    int CountOfHandlersChangeDialogResult();
    /// <summary>
    /// Attach change dialog result.
    /// </summary>
    /// <param name="handler">The handler.</param>
    /// <param name="throwException">The throw exception.</param>
    void AttachChangeDialogResult(VoidBoolNullable handler, bool throwException = true);
}