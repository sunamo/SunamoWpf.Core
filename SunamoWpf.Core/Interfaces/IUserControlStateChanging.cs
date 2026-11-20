namespace SunamoWpf.Interfaces;

/// <summary>
/// Represents the i user control state changing t type.
/// </summary>
public interface IUserControlStateChanging<T>
{
     /// <summary>
     /// The state changed.
     /// </summary>
     event Action<T> StateChanged;
}