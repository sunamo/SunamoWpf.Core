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

namespace Wpf.Tests
{
    /// <summary>
    /// Interaction logic for ResourcesClasses.xaml
    /// </summary>
    public partial class ResourcesClasses : UserControl
    {
        static Type type = typeof(ResourcesClasses);
        public ResourcesClasses()
        {
            InitializeComponent();

            

            Loaded += ResourcesClasses_Loaded;
        }

        private void ResourcesClasses_Loaded(object sender, RoutedEventArgs e)
        {
            

            // Resources image
            imgResource.Source = ResourcesH.ci.GetBitmapImageSource("Resources/Resource.jpg");
            // Resources text
            txtResource.Text = ResourcesH.ci.GetString("Resources/Resource.txt");


            //var typeResourcesSunamo = typeof(sunamo.Properties.Resources);

            //var resourcesSunamo = new EmbeddedResourcesH(typeResourcesSunamo.Assembly, "sunamo");

            //// Will not work - EmbeddedResourcesH is not for loading from sunamo
            ////var sunamo_en_US = EmbeddedResourcesH.ci.GetString("sunamo_en_US");
            ////var sunamo_en_US2 = ResourcesH.ci.GetString("sunamo_en_US");

            //ResourcesHelper rm = ResourcesHelper.Create("sunamo.Properties.Resources", typeResourcesSunamo.Assembly);
            //// 'Could not find any resources appropriate for the specified culture or the neutral culture.  Make sure "sunamo.Properties.Resources.resources" was correctly embedded or linked into assembly "ConsoleApp1" at compile time, or that all the satellite assemblies required are loadable and fully signed.'
            //var s = rm.GetByteArrayAsString("sunamo_cs_CZ");



           // var s4 = BTS.ConvertFromBytesToUtf8(sunamo.Properties.Resources.sunamo_en_US.ToList());
            
        }
    }
}
