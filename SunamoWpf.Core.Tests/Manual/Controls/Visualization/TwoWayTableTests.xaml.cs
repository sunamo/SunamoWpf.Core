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

using SunamoWpf.Controls.Visualization;

namespace Wpf.Tests.Controls.Visualization
{

    public partial class TwoWayTableTests : UserControl
    {
        private readonly TwoWayTable twt;

        public TwoWayTableTests()
        {
            InitializeComponent();
            twt = new TwoWayTable(Microsoft.Extensions.Logging.Abstractions.NullLogger.Instance);
            host.Children.Add(twt);

            Loaded += TwoWayTableTests_Loaded;
        }

        private void TwoWayTableTests_Loaded(object sender, RoutedEventArgs eventArgs)
        {
            #region region for all code to easy transfer to another code
            var rowsCount = 100;
            twt.CreateGrid(rowsCount, 2);

            List<CheckBoxData<UIElement>> items = new List<CheckBoxData<UIElement>>();
            List<CheckBoxData<UIElement>> secondItems = new List<CheckBoxData<UIElement>>();

            List<int> result = new List<int>(rowsCount);
            for (int index = 0; index < rowsCount; index++)
            {
                result.Add(index);
                items.Add(CheckBoxDataHelper.TextBlock(new ControlInitData { text = index.ToString() }));
                secondItems.Add(CheckBoxDataHelper.TextBlock(new ControlInitData { text = (index + 100).ToString() }));
            }
            
            twt.AddColumn(0, items, result.Cast<object>().ToList());

            twt.AddColumn(1, secondItems, result.Cast<object>().ToList());
            #endregion
        }

    }
}
