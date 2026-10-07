#define ASYNC
namespace SunamoWpf.Helpers;

public delegate void updateContentOfLabel(Label lbl, object content);
public delegate void updateBorderBrushOfBorder(Border border, Brush brush);
public delegate Brush getBorderBrushOfBorder(Border border);
public delegate void updateProgressBarWpf(ProgressBar progressBar, double value);
public delegate void updateTextBlockText(TextBlock lbl, string text);
public delegate void appendToTextBlock(TextBlock lbl, string text);
public delegate void changeVisibilityUIElementWpf(UIElement uie, Visibility visibility);
public delegate void updateContentOfStatusBarItem(StatusBarItem sbi, object content);
public delegate void appendToTextBox(TextBox lbl, string text);
public delegate void insertToListBoxWpf(ListBox listBox, int index, object item);
public delegate void setDataContext(FrameworkElement frameworkElement, object dataContext);
public delegate object getDataContext(FrameworkElement frameworkElement);
public delegate void setEnabled(UIElement uie, bool enabled);
public delegate object getSelectedItemSelector(Selector selector);
public delegate void setItemsSourceOfItemsControl(ItemsControl itemsControl, IList items);
public delegate void setCaretIndexOfTextBox(TextBox txt, int caretIndex);
public delegate void focusTextBox(TextBox txt);
public delegate string getTextOfTextBox(TextBox txt);
public delegate void scrollToEndTextBox(TextBox txt);
public delegate object getItemAtIndexInSelector(Selector selector, int dex);
public delegate void setSelectedItemSelector(Selector selector, object item);
public delegate void updateLayoutOfUIElement(UIElement uie);
//public delegate ListBoxItem getListBoxItemFromObject(ListBox lb, object )

public partial class IH
{
    static Type type = typeof(IH);
    public static Func<string> getTextOfTextBlock = getTextOfTextBlockW;
    public static Action<TextBlock, string> setTextTextBlock = setTextTextBlockW;
    public static changeVisibilityUIElementWpf delegateChangeVisibilityUIElementWpf = null;
    public static insertToListBoxWpf delegateInsertToListBoxWpf = null;
    public static updateContentOfLabel delegateUpdateContentOfLabel = null;
    public static updateBorderBrushOfBorder delegateUpdateBorderBrushOfBorder = null;
    public static getBorderBrushOfBorder delegateGetBorderBrushOfBorder = null;
    public static updateProgressBarWpf delegateUpdateProgressBarWpf = null;
    public static updateTextBlockText delegateUpdateTextBlockText = null;
    public static appendToTextBlock delegateAppendToTextBlock = null;
    public static updateContentOfStatusBarItem delegateUpdateContentOfStatusBarItem = null;
    public static appendToTextBox delegateAppendToTextBox = null;
    public static setDataContext delegateSetDataContext = null;
    public static getDataContext delegateGetDataContext = null;
    public static setEnabled delegateSetEnabled = null;
    public static getSelectedItemSelector delegateGetSelectedItemSelector = null;
    public static setItemsSourceOfItemsControl delegateSetItemsSourceOfItemsControl = null;
    public static setCaretIndexOfTextBox delegateSetCaretIndexOfTextBox = null;
    public static focusTextBox delegateFocusTextBox = null;
    public static getTextOfTextBox delegateGetTextOfTextBox = null;
    public static scrollToEndTextBox delegateScrollToEndTextBox = null;
    public static getItemAtIndexInSelector delegateGetItemAtIndexInSelector = null;
    public static setSelectedItemSelector delegateSetSelectedItemSelector = null;
    public static updateLayoutOfUIElement delegateUpdateLayoutOfUIElement = null;
    public static ListBoxItem getListBoxItemFromObject = null;
    //
    static IH()
    {
        delegateChangeVisibilityUIElementWpf = new changeVisibilityUIElementWpf(updateVisibility);
        delegateInsertToListBoxWpf = new insertToListBoxWpf(insertToListBoxWpfValue);
        delegateUpdateContentOfLabel = new updateContentOfLabel(updateContentOfLabelValue);
        delegateUpdateBorderBrushOfBorder = new updateBorderBrushOfBorder(updateBorderBrushOfBorderValue);
        delegateGetBorderBrushOfBorder = new getBorderBrushOfBorder(getBorderBrushOfBorderValue);
        delegateUpdateProgressBarWpf = new updateProgressBarWpf(updateProgressBarWpfValue);
        delegateUpdateTextBlockText = new updateTextBlockText(updateTextBlockText);
        delegateAppendToTextBlock = new appendToTextBlock(appendToTextBlockText);
        delegateUpdateContentOfStatusBarItem = new updateContentOfStatusBarItem(updateContentOfStatusBarItemValue);
        delegateAppendToTextBox = new appendToTextBox(appendToTextBoxText);
        delegateSetDataContext = new setDataContext(setDataContextObject);
        delegateGetDataContext = new getDataContext(getDataContextObject);
        delegateSetEnabled = new setEnabled(setEnabledBool);
        delegateGetSelectedItemSelector = new getSelectedItemSelector(getSelectedItemSelector);
        delegateSetItemsSourceOfItemsControl = new setItemsSourceOfItemsControl(setItemsSourceOfItemsControlM);
        delegateSetCaretIndexOfTextBox = new setCaretIndexOfTextBox(setCaretIndexOfTextBox);
        delegateFocusTextBox = new focusTextBox(focusTextBox);
        delegateGetTextOfTextBox = new getTextOfTextBox(getTextOfTextBox);
        delegateScrollToEndTextBox = new scrollToEndTextBox(scrollToEndTextBox);
        delegateGetItemAtIndexInSelector = new getItemAtIndexInSelector(getItemAtIndexInSelector);
        delegateSetSelectedItemSelector = new setSelectedItemSelector(setSelectedItemSelector);
        delegateUpdateLayoutOfUIElement = new updateLayoutOfUIElement(updateLayoutOfUIElement);
    }

