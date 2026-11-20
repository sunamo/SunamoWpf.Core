#define ASYNC
namespace SunamoWpf;

public partial class CyclingImageViewer : UserControl, IStatusBroadcasterAppendWpf
{
    /// <summary>
    /// The operation after enter.
    /// </summary>
    public StringString OperationAfterEnter = null;
    CyclingCollection<string> imagesPath = new CyclingCollection<string>();
    string act = "";
    /// <summary>
    /// The actual file.
    /// </summary>
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
    /// <summary>
    /// Is loaded any image.
    /// </summary>
    /// <returns>The is loaded any image result.</returns>
    public bool IsLoadedAnyImage()
    {
        return imagesPath.c.Count != 0;
    }
    /// <summary>
    /// The all files.
    /// </summary>
    public List<string> AllFiles
    {
        get
        {
            return imagesPath.c;
        }
    }
    /// <summary>
    /// The actual image.
    /// </summary>
    public BitmapImage ActualImage = null;
    /// <summary>
    /// The makes spaces.
    /// </summary>
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
    /// <summary>
    /// Initializes a new instance of the cycling image viewer class.
    /// </summary>
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
    /// <summary>
    /// Key up.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="eventArgs">The event args.</param>
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
    /// <summary>
    /// Clear collection.
    /// </summary>
    public void ClearCollection()
    {
        imagesPath.Clear();
        OnNewStatus("ImageCollectionDeleted" + ".");
    }
    /// <summary>
    /// Add images.
    /// </summary>
    /// <param name="value">The value.</param>
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
    /// <summary>
    /// Next.
    /// </summary>
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
    /// <summary>
    /// Before.
    /// </summary>
    public void Before()
    {
        ActualFile = imagesPath.Before();
    }
    /// <summary>
    /// The new status.
    /// </summary>
    public event Action<object, Object[]> NewStatus;
    /// <summary>
    /// On new status.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <param name="parameters">The parameters.</param>
    public void OnNewStatus(string message, params string[] parameters)
    {
        NewStatus(message, parameters);
    }
    /// <summary>
    /// The new status append.
    /// </summary>
    public event Action<object, Object[]> NewStatusAppend;
    /// <summary>
    /// On new status append.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <param name="parameters">The parameters.</param>
    public void OnNewStatusAppend(string message, params string[] parameters)
    {
        NewStatusAppend(message, parameters);
    }
}
