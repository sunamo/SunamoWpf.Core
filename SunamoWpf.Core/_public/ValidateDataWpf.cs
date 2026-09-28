namespace SunamoWpf._public;

public class ValidateDataWpf
{
    public static readonly ValidateDataWpf Default = new();
    public bool allowEmpty = false;


    public List<string> excludedStrings = new();
    public string messageToReallyShow;
    public string messageWhenValidateMethodFails = null;
    public bool trim = true;
    public Func<string, bool> validateMethod;


    public int ValidateNotInline()
    {
        var i = 0;
        return i;
    }
}