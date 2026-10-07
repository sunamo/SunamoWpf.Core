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

public class InlineBuilderBlockTests : UserControl
{
    public InlineBuilderBlockTests()
    {
        FixedDocument fixedDocument = new FixedDocument();
        Paragraph paragraph = new Paragraph();

        InlineBuilderBlock block = new InlineBuilderBlock(paragraph);
        block.H1("Hello world");
        block.Hyperlink("EN blog", "https://blog.sunamo.cz/2020/06/24/structure-of-flow-text-in-wpf/");
        block.LineBreak();
        block.Run("Perfect!");

        #region FixedDocument
        //FixedPage fp = new FixedPage();
        //fp.Children.Add(p);

        //PageContent pc = new PageContent();
        //pc.Child = fp;

        //fd.Pages.Add(pc); 
        #endregion

        //Content = fd;
    }
}
