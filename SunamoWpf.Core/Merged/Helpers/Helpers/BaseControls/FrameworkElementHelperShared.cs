#define ASYNC
namespace SunamoWpf.Helpers.BaseControls;

public partial class FrameworkElementHelper
{
    public static void SetToolTip(Button btnCopyToClipboard, string xlfKeys)
    {
        btnCopyToClipboard.ToolTip = Translate.FromKey(xlfKeys);
    }

    private static string SaveScreenshot(Visual target, string fileName, string appName = null, string projectName = null)
    {
        // CZ: Pokud nejsou předány hodnoty, použij prázdné stringy
        // EN: If values not provided, use empty strings
        appName = appName ?? string.Empty;
        projectName = projectName ?? string.Empty;
        fileName = PathToScreenshot(fileName, appName, projectName);

        Rect bounds = VisualTreeHelper.GetDescendantBounds(target);

        RenderTargetBitmap renderTarget = new RenderTargetBitmap((Int32)bounds.Width, (Int32)bounds.Height, 96, 96, PixelFormats.Pbgra32);

        DrawingVisual visual = new DrawingVisual();

        using (DrawingContext context = visual.RenderOpen())
        {
            VisualBrush visualBrush = new VisualBrush(target);
            context.DrawRectangle(visualBrush, null, new Rect(new Point(), bounds.Size));
        }

        renderTarget.Render(visual);
        BitmapImageHelper.Save(renderTarget, fileName);

        return fileName;
    }

    /// <summary>
    /// If A1 will be fw, will set Margin
    /// </summary>
    /// <param name = "element"></param>
    /// <param name = "allSides"></param>
    public static void SetMargin(object element, double allSides)
    {
        var frameworkElement = (FrameworkElement)element;
        if (frameworkElement != null)
        {
            frameworkElement.Margin = new Thickness(allSides, allSides, allSides, allSides);
        }
    }

    public static void SetMargin3(object element, double allSides)
    {
        var frameworkElement = (FrameworkElement)element;
        if (frameworkElement != null)
        {
            frameworkElement.Margin = new Thickness(allSides, allSides, allSides, allSides);
        }
    }

    public static void SetAll3Widths(FrameworkElement frameworkElement, double width)
    {
        frameworkElement.Width = frameworkElement.MaxWidth = frameworkElement.MinWidth = width;
    }

    public static void CreateBitmapFromVisual(object sender, RoutedEventArgs eventArgs)
    {
        Visual target = null;
        string fileName = null;

        target = (Window)WpfApp.mp;

        //if (saveSingle.HasValue)
        //{
        //if (saveSingle.Value)
        //{
        ThrowEx.NotImplementedMethod(); // vyřešit později následující řádek
        //fn = WpfApp.mp.actualR.GetType().Name;
        SaveScreenshot(target, fileName);

        var modeType = target.GetType().Assembly.GetTypes().Where(type => type.Name == Translate.FromKey(XlfKeys.Mode)).Single();
        var names = Enum.GetNames(modeType);
        List<string> names_ctor = []; //Enum.GetNames(typeof(MainWindow_Ctor.Mode));

        var skipThese = CAG.ToList<string>("MoveToPa", "SearchCodeElements");

        bool anotherSetMode = false;

        foreach (var item in names)
        {
            string _item = item.ToString();
            if (!names_ctor.Contains(_item))
            {

                if (!anotherSetMode)
                {
                    if (WpfApp.mp.ModeString == _item)
                    {
                        anotherSetMode = true;

                    }
                    continue;
                }
                if (CAG.IsEqualToAnyElement<string>(_item, skipThese))
                {
                    continue;
                }

                try
                {
                    WpfApp.mp.SetMode(item);
                    //var iuc = (IUserControl)WpfApp.mp.actual;
                    break;

                    //iuc.uc_Loaded(null, null);
                    //FrameworkElementHelper.CreateBitmapFromVisual(null, null);
                }
                catch (Exception)
                {
                }
            }
            //}
            //}
            //else
            //{


            //    saveSingle = false;
            //}
        }
    }

    public static string PathToScreenshot(string fileName, string appName, string projectName)
    {
        fileName = Path.Combine(@"E:\vs\" + appName, projectName, FolderConsts.screenshots, fileName + ".png");
        return fileName;
    }
}