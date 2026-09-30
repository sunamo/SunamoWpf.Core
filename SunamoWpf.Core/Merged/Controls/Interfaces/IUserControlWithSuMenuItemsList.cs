#define ASYNC
namespace SunamoWpf.Controls.Interfaces;

public interface IUserControlWithSuMenuItemsList : IUserControl
    {
        List<SuMenuItem> SuMenuItems();
    void RemoveWhichHaveNoItem();
}