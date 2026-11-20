#define ASYNC
namespace SunamoWpf;

/// <summary>
/// Represents the __ type.
/// </summary>
public class __
{
    /// <summary>
    /// The mw.
    /// </summary>
    public static IMainWindowBasicControls mw = null;

    /// <summary>
    /// Gets the check box list UC.
    /// </summary>
    public static ICheckBoxListUC checkBoxListUC { get => mw.checkBoxListUC; set => mw.checkBoxListUC = value; }
    /// <summary>
    /// Gets the select one value.
    /// </summary>
    public static SelectOneValue selectOneValue { get => mw.selectOneValue; set => mw.selectOneValue = value; }
    /// <summary>
    /// Gets the radio buttons list.
    /// </summary>
    public static RadioButtonsList radioButtonsList { get => mw.radioButtonsList; set => mw.radioButtonsList = value; }
    /// <summary>
    /// Gets the enter one value UC.
    /// </summary>
    public static EnterOneValueUC enterOneValueUC { get => mw.enterOneValueUC; set => mw.enterOneValueUC = value; }
    /// <summary>
    /// Gets the show text result.
    /// </summary>
    public static ShowTextResult showTextResult { get => mw.showTextResult; set => mw.showTextResult = value; }
    /// <summary>
    /// Gets the window with user control.
    /// </summary>
    public static WindowWithUserControl windowWithUserControl { get => mw.windowWithUserControl; set => mw.windowWithUserControl = value; }
    /// <summary>
    /// Gets the show text result window.
    /// </summary>
    public static ShowTextResultWindow showTextResultWindow { get => mw.showTextResultWindow; set => mw.showTextResultWindow = value; }
    /// <summary>
    /// Gets the select two values.
    /// </summary>
    public static SelectTwoValues selectTwoValues { get => mw.selectTwoValues; set => mw.selectTwoValues = value; }
}