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

namespace Wpf.Tests.Collections
{

    public partial class NotifyChangesCollectionTests : UserControl
    {
        //public NotifyChangesCollection<NotifyPropertyChangedWrapper<CheckBox>> l = null;

        public NotifyChangesCollectionTests()
        {
            InitializeComponent();

            Loaded += NotifyChangesCollection_Loaded;
        }

        private void NotifyChangesCollection_Loaded(object sender, RoutedEventArgs e)
        {
            //l = new NotifyChangesCollection<NotifyPropertyChangedWrapper<CheckBox>>(this, new ObservableCollection<NotifyPropertyChangedWrapper<CheckBox>>());

            chbl.Init();
            var l = chbl.l;

            for (int i = 0; i < 10; i++)
            {
                l.Add(c(i));
            }

            chbl.lb.ItemsSource = l.l;
        }

        NotifyPropertyChangedWrapper<CheckBox> c(int i)
        {
            var s = i.ToString();
            var chb = CheckBoxHelper.Get(new ControlInitData { content = s, tag = s });
            NotifyPropertyChangedWrapper<CheckBox> d = new NotifyPropertyChangedWrapper<CheckBox>(chb, CheckBox.IsCheckedProperty);
            return d;
        }

    }
}
