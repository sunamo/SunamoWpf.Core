#define ASYNC
namespace SunamoWpf;

public partial class ColorPicker : UserControl
{
    #region #region Rewrite to pure cs. With xaml is often problems without building
    Color result = new Color();
    /// <summary>
    /// The result.
    /// </summary>
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
    /// <summary>
    /// The color changed.
    /// </summary>
    public event VoidWpfColor ColorChanged;
    /// <summary>
    /// Initializes a new instance of the color picker class.
    /// </summary>
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
            ATextBlock.Text = "Transparency" + ":";
            RTextBlock.Text = "RedColoredFolder" + ":";
            GTextBlock.Text = "GreenColorFolder" + ":";
            BTextBlock.Text = "BlueColorFolder" + ":";
        }
        else
        {
            ATextBlock.Text = "Opacity" + ":";
            RTextBlock.Text = "RedColorComponent" + ":";
            GTextBlock.Text = "GreenColorComponent" + ":";
            BTextBlock.Text = "BlueColorComponent" + ":";
        }
    }
    private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> eventArgs)
    {
        if (rectColor != null)
        {
            Slider slider = (sender as Slider);
            string name = slider.Name;
            byte value = (byte)slider.Value;
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
    private void htmlColor_KeyUp(object sender, KeyEventArgs eventArgs)
    {
        if (eventArgs.Key == Key.Enter)
        {
            eventArgs.Handled = true;
            Result = StringHexWindowsMediaColorConverter.ConvertFrom(htmlColor.Text);
        }
    }
    #endregion
}
