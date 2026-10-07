namespace SunamoWpf._public;

public interface IStatusBroadcasterAppendWpf : IStatusBroadcasterWpf
{
    event Action<object, object[]> NewStatusAppend;
    void OnNewStatusAppend(string message, params string[] parameters);
}