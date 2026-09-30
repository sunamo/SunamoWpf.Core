namespace SunamoWpf.Data;

public delegate Task RoutedEventHandlerAsync(object sender, RoutedEventArgs e);
public class ControlInitData
{
    #region Sort by alphabet (same as in intellisense popup)
    public string xlfKey = null;
    public ButtonAction action;
    public bool checkable = false;
    public object content = null;
    /// <summary>
    /// Cant be null
    /// Otherwise control is invisible!
    /// </summary>
    public Brush foreground = Brushes.Black;
    public string group = null;
    /// <summary>
    /// FontSize when is used Awesome
    /// </summary>
    public double imageHeight = 16;
    /// <summary>
    /// BitmapImage (from EmbeddedResources for example) or string pack:///
    /// </summary>
    public object imagePath = null;
    public bool isChecked = false;
    public double imageWidth = 16;
    /// <summary>
    /// Used in ComboBox and SuMenuItem => must be IList do Add()
    /// In SuMenuItem it is ControlInitData, not SuMenuItem
    /// </summary>
    public IList list = null;
    /// <summary>
    /// Only for Click, not Checked etc!
    /// </summary>
    public RoutedEventHandler OnClick = null;
    public RoutedEventHandlerAsync OnClickAsync = null;
    public MouseButtonEventHandler MouseDown = null;
    public object tag = null;
    public string name = null;
    public string tooltip = null;
    public bool isEditable = false;
    public TextChangedEventHandler OnTextChange;
    /// <summary>
    /// Good for menu items but bad for checkboxes etc. (MoveToPa case)
    /// </summary>
    public double addPadding = 0;
    public string text
    {
        get
        {
            if (content != null)
            {
                return content.ToString();
            }
            return null;
        }
        set
        {
            content = value;
        }
    }
    #endregion
}