#define ASYNC
namespace SunamoWpf.Controls;

public class ControlsGenerator
{
    public static RadioButton RadioButtonWithDescription(TWithSizeInString<string> data, bool addDescription, bool tick)
    {
        RadioButton chb = new RadioButton();
        StackPanel stackPanel = new StackPanel();
        stackPanel.Orientation = Orientation.Vertical;
        stackPanel.Children.Add(TextBlockHelper.Get(new ControlInitData { text = data.t }));
        if (addDescription)
        {
            stackPanel.Children.Add(TextBlockHelper.Get(new ControlInitData { text = data.sizeS }));
        }
        chb.IsThreeState = false;
        chb.IsChecked = tick;
        chb.Content = stackPanel;
        return chb;
    }

    /// <summary>
    /// For get from simple string use CheckBox.Get
    /// </summary>
    /// <param name="data"></param>
    /// <param name="addDescription"></param>
    /// <param name="tick"></param>
    public static CheckBox CheckBoxWithDescription(TWithSizeInString<string> data, bool addDescription, bool tick)
    {
        var textBlock = TextBlockHelper.Get(new ControlInitData { text = data.sizeS });

        CheckBox chb = new CheckBox();
        StackPanel stackPanel = new StackPanel();
        stackPanel.Orientation = Orientation.Vertical;
        stackPanel.Children.Add(TextBlockHelper.Get(new ControlInitData { text = data.t }));
        if (addDescription)
        {
            stackPanel.Children.Add(textBlock);
        }
        chb.IsThreeState = false;
        chb.IsChecked = tick;
        chb.Content = stackPanel;
        return chb;
    }

   
}