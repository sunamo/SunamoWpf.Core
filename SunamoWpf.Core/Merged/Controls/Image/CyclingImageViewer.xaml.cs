#define ASYNC
namespace SunamoWpf;

public partial class CyclingImageViewer : UserControl, IStatusBroadcasterAppendWpf
{
    public StringString OperationAfterEnter = null;
    CyclingCollection<string> imagesPath = new CyclingCollection<string>();
    string act = "";
    public string ActualFile
    {
        get
        {
            return act;
        }
        set
        {
            act = value;
            LoadImage(act);
        }
    }
    public bool IsLoadedAnyImage()
    {
        return imagesPath.c.Count != 0;
    }
    public List<string> AllFiles
    {
        get
        {
            return imagesPath.c;
        }
    }
    public BitmapImage ActualImage = null;
    public bool MakesSpaces
    {
        get
        {
            return imagesPath.MakesSpaces;
        }
        set
        {
            imagesPath.MakesSpaces = value;
        }
    }
    public CyclingImageViewer()
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
    }
    public void KeyUp(object sender, KeyEventArgs eventArgs)
    {
        if (eventArgs.Key == Key.Left)
        {
            Before();
            OnNewStatus("Moved back to photo" + " " + imagesPath.ToString());
        }
        else if (eventArgs.Key == Key.Right)
        {
            Next();
            OnNewStatus("Moved forward to photo" + " " + imagesPath.ToString());
        }
        else if (eventArgs.Key == Key.Enter)
        {
            string copy = string.Copy(ActualFile);
            string result = OperationAfterEnter.Invoke(ActualFile);
            Next();
            if (result == "success")
            {
                OnNewStatus("Byl zmenšen obrázek {0} a nastaven obrázek v dalším pořadí - {1} ({{})", FS.GetFileName(copy), FS.GetFileName(ActualFile), imagesPath.ToString());
            }
        }
    }
    private void OnNewStatus(object value)
    {
        throw new NotImplementedException();
    }
    public void ClearCollection()
    {
        imagesPath.Clear();
        OnNewStatus("ImageCollectionDeleted" + ".");
    }
    public void AddImages(List<string> value)
    {
        if (value.Count > 0)
        {
            imagesPath.AddRange(value);
            ActualFile = imagesPath.SetIretation(0);
        }
        else
        {
            OnNewStatusAppend("No more images loaded because the specified folder did not contain any images" + ".");
        }
    }
    public void Next()
    {
        ActualFile = imagesPath.Next();
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    private void LoadImage(string value)
    {
        ActualImage = new BitmapImage(new Uri(value));
        imgImage.Source = ActualImage;
    }
    public void Before()
    {
        ActualFile = imagesPath.Before();
    }
    public event Action<object, Object[]> NewStatus;
    public void OnNewStatus(string message, params string[] parameters)
    {
        NewStatus(message, parameters);
    }
    public event Action<object, Object[]> NewStatusAppend;
    public void OnNewStatusAppend(string message, params string[] parameters)
    {
        NewStatusAppend(message, parameters);
    }
}
