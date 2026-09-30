namespace SunamoWpf.Converters;

internal class VisibilityBooleanConverter
{
    public static bool ToBool(Visibility v)
    {
        if (v == Visibility.Visible)
        {
            return true;
        }
        return false;
    }

    public static Visibility FromBool(bool b)
    {
        if (b)
        {
            return Visibility.Visible;
        }
        return Visibility.Collapsed;
    }
}