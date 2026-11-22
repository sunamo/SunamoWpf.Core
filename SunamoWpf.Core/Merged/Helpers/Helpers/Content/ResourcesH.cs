#define ASYNC
namespace SunamoWpf.Helpers.Content;

/// <summary>
/// Represents the resources h type.
/// </summary>
public class ResourcesH : IResourceHelperWpf
{
    /// <summary>
    /// The ci.
    /// </summary>
    public static ResourcesH ci = new ResourcesH();

    private ResourcesH()
    {

    }

    /// <summary>
    /// Get relative uri.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <returns>The get relative uri result.</returns>
    public Uri GetRelativeUri(string name)
    {
        if (name.EndsWith(".ico"))
        {

        }
        var name2 = SH.PrefixIfNotStartedWith(name, "/");
        return new Uri(name2, UriKind.Relative);
    }

    /// <summary>
    /// Get bitmap image source.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <returns>The get bitmap image source result.</returns>
    public BitmapImage GetBitmapImageSource(string name)
    {
        return new BitmapImage(GetRelativeUri(name));
    }

    /// <summary>
    /// Get string.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <returns>The get string result.</returns>
    public string GetString(string name)
    {
        return Encoding.UTF8.GetString(FS.StreamToArrayBytes(GetStream(name)));
    }

    /// <summary>
    /// Get stream.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <returns>The get stream result.</returns>
    public Stream GetStream(string name)
    {
        var uri = GetRelativeUri(name);
        StreamResourceInfo info = Application.GetResourceStream(uri);
        return info.Stream;
    }
}