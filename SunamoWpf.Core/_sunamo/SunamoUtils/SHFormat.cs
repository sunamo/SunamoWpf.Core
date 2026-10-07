#define ASYNC
namespace SunamoWpf.Core._sunamo;

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
        catch (Exception exception)
        {
            ThrowEx.ExcAsArg(exception);
            return status;
        }
    }
    public static string Format4(string format, params Object[] arguments)
    {
        return string.Format(format, arguments);
    }
}
