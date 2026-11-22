namespace SunamoWpf;

/// <summary>
/// Represents the image with path type.
/// </summary>
[System.Runtime.Versioning.SupportedOSPlatform("windows")]
public class ImageWithPath
{
    /// <summary>
    /// The path.
    /// </summary>
    public string path = "";
    /// <summary>
    /// The image.
    /// </summary>
    public System.Drawing.Image image = null;

    /// <summary>
    /// Initializes a new instance of the image with path class.
    /// </summary>
    /// <param name="path">The path.</param>
    public ImageWithPath(string path)
    {
        this.path = path;
        image = System.Drawing.Image.FromFile(path);
    }

    /// <summary>
    /// Initializes a new instance of the image with path class.
    /// </summary>
    /// <param name="path">The path.</param>
    /// <param name="image">The image.</param>
    public ImageWithPath(string path, System.Drawing.Image image)
    {
        this.path = path;
        this.image = image;
    }

    /// <summary>
    /// To string.
    /// </summary>
    /// <returns>The to string result.</returns>
    public override string ToString()
    {
        return path;
    }
}