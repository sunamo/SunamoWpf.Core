#define ASYNC
namespace SunamoWpf.Controls.Interfaces;

/// <summary>
/// Represents the i user control with su menu items list type.
/// </summary>
public interface IUserControlWithSuMenuItemsList : IUserControl
    {
        /// <summary>
        /// Su menu items.
        /// </summary>
        /// <returns>The su menu items result.</returns>
        List<SuMenuItem> SuMenuItems();
    /// <summary>
    /// Remove which have no item.
    /// </summary>
    void RemoveWhichHaveNoItem();
}