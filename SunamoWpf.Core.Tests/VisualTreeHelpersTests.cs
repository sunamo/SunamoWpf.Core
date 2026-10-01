using System.Windows.Controls;
using SunamoWpf.Helpers;

namespace SunamoWpf.Core.Tests;

public class VisualTreeHelpersTests
{
    [StaFact]
    public void FindDescendentsTest()
    {
        var sp = new StackPanel();
        var chb = new CheckBox();
        var tb = new TextBlock();

        const string inputText = "Hello world!";
        tb.Text = inputText;

        chb.Content = tb;
        sp.Children.Add(chb);

        // The CheckBox template (and with it the visual tree) is created only after layout.
        sp.Measure(new System.Windows.Size(200, 200));
        sp.Arrange(new System.Windows.Rect(0, 0, 200, 200));
        sp.UpdateLayout();

        var ele = VisualTreeHelpers.FindDescendents<TextBlock>(sp);
        var tb2 = ele.First();
        Assert.Equal(inputText, tb2.Text);
    }
}
