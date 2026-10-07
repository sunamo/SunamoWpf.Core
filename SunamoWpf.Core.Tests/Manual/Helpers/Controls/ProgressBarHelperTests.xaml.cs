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

namespace Wpf.Tests.Helpers.Controls
{
    /// <summary>
    /// Interaction logic for ProgressBarHelperTests.xaml
    /// </summary>
    public partial class ProgressBarHelperTests : UserControl
    {
        ProgressBarHelper pbh;

        public ProgressBarHelperTests()
        {
            InitializeComponent();

            Background = Brushes.LightBlue;

            pbh = new ProgressBarHelper(pb, 10, this);
            
            ParameterizedThreadStart threadStart = new ParameterizedThreadStart(LoadInThread);
            Thread thread = new Thread(threadStart) { IsBackground = true };
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start(null);
        }

        void LoadInThread(object state)
        {
            for (int index = 0; index < 10; index++)
            {
                pbh.DonePartially();
                Thread.Sleep(100);
            }
            pbh.Done();
            pb.Visibility = Visibility.Collapsed;
        }
    }
}
