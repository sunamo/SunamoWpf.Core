// manual-usings
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Resources;
using System.Windows.Shapes;
using SunamoWpf;
using SunamoWpf.Args;
using SunamoWpf.Collections;
using SunamoWpf.Commands;
using SunamoWpf.Controls;
using SunamoWpf.Controls.Collections;
using SunamoWpf.Controls.Controls;
using SunamoWpf.Controls.Helpers;
using SunamoWpf.Controls.Input;
using SunamoWpf.Controls.Menu;
using SunamoWpf.Controls.Text;
using SunamoWpf.Controls.Visualization;
using SunamoWpf.Controls.Wrapper;
using SunamoWpf.Data;
using SunamoWpf.Helpers;
using SunamoWpf.Helpers.Content;
using SunamoWpf.Helpers.Controls;
using SunamoWpf.Helpers.ControlsWithGet;
using SunamoWpf.Windows;
using SunamoWpf._public;
using SunamoWpf._shared;
using SunamoWpf.Essential;
using SunamoWpf.Extensions;

public class WRTBHTests : UserControl
{
    WRTBH wrtbh = null;

    public WRTBHTests()
    {
        ItemsControl itemsControl = new ItemsControl();
        itemsControl.ItemsSource = new ObservableCollection<object>();// new Binding();

        ItemsPanelTemplate ipt = new ItemsPanelTemplate();
        //ipt.LoadContent("<StackPanel Orientation=\"Vertical\"></StackPanel>");
        var templateContent = ipt.Template;
        var visualTree = ipt.VisualTree;

        StackPanel stackPanel = new StackPanel();
        stackPanel.Orientation = Orientation.Vertical;

        ControlTemplate template = new ControlTemplate(typeof(Button));
        var image = new FrameworkElementFactory(typeof(Image));
        template.VisualTree = image;

        Button btn = new Button();
        string template2 =
        " <ControlTemplate xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation' TargetType=\"ItemsControl\">" +
             "<StackPanel Orientation=\"Vertical\"></StackPanel>"+
        "</ControlTemplate>";
        btn.Template = (ControlTemplate)XamlReader.Parse(template2);

        itemsControl.ItemsPanel = ipt;

        WRTBH tbh2 = new WRTBH(475, 10, FontArgs.DefaultRun());

        wrtbh = new WRTBH(400, 20, FontArgs.DefaultRun());

        wrtbh.Hyperlink("hello", "https://sunamo.cz/");

        itemsControl.DataContext = wrtbh.uis;

        Content = itemsControl;
    }
}
