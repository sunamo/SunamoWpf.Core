namespace SunamoWpf;

/// <summary>
///     MainWindow_PreviewKeyDown
/// </summary>
/// <typeparam name="KeyArg"></typeparam>
public interface IKeysHandler<KeyArg>
{
    /*
    if (keysHandler != null)
    {
    if (keysHandler.HandleKey(e))
    {
    e.Handled = true;
    }
    else
    {
    }
    }
    */

    /// <summary>
    /// Handle key.
    /// </summary>
    /// <param name="keyArg">The key arg.</param>
    /// <returns>The handle key result.</returns>
    bool HandleKey(KeyArg keyArg);
}