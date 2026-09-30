#define ASYNC
namespace SunamoWpf._sunamo;

internal class SHFormat
{
    public static string Format2(string status, params object[] args)
    {
        if (string.IsNullOrWhiteSpace(status)) return string.Empty;

        if (status.Contains('{') && !status.Contains("{0}")) return status;

        try
        {
            return string.Format(status, args);
        }
        catch (Exception ex)
        {
            ThrowEx.ExcAsArg(ex);
            return status;
        }
    }
    public static string Format4(string v, params Object[] o)
    {
        return string.Format(v, o);
    }
}