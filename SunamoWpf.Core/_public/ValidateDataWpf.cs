namespace SunamoWpf._public;

/// <summary>
/// Represents the validate data wpf type.
/// </summary>
public class ValidateDataWpf
{
    /// <summary>
    /// The default.
    /// </summary>
    public static readonly ValidateDataWpf Default = new();
    /// <summary>
    /// The allow empty.
    /// </summary>
    public bool allowEmpty = false;


    /// <summary>
    /// The excluded strings.
    /// </summary>
    public List<string> excludedStrings = new();
    /// <summary>
    /// The message to really show.
    /// </summary>
    public string messageToReallyShow;
    /// <summary>
    /// The message when validate method fails.
    /// </summary>
    public string messageWhenValidateMethodFails = null;
    /// <summary>
    /// The trim.
    /// </summary>
    public bool trim = true;
    /// <summary>
    /// The validate method.
    /// </summary>
    public Func<string, bool> validateMethod;


    /// <summary>
    /// Validate not inline.
    /// </summary>
    /// <returns>The validate not inline result.</returns>
    public int ValidateNotInline()
    {
        var result = 0;
        return result;
    }
}