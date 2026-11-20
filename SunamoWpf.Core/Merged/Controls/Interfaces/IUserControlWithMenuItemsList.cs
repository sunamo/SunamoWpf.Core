#define ASYNC
namespace SunamoWpf.Controls.Interfaces;

/// <summary>
/// Represents the i user control with menu items list type.
/// </summary>
public interface IUserControlWithMenuItemsList
{
    /// <summary>
    /// Su menu items.
    /// </summary>
    /// <returns>The su menu items result.</returns>
    List<SuMenuItem> SuMenuItems();
}