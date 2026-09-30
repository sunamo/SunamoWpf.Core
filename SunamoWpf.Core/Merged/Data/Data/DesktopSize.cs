namespace SunamoWpf.Data;

public class DesktopSize
{
    public double Width { get => s.Width; }
    System.Windows.Size s = new Size();

    public DesktopSize()
    {

    }

    public DesktopSize(SizeChangedEventArgs e)
    {
        s.Width = e.NewSize.Width;
        s.Height = e.NewSize.Height;
    }

    public DesktopSize(double actualWidth, double actualHeight)
    {
        s.Width = actualWidth;
        s.Height = actualHeight;
    }

    public double Height { get => s.Height; }

    public SunamoSize ToSunamoSize()
    {
        throw new NotImplementedException();
    }
}