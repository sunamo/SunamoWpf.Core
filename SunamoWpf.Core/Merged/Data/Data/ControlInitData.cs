namespace SunamoWpf.Data;

/// <summary>
/// Represents the routed event handler async type.
/// </summary>
public delegate Task RoutedEventHandlerAsync(object sender, RoutedEventArgs eventArgs);
/// <summary>
/// Represents the control init data type.
/// </summary>
public class ControlInitData
{
    #region Sort by alphabet (same as in intellisense popup)
    /// <summary>
    /// The xlf key.
    /// </summary>
    public string xlfKey = null;
    /// <summary>
    /// The action.
    /// </summary>
    public ButtonAction action;
    /// <summary>
    /// The checkable.
    /// </summary>
    public bool checkable = false;
    /// <summary>
    /// The content.
    /// </summary>
    public object content = null;
    /// <summary>
    /// Cant be null
    /// Otherwise control is invisible!
    /// </summary>
    public Brush foreground = Brushes.Black;
    /// <summary>
    /// The group.
    /// </summary>
    public string group = null;
    /// <summary>
    /// FontSize when is used Awesome
    /// </summary>
    public double imageHeight = 16;
    /// <summary>
    /// BitmapImage (from EmbeddedResources for example) or string pack:///
    /// </summary>
    public object imagePath = null;
    /// <summary>
    /// The is checked.
    /// </summary>
    public bool isChecked = false;
    /// <summary>
    /// The image width.
    /// </summary>
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
    /// <summary>
    /// The on click async.
    /// </summary>
    public RoutedEventHandlerAsync OnClickAsync = null;
    /// <summary>
    /// The mouse down.
    /// </summary>
    public MouseButtonEventHandler MouseDown = null;
    /// <summary>
    /// The tag.
    /// </summary>
    public object tag = null;
    /// <summary>
    /// The name.
    /// </summary>
    public string name = null;
    /// <summary>
    /// The tooltip.
    /// </summary>
    public string tooltip = null;
    /// <summary>
    /// The is editable.
    /// </summary>
    public bool isEditable = false;
    /// <summary>
    /// The on text change.
    /// </summary>
    public TextChangedEventHandler OnTextChange;
    /// <summary>
    /// Good for menu items but bad for checkboxes etc. (MoveToPa case)
    /// </summary>
    public double addPadding = 0;
    /// <summary>
    /// The text.
    /// </summary>
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