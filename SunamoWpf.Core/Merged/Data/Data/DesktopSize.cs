namespace SunamoWpf.Data;

/// <summary>
/// Represents the desktop size type.
/// </summary>
public class DesktopSize
{
    /// <summary>
    /// Gets the width.
    /// </summary>
    public double Width { get => s.Width; }
    System.Windows.Size s = new Size();

    /// <summary>
    /// Initializes a new instance of the desktop size class.
    /// </summary>
    public DesktopSize()
    {

    }

    /// <summary>
    /// Initializes a new instance of the desktop size class.
    /// </summary>
    /// <param name="eventArgs">The event args.</param>
    public DesktopSize(SizeChangedEventArgs eventArgs)
    {
        s.Width = eventArgs.NewSize.Width;
        s.Height = eventArgs.NewSize.Height;
    }

    /// <summary>
    /// Initializes a new instance of the desktop size class.
    /// </summary>
    /// <param name="actualWidth">The actual width.</param>
    /// <param name="actualHeight">The actual height.</param>
    public DesktopSize(double actualWidth, double actualHeight)
    {
        s.Width = actualWidth;
        s.Height = actualHeight;
    }

    /// <summary>
    /// Gets the height.
    /// </summary>
    public double Height { get => s.Height; }

    /// <summary>
    /// To sunamo size.
    /// </summary>
    /// <returns>The to sunamo size result.</returns>
    public SunamoSize ToSunamoSize()
    {
        throw new NotImplementedException();
    }
}