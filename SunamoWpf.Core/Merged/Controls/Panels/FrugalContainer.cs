#define ASYNC
namespace SunamoWpf.Controls.Panels;

/// <summary>
/// Represents the frugal container type.
/// </summary>
public class FrugalContainer : Decorator
{
    /// <summary>
    /// Initializes a new instance of the frugal container class.
    /// </summary>
    public FrugalContainer() : base()
    {

    }

    /// <summary>
    /// Measure override.
    /// </summary>
    /// <param name="availableSize">The available size.</param>
    /// <returns>The measure override result.</returns>
    protected override Size MeasureOverride(Size availableSize)
    {
        return new Size(0, 0);
    }

    /// <summary>
    /// Arrange override.
    /// </summary>
    /// <param name="arrangeSize">The arrange size.</param>
    /// <returns>The arrange override result.</returns>
    protected override Size ArrangeOverride(Size arrangeSize)
    {
        // get it all
        Child.Measure(arrangeSize);
        Child.Arrange(new Rect(arrangeSize));
        return Child.RenderSize;
    }
}