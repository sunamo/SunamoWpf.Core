#define ASYNC
namespace SunamoWpf.Controls;

/// <summary>
/// Padding - chb,tb
/// Margin - txt,btn
/// </summary>
public partial class ResourceDictionaryStyles
{
    #region 10 for remembering default size
    public static double def = 10;
    public static void Padding10(IList<Control> p)
    {
        Padding(def, p);
    }

    /// <summary>
    /// TextBlock is not deriving from Control, has own Padding
    /// </summary>
    /// <param name="d"></param>
    /// <param name="p"></param>
    public static void Padding10(IList<TextBlock> p)
    {
        Padding(def, p);
    }

    public static void Margin10(IList<TextBox> p)
    {
        Margin(def, p);
    }

    public static void Margin10(IList<TextBlock> p)
    {
        Margin(def, p);
    }

    public static void Margin10(IList<PasswordBox> p)
    {
        Margin(def, p);
    }

    public static void Margin10(IList<Grid> p)
    {
        Margin(def, p);
    }

    public static void Margin10(IList<CheckBox> p)
    {
        Margin(def, p);
    }

    public static void Margin10(IList<Button> p)
    {
        Margin(def, p);
    }


    #endregion

    public static void Padding(double d, IList<Control> p)
    {
        foreach (var item in p)
        {
            item.Padding = new Thickness(d);
        }
    }

    public static void Margin(double d, IList<CheckBox> p)
    {
        foreach (var item in p)
        {
            item.Margin = new Thickness(d);
        }
    }

    public static void Margin(double d, IList<TextBlock> p)
    {
        foreach (var item in p)
        {
            item.Margin = new Thickness(d);
        }
    }

    public static void Margin(double d, IList<Grid> p)
    {
        foreach (var item in p)
        {
            item.Margin = new Thickness(d);
        }
    }



    /// <summary>
    /// TextBlock is not deriving from Control, has own Padding
    /// </summary>
    /// <param name="d"></param>
    /// <param name="p"></param>
    public static void Padding(double d, IList<TextBlock> p)
    {
        foreach (var item in p)
        {
            item.Padding = new Thickness(d);
        }
    }

    public static void Margin(double v, IList<PasswordBox> p)
    {
        foreach (var item in p)
        {
            item.Margin = new Thickness(v);
        }
    }

    public static void Margin(double v, IList<TextBox> p)
    {
        foreach (var item in p)
        {
            item.Margin = new Thickness(v);
        }
    }

    public static void Margin(double v, IList<Button> p)
    {
        foreach (var item in p)
        {
            item.Margin = new Thickness(v);
        }
    }

    public static void Margin(int v, IList<StackPanel> p)
    {
        foreach (var item in p)
        {
            item.Margin = new Thickness(v);
        }
    }

    public static void Margin(int v, IList<SelectManyFiles> p)
    {
        foreach (var item in p)
        {
            item.Margin = new Thickness(v);
        }
    }
}