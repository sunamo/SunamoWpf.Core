#define ASYNC
namespace SunamoWpf.Controls;

/// <summary>
/// Padding - chb,tb
/// Margin - txt,btn
/// </summary>
public partial class ResourceDictionaryStyles
{
    #region 10 for remembering default size
    /// <summary>
    /// The def.
    /// </summary>
    public static double def = 10;
    /// <summary>
    /// Padding 10.
    /// </summary>
    /// <param name="controls">The controls.</param>
    public static void Padding10(IList<Control> controls)
    {
        Padding(def, controls);
    }

    /// <summary>
    /// TextBlock is not deriving from Control, has own Padding
    /// </summary>
    /// <param name="d"></param>
    /// <param name="controls"></param>
    public static void Padding10(IList<TextBlock> controls)
    {
        Padding(def, controls);
    }

    /// <summary>
    /// Margin 10.
    /// </summary>
    /// <param name="controls">The controls.</param>
    public static void Margin10(IList<TextBox> controls)
    {
        Margin(def, controls);
    }

    /// <summary>
    /// Margin 10.
    /// </summary>
    /// <param name="controls">The controls.</param>
    public static void Margin10(IList<TextBlock> controls)
    {
        Margin(def, controls);
    }

    /// <summary>
    /// Margin 10.
    /// </summary>
    /// <param name="controls">The controls.</param>
    public static void Margin10(IList<PasswordBox> controls)
    {
        Margin(def, controls);
    }

    /// <summary>
    /// Margin 10.
    /// </summary>
    /// <param name="controls">The controls.</param>
    public static void Margin10(IList<Grid> controls)
    {
        Margin(def, controls);
    }

    /// <summary>
    /// Margin 10.
    /// </summary>
    /// <param name="controls">The controls.</param>
    public static void Margin10(IList<CheckBox> controls)
    {
        Margin(def, controls);
    }

    /// <summary>
    /// Margin 10.
    /// </summary>
    /// <param name="controls">The controls.</param>
    public static void Margin10(IList<Button> controls)
    {
        Margin(def, controls);
    }


    #endregion

    /// <summary>
    /// Padding.
    /// </summary>
    /// <param name="padding">The padding.</param>
    /// <param name="controls">The controls.</param>
    public static void Padding(double padding, IList<Control> controls)
    {
        foreach (var item in controls)
        {
            item.Padding = new Thickness(padding);
        }
    }

    /// <summary>
    /// Margin.
    /// </summary>
    /// <param name="margin">The margin.</param>
    /// <param name="controls">The controls.</param>
    public static void Margin(double margin, IList<CheckBox> controls)
    {
        foreach (var item in controls)
        {
            item.Margin = new Thickness(margin);
        }
    }

    /// <summary>
    /// Margin.
    /// </summary>
    /// <param name="margin">The margin.</param>
    /// <param name="controls">The controls.</param>
    public static void Margin(double margin, IList<TextBlock> controls)
    {
        foreach (var item in controls)
        {
            item.Margin = new Thickness(margin);
        }
    }

    /// <summary>
    /// Margin.
    /// </summary>
    /// <param name="margin">The margin.</param>
    /// <param name="controls">The controls.</param>
    public static void Margin(double margin, IList<Grid> controls)
    {
        foreach (var item in controls)
        {
            item.Margin = new Thickness(margin);
        }
    }



    /// <summary>
    /// TextBlock is not deriving from Control, has own Padding
    /// </summary>
    /// <param name="padding"></param>
    /// <param name="controls"></param>
    public static void Padding(double padding, IList<TextBlock> controls)
    {
        foreach (var item in controls)
        {
            item.Padding = new Thickness(padding);
        }
    }

    /// <summary>
    /// Margin.
    /// </summary>
    /// <param name="margin">The margin.</param>
    /// <param name="controls">The controls.</param>
    public static void Margin(double margin, IList<PasswordBox> controls)
    {
        foreach (var item in controls)
        {
            item.Margin = new Thickness(margin);
        }
    }

    /// <summary>
    /// Margin.
    /// </summary>
    /// <param name="margin">The margin.</param>
    /// <param name="controls">The controls.</param>
    public static void Margin(double margin, IList<TextBox> controls)
    {
        foreach (var item in controls)
        {
            item.Margin = new Thickness(margin);
        }
    }

    /// <summary>
    /// Margin.
    /// </summary>
    /// <param name="margin">The margin.</param>
    /// <param name="controls">The controls.</param>
    public static void Margin(double margin, IList<Button> controls)
    {
        foreach (var item in controls)
        {
            item.Margin = new Thickness(margin);
        }
    }

    /// <summary>
    /// Margin.
    /// </summary>
    /// <param name="margin">The margin.</param>
    /// <param name="controls">The controls.</param>
    public static void Margin(int margin, IList<StackPanel> controls)
    {
        foreach (var item in controls)
        {
            item.Margin = new Thickness(margin);
        }
    }

    /// <summary>
    /// Margin.
    /// </summary>
    /// <param name="margin">The margin.</param>
    /// <param name="controls">The controls.</param>
    public static void Margin(int margin, IList<SelectManyFiles> controls)
    {
        foreach (var item in controls)
        {
            item.Margin = new Thickness(margin);
        }
    }
}