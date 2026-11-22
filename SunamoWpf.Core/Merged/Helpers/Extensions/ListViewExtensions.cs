#define ASYNC
namespace SunamoWpf.Extensions;

/// <summary>
/// Represents the list view extensions type.
/// </summary>
public static class ListViewExtensions
{
    /// <summary>
    /// The validated.
    /// </summary>
    public static bool validated
    {
        get => ValidationHelper.validated;
        set => ValidationHelper.validated = value;
    }
}