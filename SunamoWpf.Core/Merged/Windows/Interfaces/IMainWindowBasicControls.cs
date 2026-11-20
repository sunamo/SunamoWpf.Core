#define ASYNC
namespace SunamoWpf.Interfaces;

/// <summary>
/// Uz to neimplementovat do kazde tridy ale pouzivat __ kde jsou tytez promenne staticke
/// Bude to setrit pamet
/// </summary>
public interface IMainWindowBasicControls
{
    /// <summary>
    /// The check box list UC.
    /// </summary>
    ICheckBoxListUC checkBoxListUC
    {
        get; set;
    }


    /// <summary>
    /// The select one value.
    /// </summary>
    SelectOneValue selectOneValue
    {
        get; set;
    }
    /// <summary>
    /// The radio buttons list.
    /// </summary>
    RadioButtonsList radioButtonsList
    {
        get; set;
    }
    /// <summary>
    /// The enter one value UC.
    /// </summary>
    EnterOneValueUC enterOneValueUC
    {
        get; set;
    }
    /// <summary>
    /// The show text result.
    /// </summary>
    ShowTextResult showTextResult
    {
        get; set;
    }
    /// <summary>
    /// The window with user control.
    /// </summary>
    WindowWithUserControl windowWithUserControl
    {
        get; set;
    }
    /// <summary>
    /// Gets or sets the show text result window.
    /// </summary>
    ShowTextResultWindow showTextResultWindow
    {
        get; set;
    }

    /// <summary>
    /// The compare in check box list UC.
    /// </summary>
    ICompareInCheckBoxListUC compareInCheckBoxListUC
    {
        get; set;
    }

    /// <summary>
    /// The select two values.
    /// </summary>
    SelectTwoValues selectTwoValues
    {
        get; set;
    }
}
