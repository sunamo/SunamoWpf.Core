namespace SunamoWpf._public;

/// <summary>
/// Represents the i control with result wpf type.
/// </summary>
public interface IControlWithResultWpf
{




    /// <summary>
    /// The change dialog result.
    /// </summary>
    event VoidBoolNullable ChangeDialogResult;





    /// <summary>
    /// Gets or sets the dialog result.
    /// </summary>
    bool? DialogResult { set; }

    /// <summary>
    /// Accept.
    /// </summary>
    /// <param name="input">The input.</param>
    void Accept(object input);
    /// <summary>
    /// Focus on main element.
    /// </summary>
    void FocusOnMainElement();

}