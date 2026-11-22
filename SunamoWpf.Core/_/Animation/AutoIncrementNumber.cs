namespace SunamoWpf._.Animation;

/// <summary>
/// Represents the auto increment number type.
/// </summary>
public class AutoIncrementNumber
{
    /// <summary>
    /// The d.
    /// </summary>
    public double d = 0;
    double incO = 0;

    /// <summary>
    /// Initializes a new instance of the auto increment number class.
    /// </summary>
    /// <param name="incO">The inc o.</param>
    public AutoIncrementNumber(double incO)
    {
        this.incO = incO;
    }

    /// <summary>
    /// Increment.
    /// </summary>
    public void Increment()
    {
        d += incO;
    }
}