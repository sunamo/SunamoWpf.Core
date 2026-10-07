// manual-usings
using System;
using System.Configuration;
using SunamoWpf.Storage;
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

namespace WpfState.Tests
{
    /// <summary>
    /// Interaction logic for ApplicationDataSettingsTests.xaml
    /// </summary>
    public partial class ApplicationDataSettingsTests : Window
    {
        ApplicationDataContainer data = null;

        public ApplicationDataSettingsTests()
        {
            

            

            InitializeComponent();

            Loaded += ApplicationDataSettingsTests_Loaded;

        }

        private void ApplicationDataSettingsTests_Loaded(object sender, RoutedEventArgs eventArgs)
        {
            
            

            chbl.Init(ImageButtonsInit.OnlySelect, new List<string>());

            data = new ApplicationDataContainer();
            data.Add(cb);
            data.Add(chb);



            data.Add(chbl);
        }

        protected override void OnClosing(CancelEventArgs eventArgs)
        {
            base.OnClosing(eventArgs);

            var indexes = chbl.CheckedIndexes();

            int index = 0;
        }
    }
}
