namespace SunamoWpf._public;

public interface IStatusBroadcasterAppendWpf : IStatusBroadcasterWpf
{
    event Action<object, object[]> NewStatusAppend;
    void OnNewStatusAppend(string s, params string[] p);
}