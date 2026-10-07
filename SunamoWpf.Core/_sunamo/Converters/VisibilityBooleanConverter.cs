namespace SunamoWpf.Core._sunamo;

internal class VisibilityBooleanConverter
{
    public static bool ToBool(Visibility visibility)
    {
        if (visibility == Visibility.Visible)
        {
            return true;
        }
        return false;
    }

    public static Visibility FromBool(bool value)
    {
        if (value)
        {
            return Visibility.Visible;
        }
        return Visibility.Collapsed;
    }
}
