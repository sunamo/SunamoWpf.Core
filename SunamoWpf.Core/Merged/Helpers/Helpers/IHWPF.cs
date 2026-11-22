#define ASYNC
namespace SunamoWpf.Helpers;

/// <summary>
/// Represents the update content of label type.
/// </summary>
public delegate void updateContentOfLabel(Label lbl, object content);
/// <summary>
/// Represents the update border brush of border type.
/// </summary>
public delegate void updateBorderBrushOfBorder(Border border, Brush brush);
/// <summary>
/// Represents the get border brush of border type.
/// </summary>
public delegate Brush getBorderBrushOfBorder(Border border);
/// <summary>
/// Represents the update progress bar wpf type.
/// </summary>
public delegate void updateProgressBarWpf(ProgressBar progressBar, double value);
/// <summary>
/// Represents the update text block text type.
/// </summary>
public delegate void updateTextBlockText(TextBlock lbl, string text);
/// <summary>
/// Represents the append to text block type.
/// </summary>
public delegate void appendToTextBlock(TextBlock lbl, string text);
/// <summary>
/// Represents the change visibility UI element wpf type.
/// </summary>
public delegate void changeVisibilityUIElementWpf(UIElement uie, Visibility visibility);
/// <summary>
/// Represents the update content of status bar item type.
/// </summary>
public delegate void updateContentOfStatusBarItem(StatusBarItem sbi, object content);
/// <summary>
/// Represents the append to text box type.
/// </summary>
public delegate void appendToTextBox(TextBox lbl, string text);
/// <summary>
/// Represents the insert to list box wpf type.
/// </summary>
public delegate void insertToListBoxWpf(ListBox listBox, int index, object item);
/// <summary>
/// Represents the set data context type.
/// </summary>
public delegate void setDataContext(FrameworkElement frameworkElement, object dataContext);
/// <summary>
/// Represents the get data context type.
/// </summary>
public delegate object getDataContext(FrameworkElement frameworkElement);
/// <summary>
/// Represents the set enabled type.
/// </summary>
public delegate void setEnabled(UIElement uie, bool enabled);
/// <summary>
/// Represents the get selected item selector type.
/// </summary>
public delegate object getSelectedItemSelector(Selector selector);
/// <summary>
/// Represents the set items source of items control type.
/// </summary>
public delegate void setItemsSourceOfItemsControl(ItemsControl itemsControl, IList items);
/// <summary>
/// Represents the set caret index of text box type.
/// </summary>
public delegate void setCaretIndexOfTextBox(TextBox txt, int caretIndex);
/// <summary>
/// Represents the focus text box type.
/// </summary>
public delegate void focusTextBox(TextBox txt);
/// <summary>
/// Represents the get text of text box type.
/// </summary>
public delegate string getTextOfTextBox(TextBox txt);
/// <summary>
/// Represents the scroll to end text box type.
/// </summary>
public delegate void scrollToEndTextBox(TextBox txt);
/// <summary>
/// Represents the get item at index in selector type.
/// </summary>
public delegate object getItemAtIndexInSelector(Selector selector, int dex);
/// <summary>
/// Represents the set selected item selector type.
/// </summary>
public delegate void setSelectedItemSelector(Selector selector, object item);
/// <summary>
/// Represents the update layout of UI element type.
/// </summary>
public delegate void updateLayoutOfUIElement(UIElement uie);
//public delegate ListBoxItem getListBoxItemFromObject(ListBox lb, object )

