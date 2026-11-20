#define ASYNC
namespace SunamoWpf;

/// <summary>
/// Represents the validation helper type.
/// </summary>
public class ValidationHelper
{
    /// <summary>
    /// The check for false validated.
    /// </summary>
    public static bool checkForFalseValidated = false;

    static bool _validated = false;

    /// <summary>
    /// The validated.
    /// </summary>
    public static bool validated
    {
        set
        {
            if (checkForFalseValidated && !value)
            {

            }
            _validated = value;
        }
        get
        {
            return _validated;
        }
    }
}