namespace SunamoWpf._public;

/// <summary>
/// Represents the i status broadcaster wpf type.
/// </summary>
public interface IStatusBroadcasterWpf
{
    /// <summary>
    /// The new status.
    /// </summary>
    event Action<object, object[]> NewStatus;
    /// <summary>
    /// On new status.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <param name="parameters">The parameters.</param>
    void OnNewStatus(string message, params string[] parameters);
}