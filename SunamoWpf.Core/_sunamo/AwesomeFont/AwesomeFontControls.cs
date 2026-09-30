namespace SunamoWpf.Core._sunamo;

internal static partial class AwesomeFontControls
{
    const string FontAwesome = "FontAwesome";
    public const int low = 61440;
    public const int high = 62176;

    public static bool IsFamilyFontFontAwesome(FontFamily f)
    {
        foreach (var item in f.FamilyNames)
        {
            if (item.Value.Contains(FontAwesome))
            {
                return true;
            }
        }
        return false;
    }

    public static async Task SetAwesomeFontSymbol(Button txtSearchIcon, string v)
    {
        await System.Windows.Application.Current.Dispatcher.InvokeAsync(() =>
        {
            txtSearchIcon.FontFamily = new System.Windows.Media.FontFamily(new Uri("pack://application:,,,/"), "./Fonts/#FontAwesome");
            txtSearchIcon.Content = v;
        });
    }

    public static async Task SetAwesomeFontSymbol(TextBlock txtSearchIcon, string v)
    {
        await System.Windows.Application.Current.Dispatcher.InvokeAsync(() =>
        {
            txtSearchIcon.FontFamily = new System.Windows.Media.FontFamily(new Uri("pack://application:,,,/"), "./Fonts/#FontAwesome");
            txtSearchIcon.Text = v;
        });
    }
}
