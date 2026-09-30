#define ASYNC
namespace SunamoWpf;

public partial class ColorPicker : UserControl
{
    #region #region Rewrite to pure cs. With xaml is often problems without building
    Color result = new Color();
    public Color Result
    {
        get
        {
            return result;
        }
        set
        {
            RSlider.Value = value.R;
            GSlider.Value = value.G;
            BSlider.Value = value.B;
            ASlider.Value = value.A;
            result = value;
            SetColor(value);
        }
    }
    private void SetColor(Color value)
    {
        SolidColorBrush scb = new SolidColorBrush(value);
        htmlColor.Text = StringHexWindowsMediaColorConverter.ConvertTo(value);
        rectColor.Fill = scb;
        ColorChanged(result);
        RSlider.BorderBrush = GSlider.BorderBrush = BSlider.BorderBrush = ASlider.BorderBrush = scb;
        //return value;
    }
    public event VoidWpfColor ColorChanged;
    public ColorPicker()
    {
        try
        {
            InitializeComponent();
        }
        catch (Exception)
        {
#if DEBUG
            Debugger.Break();
#endif
        }
        if (CultureInfo.CurrentUICulture.TwoLetterISOLanguageName == "cs")
        {
            ATextBlock.Text = Translate.FromKey(XlfKeys.Transparency) + ":";
            RTextBlock.Text = Translate.FromKey(XlfKeys.RedColoredFolder) + ":";
            GTextBlock.Text = Translate.FromKey(XlfKeys.GreenColorFolder) + ":";
            BTextBlock.Text = Translate.FromKey(XlfKeys.BlueColorFolder) + ":";
        }
        else
        {
            ATextBlock.Text = Translate.FromKey(XlfKeys.Opacity) + ":";
            RTextBlock.Text = Translate.FromKey(XlfKeys.RedColorComponent) + ":";
            GTextBlock.Text = Translate.FromKey(XlfKeys.GreenColorComponent) + ":";
            BTextBlock.Text = Translate.FromKey(XlfKeys.BlueColorComponent) + ":";
        }
    }
    private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        if (rectColor != null)
        {
            Slider s = (sender as Slider);
            string name = s.Name;
            byte value = (byte)s.Value;
            switch (name)
            {
                case "RSlider":
                    result.R = value;
                    break;
                case "GSlider":
                    result.G = value;
                    break;
                case "BSlider":
                    result.B = value;
                    break;
                case "ASlider":
                    result.A = value;
                    break;
                default:
                    ThrowEx.Custom("");
                    break;
            }
            rectColor.Fill = new SolidColorBrush(result);
            SetColor(result);
            //ColorChanged(result);
        }
    }
    static Type type = typeof(ColorPicker);
    private void htmlColor_KeyUp(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
        {
            e.Handled = true;
            Result = StringHexWindowsMediaColorConverter.ConvertFrom(htmlColor.Text);
        }
    }
    #endregion
}
