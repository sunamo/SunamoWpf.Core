#define ASYNC
namespace SunamoWpf.Helpers.ControlsWithGet;

/// <summary>
/// TBH je pro TextBox, TBH2 pro TextBlock
/// </summary>
public partial class TextBlockHelper 
{
    public static void InicializeWidths()
    {
        StackPanel stackPanel = new StackPanel();
        TextBlock txtTest = new TextBlock();
        txtTest.MinWidth = 0;
        Dictionary<int, double> charWidth = new Dictionary<int, double>();
        double? value = null;
        for (char letter = 'a'; letter <= 'z'; letter++)
        {
            txtTest = new TextBlock();
            txtTest.Text = letter.ToString();
            txtTest.Measure(ControlsHelperValues.SizePositiveInfinity);
            txtTest.Arrange(new Rect(0, 0, txtTest.DesiredSize.Width, txtTest.DesiredSize.Height));
            txtTest.UpdateLayout();
            charWidth.Add(letter, txtTest.ActualWidth);
            if (value == null)
            {
                value = txtTest.ActualWidth;
            }
            else
            {
                if (txtTest.ActualWidth > value.Value)
                {
                    value = txtTest.ActualWidth;
                }
            }
        }

        double ave = 0;
        double sum = 0;
        // Nejdříve vypočtu průměrnou velikost při FontSize=100
        foreach (var item in charWidth)
        {
            sum += item.Value;
        }

        ave = sum / charWidth.Count;
        // Pak vydělím 100
        ave /= 100;
        // Násobím 1-100(velikost písma) předchozím výsledkem - dostanu šířku TextBlocku při velikosti písma ai
        Dictionary<int, double> aweWidthFor = new Dictionary<int, double>();
        for (int index = 1; index < 101; index++)
        {
            aweWidthFor.Add(index, index * ave);
        }

        for (int widthIndex = 1; widthIndex < 101; widthIndex++)
        {
            txtTest = new TextBlock();
            stackPanel.Children.Add(txtTest);
            txtTest.Text = "1";
            txtTest.FontSize = widthIndex;
            txtTest.Measure(ControlsHelperValues.SizePositiveInfinity);
            averageNumberWidthOnFontSize.Add(widthIndex, txtTest.DesiredSize.Width);
            stackPanel.Children.Remove(txtTest);
        }

        stackPanel.Visibility = Visibility.Collapsed;
    }

    public static void AddTextPostColon(TextBlock tbSmtpServer)
    {
        tbSmtpServer.Text += ": ";
    }

    static TextBlockHelper()
    {
        InicializeWidths();
    }

    static Dictionary<int, double> averageNumberWidthOnFontSize = new Dictionary<int, double>();
    static Dictionary<int, double> averageCharWidthOnFontSize = new Dictionary<int, double>();
    public static double GetOptimalWidthForCountOfChars(int count, bool alsoLetters, TextBlock txt)
    {
        double countDouble = (double)count;
        double copy = (double)(int)txt.FontSize;
        if (copy != txt.FontSize)
        {
            copy++;
        }

        int copyInt = (int)copy;
        Dictionary<int, double> dict = null;
        if (alsoLetters)
        {
            dict = averageCharWidthOnFontSize;
        }
        else
        {
            dict = averageNumberWidthOnFontSize;
        }

        if (!dict.ContainsKey(copyInt))
        {
            copyInt = dict.Count;
        }

        return dict[copyInt] * countDouble;
    }

    public static void SetTextPostColonXlf(TextBlock lblStatusDownload, string xlf)
    {
        SetTextPostColonXlf(lblStatusDownload, Translate.FromKey(xlf));
    }

    public static void SetTextPostColon(TextBlock lblStatusDownload, string status)
    {
        status = SH.PostfixIfNotEmpty(status, ":");
        TextBlockHelper.SetText(lblStatusDownload, status);
    }

}