/// <summary>
/// Represents the IH type.
/// </summary>
public partial class IH
{
    static Type type = typeof(IH);
    /// <summary>
    /// The get text of text block.
    /// </summary>
    public static Func<string> getTextOfTextBlock = getTextOfTextBlockW;
    /// <summary>
    /// The set text text block.
    /// </summary>
    public static Action<TextBlock, string> setTextTextBlock = setTextTextBlockW;
    /// <summary>
    /// The delegate change visibility UI element wpf.
    /// </summary>
    public static changeVisibilityUIElementWpf delegateChangeVisibilityUIElementWpf = null;
    /// <summary>
    /// The delegate insert to list box wpf.
    /// </summary>
    public static insertToListBoxWpf delegateInsertToListBoxWpf = null;
    /// <summary>
    /// The delegate update content of label.
    /// </summary>
    public static updateContentOfLabel delegateUpdateContentOfLabel = null;
    /// <summary>
    /// The delegate update border brush of border.
    /// </summary>
    public static updateBorderBrushOfBorder delegateUpdateBorderBrushOfBorder = null;
    /// <summary>
    /// The delegate get border brush of border.
    /// </summary>
    public static getBorderBrushOfBorder delegateGetBorderBrushOfBorder = null;
    /// <summary>
    /// The delegate update progress bar wpf.
    /// </summary>
    public static updateProgressBarWpf delegateUpdateProgressBarWpf = null;
    /// <summary>
    /// The delegate update text block text.
    /// </summary>
    public static updateTextBlockText delegateUpdateTextBlockText = null;
    /// <summary>
    /// The delegate append to text block.
    /// </summary>
    public static appendToTextBlock delegateAppendToTextBlock = null;
    /// <summary>
    /// The delegate update content of status bar item.
    /// </summary>
    public static updateContentOfStatusBarItem delegateUpdateContentOfStatusBarItem = null;
    /// <summary>
    /// The delegate append to text box.
    /// </summary>
    public static appendToTextBox delegateAppendToTextBox = null;
    /// <summary>
    /// The delegate set data context.
    /// </summary>
    public static setDataContext delegateSetDataContext = null;
    /// <summary>
    /// The delegate get data context.
    /// </summary>
    public static getDataContext delegateGetDataContext = null;
    /// <summary>
    /// The delegate set enabled.
    /// </summary>
    public static setEnabled delegateSetEnabled = null;
    /// <summary>
    /// The delegate get selected item selector.
    /// </summary>
    public static getSelectedItemSelector delegateGetSelectedItemSelector = null;
    /// <summary>
    /// The delegate set items source of items control.
    /// </summary>
    public static setItemsSourceOfItemsControl delegateSetItemsSourceOfItemsControl = null;
    /// <summary>
    /// The delegate set caret index of text box.
    /// </summary>
    public static setCaretIndexOfTextBox delegateSetCaretIndexOfTextBox = null;
    /// <summary>
    /// The delegate focus text box.
    /// </summary>
    public static focusTextBox delegateFocusTextBox = null;
    /// <summary>
    /// The delegate get text of text box.
    /// </summary>
    public static getTextOfTextBox delegateGetTextOfTextBox = null;
    /// <summary>
    /// The delegate scroll to end text box.
    /// </summary>
    public static scrollToEndTextBox delegateScrollToEndTextBox = null;
    /// <summary>
    /// The delegate get item at index in selector.
    /// </summary>
    public static getItemAtIndexInSelector delegateGetItemAtIndexInSelector = null;
    /// <summary>
    /// The delegate set selected item selector.
    /// </summary>
    public static setSelectedItemSelector delegateSetSelectedItemSelector = null;
    /// <summary>
    /// The delegate update layout of UI element.
    /// </summary>
    public static updateLayoutOfUIElement delegateUpdateLayoutOfUIElement = null;
    /// <summary>
    /// The get list box item from object.
    /// </summary>
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

    /// <summary>
    /// The tb.
    /// </summary>
    public static TextBlock tb = null;
    static string getTextOfTextBlockW()
    {
        return tb.Text;
    }
    static void setTextTextBlockW(TextBlock textBlock, string text)
    {
        textBlock.Text = text;
    }

