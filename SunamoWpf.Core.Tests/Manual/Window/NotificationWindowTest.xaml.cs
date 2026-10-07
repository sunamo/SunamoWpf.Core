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

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for NotificationWindowTest.xaml
    /// </summary>
    public partial class NotificationUC : UserControl
    {


        public NotificationUC()
        {
            InitializeComponent();
            //Title = "NotificationWindowTest";

            Loaded += NotificationWindowTest_Loaded;
        }

        private void NotificationWindowTest_Loaded(object sender, RoutedEventArgs eventArgs)
        {

        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs eventArgs)
        {

        }

        private void Grid_PreviewKeyDown(object sender, KeyEventArgs eventArgs)
        {
            NotificationWindow.Show("Hello", this);
        }

        private void Grid_PreviewMouseDown(object sender, MouseButtonEventArgs eventArgs)
        {

        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs eventArgs)
        {

        }
    }
}