    public static TextBlock tb = null;
    static string getTextOfTextBlockW()
    {
        return tb.Text;
    }
    static void setTextTextBlockW(TextBlock textBlock, string text)
    {
        textBlock.Text = text;
    }

    public static void updateLayoutOfUIElement(UIElement uie)
    {
        uie.UpdateLayout();
    }
    public static void setSelectedItemSelector(Selector selector, object item)
    {
        selector.SelectedItem = item;
    }
    public static object getItemAtIndexInSelector(Selector selector, int dex)
    {
        return selector.Items[dex];
    }
    public static void scrollToEndTextBox(TextBox txt)
    {
        txt.ScrollToEnd();
    }
    public static string getTextOfTextBox(TextBox txt)
    {
        return txt.Text;
    }
    public static void focusTextBox(TextBox txt)
    {
        txt.Focus();
    }
    public static void updateContentOfLabelValue(Label label, object content)
    {
        label.Content = content;
    }
    public static void setCaretIndexOfTextBox(TextBox txt, int caretIndex)
    {
        txt.CaretIndex = caretIndex;
    }
    public static void updateBorderBrushOfBorderValue(Border border, Brush brush)
    {
        border.BorderBrush = brush;
    }
    public static Brush getBorderBrushOfBorderValue(Border border)
    {
        return border.BorderBrush;
    }
    public static void updateContentOfStatusBarItemValue(StatusBarItem sbi, object content)
    {
        sbi.Content = content;
    }
    static void setItemsSourceOfItemsControlM(ItemsControl itemsControl, IList items)
    {
        itemsControl.ItemsSource = items;
    }
    /// <summary>
    /// Tato metoda je pro WPF, updateProgressBarValue pak na WF
    /// </summary>
    /// <param name="progressBar"></param>
    /// <param name="value"></param>
    public static void updateProgressBarWpfValue(ProgressBar progressBar, double value)
    {
        if (value > 100)
        {
            //ThrowEx.Custom("Hodnota pro ProgressBar nemůže být vyšší než 100.");
            value = 100;
        }
        progressBar.Value = value;
    }
    public static void updateTextBlockText(TextBlock lbl, string text)
    {
        lbl.Text = text;
        lbl.ToolTip = text;
    }
    public static void appendToTextBlockText(TextBlock lbl, string text)
    {
        lbl.Text = lbl.Text + " " + text;
        lbl.ToolTip = lbl.Text;
    }
    public static void appendToTextBoxText(TextBox textBox, string text)
    {
        textBox.Text = textBox.Text + " " + text;
        textBox.ToolTip = textBox.Text;
    }
    //
    public static void updateVisibility(UIElement uiElement, Visibility vis)
    {
        uiElement.Visibility = vis;
    }

    public static void insertToListBoxWpfValue(ListBox listBox, int index, object item)
    {
        listBox.Items.Insert(index, item);
    }
    public static void setDataContextObject(FrameworkElement frameworkElement, object dataContext)
    {
        frameworkElement.DataContext = dataContext;
    }
    public static object getDataContextObject(FrameworkElement frameworkElement)
    {
        return frameworkElement.DataContext;
    }
    public static void setEnabledBool(UIElement uiElement, bool enabled)
    {
        uiElement.IsEnabled = enabled;
    }
    public static object getSelectedItemSelector(Selector selector)
    {
        return selector.SelectedItem;
    }
}