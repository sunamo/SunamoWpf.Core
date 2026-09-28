namespace SunamoWpf.Interfaces;

public interface IHideToTray
{
    // cant be Title as in UC, because Window has own Property
    bool CancelClosing { get; set; }

    bool GetCancelClosing();
    void SetCancelClosing(bool b);
}