    /// <summary>
    /// Update layout of UI element.
    /// </summary>
    /// <param name="uie">The uie.</param>
    public static void updateLayoutOfUIElement(UIElement uie)
    {
        uie.UpdateLayout();
    }
    /// <summary>
    /// Set selected item selector.
    /// </summary>
    /// <param name="selector">The selector.</param>
    /// <param name="item">The item.</param>
    public static void setSelectedItemSelector(Selector selector, object item)
    {
        selector.SelectedItem = item;
    }
    /// <summary>
    /// Get item at index in selector.
    /// </summary>
    /// <param name="selector">The selector.</param>
    /// <param name="dex">The dex.</param>
    /// <returns>The get item at index in selector result.</returns>
    public static object getItemAtIndexInSelector(Selector selector, int dex)
    {
        return selector.Items[dex];
    }
    /// <summary>
    /// Scroll to end text box.
    /// </summary>
    /// <param name="txt">The txt.</param>
    public static void scrollToEndTextBox(TextBox txt)
    {
        txt.ScrollToEnd();
    }
    /// <summary>
    /// Get text of text box.
    /// </summary>
    /// <param name="txt">The txt.</param>
    /// <returns>The get text of text box result.</returns>
    public static string getTextOfTextBox(TextBox txt)
    {
        return txt.Text;
    }
    /// <summary>
    /// Focus text box.
    /// </summary>
    /// <param name="txt">The txt.</param>
    public static void focusTextBox(TextBox txt)
    {
        txt.Focus();
    }
    /// <summary>
    /// Update content of label value.
    /// </summary>
    /// <param name="label">The label.</param>
    /// <param name="content">The content.</param>
    public static void updateContentOfLabelValue(Label label, object content)
    {
        label.Content = content;
    }
    /// <summary>
    /// Set caret index of text box.
    /// </summary>
    /// <param name="txt">The txt.</param>
    /// <param name="caretIndex">The caret index.</param>
    public static void setCaretIndexOfTextBox(TextBox txt, int caretIndex)
    {
        txt.CaretIndex = caretIndex;
    }
    /// <summary>
    /// Update border brush of border value.
    /// </summary>
    /// <param name="border">The border.</param>
    /// <param name="brush">The brush.</param>
    public static void updateBorderBrushOfBorderValue(Border border, Brush brush)
    {
        border.BorderBrush = brush;
    }
    /// <summary>
    /// Get border brush of border value.
    /// </summary>
    /// <param name="border">The border.</param>
    /// <returns>The get border brush of border value result.</returns>
    public static Brush getBorderBrushOfBorderValue(Border border)
    {
        return border.BorderBrush;
    }
    /// <summary>
    /// Update content of status bar item value.
    /// </summary>
    /// <param name="sbi">The sbi.</param>
    /// <param name="content">The content.</param>
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
    /// <summary>
    /// Update text block text.
    /// </summary>
    /// <param name="lbl">The lbl.</param>
    /// <param name="text">The text.</param>
    public static void updateTextBlockText(TextBlock lbl, string text)
    {
        lbl.Text = text;
        lbl.ToolTip = text;
    }
    /// <summary>
    /// Append to text block text.
    /// </summary>
    /// <param name="lbl">The lbl.</param>
    /// <param name="text">The text.</param>
    public static void appendToTextBlockText(TextBlock lbl, string text)
    {
        lbl.Text = lbl.Text + " " + text;
        lbl.ToolTip = lbl.Text;
    }
    /// <summary>
    /// Append to text box text.
    /// </summary>
    /// <param name="textBox">The text box.</param>
    /// <param name="text">The text.</param>
    public static void appendToTextBoxText(TextBox textBox, string text)
    {
        textBox.Text = textBox.Text + " " + text;
        textBox.ToolTip = textBox.Text;
    }
    //
    /// <summary>
    /// Update visibility.
    /// </summary>
    /// <param name="uiElement">The ui element.</param>
    /// <param name="vis">The vis.</param>
    public static void updateVisibility(UIElement uiElement, Visibility vis)
    {
        uiElement.Visibility = vis;
    }

    /// <summary>
    /// Insert to list box wpf value.
    /// </summary>
    /// <param name="listBox">The list box.</param>
    /// <param name="index">The index.</param>
    /// <param name="item">The item.</param>
    public static void insertToListBoxWpfValue(ListBox listBox, int index, object item)
    {
        listBox.Items.Insert(index, item);
    }
    /// <summary>
    /// Set data context object.
    /// </summary>
    /// <param name="frameworkElement">The framework element.</param>
    /// <param name="dataContext">The data context.</param>
    public static void setDataContextObject(FrameworkElement frameworkElement, object dataContext)
    {
        frameworkElement.DataContext = dataContext;
    }
    /// <summary>
    /// Get data context object.
    /// </summary>
    /// <param name="frameworkElement">The framework element.</param>
    /// <returns>The get data context object result.</returns>
    public static object getDataContextObject(FrameworkElement frameworkElement)
    {
        return frameworkElement.DataContext;
    }
    /// <summary>
    /// Set enabled bool.
    /// </summary>
    /// <param name="uiElement">The ui element.</param>
    /// <param name="enabled">The enabled.</param>
    public static void setEnabledBool(UIElement uiElement, bool enabled)
    {
        uiElement.IsEnabled = enabled;
    }
    /// <summary>
    /// Get selected item selector.
    /// </summary>
    /// <param name="selector">The selector.</param>
    /// <returns>The get selected item selector result.</returns>
    public static object getSelectedItemSelector(Selector selector)
    {
        return selector.SelectedItem;
    }
}