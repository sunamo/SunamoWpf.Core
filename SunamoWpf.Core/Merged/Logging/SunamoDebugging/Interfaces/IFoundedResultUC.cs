namespace SunamoWpf.SunamoDebugging.Interfaces;

/// <summary>
/// Represents the i founded result UC type.
/// </summary>
public interface IFoundedResultUC
{
    /// <summary>
    /// Gets or sets the second row.
    /// </summary>
    UIElement SecondRow { set; }

    /// <summary>
    /// The selected.
    /// </summary>
    event VoidString Selected;

    /// <summary>
    /// Contains.
    /// </summary>
    /// <param name="regex">The regex.</param>
    /// <param name="text">The text.</param>
    /// <returns>The contains result.</returns>
    bool Contains(Regex regex, string text);
    /// <summary>
    /// Contains.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <returns>The contains result.</returns>
    bool Contains(string text);
    // musí to tu být?
    //void InitializeComponent();
}