#define ASYNC
namespace SunamoWpf.Controls.Collections;

public partial class LoggerUC : UserControl, ISaveWithoutArgWpf
{
    #region Rewrite to pure cs. With xaml is often problems without building
    public LoggerUC()
    {
        try
        {
            InitializeComponent();
        }
        catch (Exception)
        {
#if DEBUG
            Debugger.Break();
#endif
        }
        Loaded += LoggerUC_Loaded;
    }
    private void LoggerUC_Loaded(object sender, RoutedEventArgs eventArgs)
    {
        AwesomeFontControls.SetAwesomeFontSymbol(BtnClear, "\uf00d"); // async Task nelze RunSynchronously (InvalidOperationException); symbol se nastavi pres Dispatcher.InvokeAsync
        AwesomeFontControls.SetAwesomeFontSymbol(BtnCopyToClipboard, "\uf0c5"); // async Task nelze RunSynchronously (InvalidOperationException); symbol se nastavi pres Dispatcher.InvokeAsync
    }
    private void BtnClear_Click(object sender, RoutedEventArgs eventArgs)
    {
        lbLogs.Children.Clear();
    }
    private void BtnCopyToClipboard_Click(object sender, RoutedEventArgs eventArgs)
    {
        List<string> result = Lines();
        ClipboardHelper.SetLines(result);
        //SunamoTemplateLogger.Instance.CopiedToClipboard(Translate.FromKey(XlfKeys.logs));
    }
    private List<string> Lines()
    {
        List<string> result = new List<string>(lbLogs.Children.Count);
        foreach (var item in lbLogs.Children)
        {
            result.Add(((TextBlock)item).Text);
        }
        return result;
    }
    public string fileToSave = null;
    public void Save(string fileToSave)
    {
        //fileToSave = AppData.ci.GetFile(AppFolders.Logs, this.Name + AllExtensions.txt);
        this.fileToSave = fileToSave;
        var lines = Lines();

        // synchronni rozhrani ISaveWithoutArgWpf: Task.Run, aby await uvnitr TF nedeadlockoval UI vlakno
        Task.Run(() => TF.WriteAllLines(fileToSave, lines)).GetAwaiter().GetResult();
    }
}
#endregion
