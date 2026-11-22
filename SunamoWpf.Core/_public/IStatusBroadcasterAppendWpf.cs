namespace SunamoWpf._public;

/// <summary>
/// Represents the i status broadcaster append wpf type.
/// </summary>
public interface IStatusBroadcasterAppendWpf : IStatusBroadcasterWpf
{
    /// <summary>
    /// The new status append.
    /// </summary>
    event Action<object, object[]> NewStatusAppend;
    /// <summary>
    /// On new status append.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <param name="parameters">The parameters.</param>
    void OnNewStatusAppend(string message, params string[] parameters);
}