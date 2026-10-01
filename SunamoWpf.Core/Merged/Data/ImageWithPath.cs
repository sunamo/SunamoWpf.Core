namespace SunamoWpf;

[System.Runtime.Versioning.SupportedOSPlatform("windows")]
public class ImageWithPath
{
    public string path = "";
    public System.Drawing.Image image = null;

    public ImageWithPath(string path)
    {
        this.path = path;
        image = System.Drawing.Image.FromFile(path);
    }

    public ImageWithPath(string path, System.Drawing.Image image)
    {
        this.path = path;
        this.image = image;
    }

    public override string ToString()
    {
        return path;
    }
}