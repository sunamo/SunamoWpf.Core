#define ASYNC
/// <summary>
/// Represents the i user control shared type.
/// </summary>
public interface IUserControlShared
{
    /// <summary>
    /// Gets or sets the main control.
    /// </summary>
    IEssentialMainWindow MainControl { get; set; }
}
