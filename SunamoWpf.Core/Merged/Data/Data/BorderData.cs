namespace SunamoWpf.Data;

/// <summary>
/// Represents the border data type.
/// </summary>
public class BorderData
{
    /// <summary>
    /// The border thickness.
    /// </summary>
    public Thickness BorderThickness;
    /// <summary>
    /// The border brush.
    /// </summary>
    public Brush BorderBrush;

    /// <summary>
    /// Initializes a new instance of the border data class.
    /// </summary>
    /// <param name="borderBrush">The border brush.</param>
    /// <param name="borderThickness">The border thickness.</param>
    public BorderData(Brush borderBrush, int borderThickness)
    {
        BorderThickness = new Thickness(borderThickness);
        BorderBrush = borderBrush;
    }

    /// <summary>
    /// Initializes a new instance of the border data class.
    /// </summary>
    /// <param name="borderBrush">The border brush.</param>
    /// <param name="borderThickness">The border thickness.</param>
    public BorderData(Brush borderBrush, Thickness borderThickness)
    {
        BorderThickness = borderThickness;
        BorderBrush = borderBrush;
    }

    /// <summary>
    /// Thickness.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>The thickness result.</returns>
    public static Thickness Thickness(double value)
    {
        return new Thickness(value);
    }

    /// <summary>
    /// The none.
    /// </summary>
    public static readonly BorderData None = new BorderData(Brushes.Beige, 0);
    /// <summary>
    /// The black 1.
    /// </summary>
    public static readonly BorderData Black1 = new BorderData(Brushes.Black, Thickness(1));
}