namespace SunamoWpf._public;

public interface IStatusBroadcasterWpf
{
    event Action<object, object[]> NewStatus;
    void OnNewStatus(string message, params string[] parameters);
}