namespace SunamoWpf.Interfaces;

/// <summary>
/// Represents the i resource helper desktop type.
/// </summary>
public interface IResourceHelperDesktop : IResourceHelperWpf
{

    /// <summary>
    /// Get bitmap image source.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <returns>The get bitmap image source result.</returns>
    BitmapImage GetBitmapImageSource(string name);

}