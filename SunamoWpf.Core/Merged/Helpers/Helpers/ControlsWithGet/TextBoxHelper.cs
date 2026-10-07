#define ASYNC
namespace SunamoWpf.Helpers.ControlsWithGet;

[System.Runtime.Versioning.SupportedOSPlatform("windows")]
public class TextBoxHelper
{
    static Type type = typeof(TextBoxHelper);
    static Dictionary<int, double> averageNumberWidthOnFontSize = new Dictionary<int, double>();
    static Dictionary<int, double> averageCharWidthOnFontSize = new Dictionary<int, double>();
    public static bool validated
    {
        set
        {
            TextBoxExtensions.validated = value;
        }
        get
        {
            return TextBoxExtensions.validated;
        }
    }
    /// <summary>
    ///
    /// </summary>
    /// <param name="txt"></param>
    /// <returns></returns>
    public static int VisibleLineCount(TextBox txt)
    {
        var firstLine = txt.GetFirstVisibleLineIndex();
        var lastLine = txt.GetLastVisibleLineIndex();
        return lastLine - firstLine;
    }
    public static void RegisterHighlightAllTextBox()
    {
        EventManager.RegisterClassHandler(typeof(TextBox),
     UIElement.GotFocusEvent,
     new RoutedEventHandler(TextBox_GotFocus));
    }
    static void TextBox_GotFocus(object sender, RoutedEventArgs eventArgs)
    {
        (sender as TextBox).SelectAll();
    }
    /// <summary>
    /// tag is not needed, value is obtained through []
    /// Tag here is mainly for comment what data control hold
    /// </summary>
    /// <param name="tag"></param>
    public static TextBox Get(ControlInitData controlInitData)
    {
        TextBox txt = new TextBox();
        ControlHelper.SetForeground(txt, controlInitData.foreground);
        if (controlInitData.imagePath != null)
        {
            ThrowEx.IsNotNull("d.imagePath", controlInitData.imagePath);
        }
        if (controlInitData.OnClick != null)
        {
            ThrowEx.IsNotNull("d.OnClick", controlInitData.OnClick);
        }
        txt.Name = controlInitData.name;
        // Set up NaN due to fill all available size
        txt.Width = double.NaN;
        txt.Tag = controlInitData.tag;
        txt.ToolTip = controlInitData.tooltip;
        txt.Text = controlInitData.text;
        if (controlInitData.OnTextChange != null)
        {
            txt.TextChanged += controlInitData.OnTextChange;
        }
        return txt;
    }
    private static void Txt_TextChanged(object sender, TextChangedEventArgs eventArgs)
    {
    }
    static TextBoxHelper()
    {
        InicializeWidths();
    }
    public static int GetLineLength(TextBox txt, int line)
    {
        // Counting from 0
        return txt.GetLineLength(line);
    }
    /// <summary>
    /// Get number of chars before
    /// </summary>
    /// <param name="txt"></param>
    /// <param name="line"></param>
    public static int GetCharacterIndexFromLineIndex(TextBox txt, int line)
    {
        // Counting from 0
        return txt.GetCharacterIndexFromLineIndex(line);
    }
    public static string GetLineText(TextBox txt, int line)
    {
        // Counting from 0
        return txt.GetLineText(line);
    }
    /// <summary>
    /// line is from 0
    /// </summary>
    /// <param name="txt"></param>
    /// <param name="line"></param>
    public static void ScrollToLine(TextBox txt, int line)
    {
#if DEBUG
        ////////////DebugLogger.Instance.WriteLine($"Line: {line} txt lines: {txt.LineCount}");
#endif
        //try
        //{
        //txt.SelectionStart = 0;
        ScrollToLineWorking(txt, line);
        //}
        //catch (Exception ex)
        //{
        //}
        // I had combobox which was focused by ctrl+1. But then lost focus due to next line
        //txt.Focus();
    }
    public static void ScrollToLine(TextEditor txtContent, int line)
    {
        if (txtContent == null)
        {
            return;
        }
        var count = 0;
        var lines = txtContent.Text.Split(new string[] { SH.DetectNewline(txtContent.Text) }, StringSplitOptions.RemoveEmptyEntries);
        for (int index = 0; index < line; index++)
        {
            count += lines[index].Length + 1;
        }
        txtContent.CaretOffset = count;
        txtContent.Focus();
    }
    //private static void MoveCaretToLine(TextBox txtBox, int lineNumber)
    //{
    //    //txtBox.HideSelection = false;
    //    txtBox.SelectionStart = txtBoxSH.GetFirstCharIndexFromLine(lineNumber - 1);
    //    txtBox.SelectionLength = txtBox.Lines[lineNumber - 1].Length;
    //    txtBox.ScrollToLine(txtBox.GetLineIndexFromCharacterIndex(txtBox.SelectionStart));
    //}
    private static void ScrollToLineWorking(TextBox txt, int line)
    {
        if (true)
        {
            #region Pokud i toto zakomentuji, nefunguje to už vůbec
            try
            {
                /*Snažil jsem opravit
                 * problém s napovídáním, mám git status, napíšu git, znovu mi to doplní status, mezerník a GetCharacterIndexFromLineIndex(Int32 lineIndex)\r\n   at SunamoWpf.TextBoxHelper.ScrollToLineWorking(TextBox txt, Int32 line)\r\n   at SunamoWpf.TextBoxHelper.ScrollToLin.
                 * poprvé se to projevilo, podruhé už ne, tak to jednoduše zakomentuji
                 */
                txt.SelectionStart = txt.GetCharacterIndexFromLineIndex(line);
            }
            catch (Exception)
            {
                return;
            }
            txt.SelectionLength = txt.GetLineLength(line);
            txt.CaretIndex = txt.SelectionStart;
            #endregion
            txt.ScrollToLine(line);
            txt.Focus();
        }
        //MoveCaretToLine(txt, line);
#if DEBUG
        Debug.WriteLine("ScrollToLine: " + line);
#endif
    }
    public static void InicializeWidths()
    {
        StackPanel stackPanel = new StackPanel();
        TextBox txtTest = new TextBox();
        txtTest.MinWidth = 0;
        Dictionary<int, double> charWidth = new Dictionary<int, double>();
        double? value = null;
        for (char letter = 'a'; letter <= 'z'; letter++)
        {
            txtTest = new TextBox();
            txtTest.Text = letter.ToString();
            txtTest.Measure(ControlHelper.SizePositiveInfinity);
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
        // Násobím 1-100(velikost písma) předchozím výsledkem - dostanu šířku textboxu při velikosti písma ai
        Dictionary<int, double> aweWidthFor = new Dictionary<int, double>();
        for (int index = 1; index < 101; index++)
        {
            aweWidthFor.Add(index, index * ave);
        }
        for (int index2 = 1; index2 < 101; index2++)
        {
            txtTest = new TextBox();
            stackPanel.Children.Add(txtTest);
            txtTest.Text = "1";
            txtTest.FontSize = index2;
            txtTest.Measure(ControlHelper.SizePositiveInfinity);
            averageNumberWidthOnFontSize.Add(index2, txtTest.DesiredSize.Width);
            stackPanel.Children.Remove(txtTest);
        }
        stackPanel.Visibility = Visibility.Collapsed;
    }
    /// <summary>
    /// Instead of this use instance
    /// </summary>
    /// <param name="textBox"></param>
    /// <param name="control"></param>
    /// <param name="trim"></param>
    public static void Validate(object textBox, TextBox control, ref ValidateDataWpf validateData)
    {
        control.Validate(textBox, ref validateData);
    }
    public static double GetOptimalWidthForCountOfChars(int count, bool alsoLetters, TextBox txt)
    {
        double countDouble = count;
        double copy = (int)txt.FontSize;
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
}
