#define ASYNC
namespace SunamoWpf;

public class XamlSerializer
{
    static Type type = typeof(XamlSerializer);
    Window w = null;
    string path = null;
    /// <summary>
    /// Is Used from Name, A1 is only for showing Exception
    /// path: path = AppData.ci.GetFile(AppFolders.Controls, name);
    /// </summary>
    /// <param name="nameWindow"></param>
    /// <param name="window"></param>
    public XamlSerializer(Window window)
    {
        var name = window.GetType().Name;
        //ThrowEx.NameIsNotSetted(Exc.GetStackTrace(),type, "ctor", nameWindow, w.Name);
        this.w = window;
        window.Loaded += new RoutedEventHandler(MainWindow_Loaded);
        window.Closing += new CancelEventHandler(MainWindow_Closing);
    }
    void MainWindow_Loaded(object sender, RoutedEventArgs eventArgs)
    {
        LoadExternalXaml();
    }
    void MainWindow_Closing(object sender, CancelEventArgs eventArgs)
    {
        SaveExternalXaml();
    }
    public void LoadExternalXaml()
    {
        if (FS.ExistsFile(path))
        {
            using (FileStream stream = new FileStream(path, FileMode.Open))
            {
                w.Content = XamlReader.Load(stream);
            }
        }
    }
    public void SaveExternalXaml()
    {
        using (FileStream stream = new FileStream(path, FileMode.Create))
        {
            XamlWriter.Save(w.Content, stream);
        }
    }
}