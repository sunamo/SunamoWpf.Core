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

    public partial class SettingsWindow : Window//, IWindowWithSettingsManager
    {
        const string s = "Number";
        Random random = new Random();
        WpfStateSettings mus = null;

        private void button2_Click(object sender, RoutedEventArgs eventArgs)
        {
            int randomNumber = random.Next(999);
            mus[s] = randomNumber;
            SetToTb();
        }

        private void SetToTb()
        {
            // TODO: Osetrit kdyz nebude, nemusi vzdycky byt
            tb.Text = mus[s].ToString();
        }

        public SettingsWindow()
        {
            InitializeComponent();

            var settings = new WpfStateSettings();
            var settingsManager = new SettingsManager(settings, settings.Providers);
            settingsManager.customProperties.Add(s, 0);

            mus = settings;
            AppSettingsManager.SettingsManager = settingsManager;

            //WpfStateHelper.AddControls(sp, "CheckBox", "TextBox");
            
            Loaded += SettingsWindow_Loaded;

        }

        private void SettingsWindow_Loaded(object sender, RoutedEventArgs eventArgs)
        {
            AppSettingsManager.AddChildrenFrom(this);

            AppSettingsManager.LoadSettings();
        }

        

        protected override void OnClosing(CancelEventArgs eventArgs)
        {
            base.OnClosing(eventArgs);

            AppSettingsManager.SaveSettings();
        }


    }
}
