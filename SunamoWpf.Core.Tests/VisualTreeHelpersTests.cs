using System.Windows.Controls;
using SunamoWpf.Helpers;

namespace SunamoWpf.Core.Tests;

public class VisualTreeHelpersTests
{
    [StaFact]
    public void FindDescendentsTest()
    {
        var stackPanel = new StackPanel();
        var chb = new CheckBox();
        var textBlock = new TextBlock();

        const string inputText = "Hello world!";
        textBlock.Text = inputText;

        chb.Content = textBlock;
        stackPanel.Children.Add(chb);

        // The CheckBox template (and with it the visual tree) is created only after layout.
        stackPanel.Measure(new System.Windows.Size(200, 200));
        stackPanel.Arrange(new System.Windows.Rect(0, 0, 200, 200));
        stackPanel.UpdateLayout();

        var ele = VisualTreeHelpers.FindDescendents<TextBlock>(stackPanel);
        var tb2 = ele.First();
        Assert.Equal(inputText, tb2.Text);
    }
}
