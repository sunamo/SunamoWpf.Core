namespace SunamoWpf.Data;

public class BitmapImageWithPath
{
    public string path = "";
    public BitmapImage image = null;

    public BitmapImageWithPath(string path, BitmapImage image)
    {
        this.path = path;
        this.image = image;
    }

    public override string ToString()
    {
        return path;
    }
}