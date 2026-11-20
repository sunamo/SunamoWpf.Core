namespace SunamoWpf.Data;

/// <summary>
/// Represents the sunamo point type.
/// </summary>
public class SunamoPoint
{
    /// <summary>
    /// Initializes a new instance of the sunamo point class.
    /// </summary>
    public SunamoPoint()
    {
    }

    /// <summary>
    /// Initializes a new instance of the sunamo point class.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <param name="y">The y.</param>
    public SunamoPoint(double x, double y)
    {
        X = x;
        Y = y;
    }

    /// <summary>
    /// Gets or sets the x.
    /// </summary>
    public double X { get; set; }
    /// <summary>
    /// Gets or sets the y.
    /// </summary>
    public double Y { get; set; }

    /// <summary>
    /// Parse.
    /// </summary>
    /// <param name="input">The input.</param>
    public void Parse(string input)
    {
        var parts = input.Split(',');
        //ParserTwoValues.ParseDouble(",", SHParts.RemoveAfterFirstFunc(input, char.IsLetter, new char[] { ',' }));
        X = double.Parse(parts[0]);

        Y = double.Parse(parts[1]);
    }

    /// <summary>
    /// To string.
    /// </summary>
    /// <returns>The to string result.</returns>
    public override string ToString()
    {
        //return ParserTwoValues.ToString(",", X.ToString(), Y.ToString());
        return X + "," + Y;
    }

    /// <summary>
    /// To system windows.
    /// </summary>
    /// <returns>The to system windows result.</returns>
    public object ToSystemWindows()
    {
        throw new NotImplementedException();
    }
}