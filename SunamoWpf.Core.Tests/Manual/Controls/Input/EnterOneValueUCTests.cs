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



/// <summary>
/// EnterOneValueUCTests
/// Add txt and cb
///
/// EnterOneValueWindowTests
/// just create instance of EnterOneValueWindow
///
/// SelectTwoValuesUCTests
/// initialize SelectTwoValues (Values - selector controls) in one method Init()
/// </summary>
public class EnterOneValueUCTests
{
    static WindowWithUserControl w;

    string nameTxt = "a";
    string nameCb = "b";
    EnterOneValueUC selectTwoValues = null;
    List<FrameworkElement> elements = null;
    public static EnterOneValueUCTests Instance = new EnterOneValueUCTests();

    public  void Run()
    {
        selectTwoValues = new EnterOneValueUC();

        // 1. create controls
        var txt = TextBoxHelper.Get(new ControlInitData { text = nameTxt });
        var comboBox = ComboBoxHelper.Get(new ControlInitData { tag = nameCb, list = TestData.list12 });

        // 2. create list
        elements = new List<FrameworkElement> { txt, comboBox };

        // 3. init with list
        selectTwoValues.Init(elements);
        selectTwoValues.ChangeDialogResult += SelectTwoValues_ChangeDialogResult;

        w = new WindowWithUserControl(selectTwoValues, System.Windows.ResizeMode.CanResize, true);
        w.Loaded += W_Loaded;

        w.ShowDialog();
    }

    private void W_Loaded(object sender, RoutedEventArgs eventArgs)
    {
        selectTwoValues.EnterOneValueUC_Loaded(null, null);
    }

    private  void SelectTwoValues_ChangeDialogResult(bool? result)
    {
        // 4. get elements with indexes from original array
        var txt = ((TextBox)elements[0]).Text;
        var selectedItem = ((ComboBox)elements[1]).SelectedItem;

        MessageBox.Show(txt + Environment.NewLine + selectedItem);

        w.Close();
    }

}
