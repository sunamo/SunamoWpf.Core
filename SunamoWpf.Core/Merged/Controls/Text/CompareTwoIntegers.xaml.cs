#define ASYNC
namespace SunamoWpf.Controls;

public partial class CompareTwoIntegers : UserControl
{
    #region Rewrite to pure cs. With xaml is often problems without building
    /// <summary>
    /// Initializes a new instance of the compare two integers class.
    /// </summary>
    /// <param name="whatCompare">The what compare.</param>
    /// <param name="value1">The value 1.</param>
    /// <param name="value2">The value 2.</param>
    /// <param name="widthValues">The width values.</param>
    /// <param name="bold">The bold.</param>
    public CompareTwoIntegers(string whatCompare, decimal value1, decimal value2, double widthValues, bool bold)
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

        tbWhatComparing.Text = whatCompare;

        if (bold)
        {
            tbWhatComparing.FontWeight = System.Windows.FontWeight.FromOpenTypeWeight(600);
        }

        Brush brush1 = Brushes.Black;
        Brush brush2 = Brushes.Black;
        string symbol = " = ";
        if (value1 > value2)
        {
            brush1 = Brushes.Green;
            brush2 = Brushes.Red;
            symbol = " > ";
        }
        else if (value2 > value1)
        {
            brush1 = Brushes.Red;
            brush2 = Brushes.Green;
            symbol = " < ";
        }

        tbValue1.Text = value1.ToString();
        tbValue1.Foreground = brush1;
        tbValue1.Width = widthValues;

        tbCompare.Text = symbol;

        tbValue2.Text = value2.ToString();
        tbValue2.Foreground = brush2;
        tbValue2.Width = widthValues;

    }
    #endregion


}

