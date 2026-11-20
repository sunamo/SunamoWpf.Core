#define ASYNC
namespace SunamoWpf.Controls.Helpers;

/// <summary>
/// Represents the check box data helper type.
/// </summary>
public partial class CheckBoxDataHelper
{
    /// <summary>
    /// Text block.
    /// </summary>
    /// <param name="controlInitData">The control init data.</param>
    /// <returns>The text block result.</returns>
    public static CheckBoxData<UIElement> TextBlock(ControlInitData controlInitData)
    {
        return Get(TextBlockHelper.Get(controlInitData));
    }

    /// <summary>
    /// Check box.
    /// </summary>
    /// <param name="controlInitData">The control init data.</param>
    /// <returns>The check box result.</returns>
    public static CheckBoxData<UIElement> CheckBox(ControlInitData controlInitData)
    {
        return Get(CheckBoxHelper.Get(controlInitData));
    }

    /// <summary>
    /// Use ActionButton() for buttons without handler
    /// </summary>
    /// <param name="controlInitData"></param>
    public static CheckBoxData<UIElement> Button(ControlInitData controlInitData)
    {
        return Get(ButtonHelper.Get(controlInitData));
    }
}