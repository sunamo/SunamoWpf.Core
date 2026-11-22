namespace SunamoWpf;

/// <summary>
/// Represents the i resource helper wpf type.
/// </summary>
public interface IResourceHelperWpf
{
    /// <summary>
    /// Get string.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <returns>The get string result.</returns>
    string GetString(string name);
    /// <summary>
    /// Get stream.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <returns>The get stream result.</returns>
    Stream GetStream(string name);
}