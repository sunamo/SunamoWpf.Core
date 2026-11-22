#define ASYNC
namespace SunamoWpf.Controls.ToolBar;

/// <summary>
/// Represents the text image relation type.
/// </summary>
public enum TextImageRelation
{
    /// <summary>
    /// The image above text value.
    /// </summary>
    ImageAboveText,
    /// <summary>
    /// The image before text value.
    /// </summary>
    ImageBeforeText
}

/// <summary>
/// Represents the tool strip button type.
/// </summary>
public class ToolStripButton : ToggleButton
{
    /// <summary>
    /// The image property.
    /// </summary>
    public static readonly DependencyProperty ImageProperty = DependencyProperty.Register("Image", typeof(ImageSource), typeof(ToolStripButton));
    /// <summary>
    /// The text property.
    /// </summary>
    public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(ToolStripButton));
    //public static readonly DependencyProperty CheckedProperty = DependencyProperty.Register("Checked", typeof(bool), typeof(ToolStripButton));
    /// <summary>
    /// The check on click property.
    /// </summary>
    public static readonly DependencyProperty CheckOnClickProperty = DependencyProperty.Register("CheckOnClick", typeof(bool), typeof(ToolStripButton));
    //public static readonly DependencyProperty EnabledProperty = DependencyProperty.Register("Enabled", typeof(bool), typeof(ToolStripButton));
    /// <summary>
    /// The text image relation property.
    /// </summary>
    public static readonly DependencyProperty TextImageRelationProperty = DependencyProperty.Register("TextImageRelation", typeof(TextImageRelation), typeof(ToolStripButton), new PropertyMetadata(TextImageRelation.ImageAboveText));
    /// <summary>
    /// The fixed image size property.
    /// </summary>
    public static readonly DependencyProperty FixedImageSizeProperty = DependencyProperty.Register("FixedImageSize", typeof(Size), typeof(ToolStripButton), new PropertyMetadata(null));
    StackPanel sp = new StackPanel();
    Image image = null;
    TextBlock tb = null;

    static ToolStripButton()
    {

    }

    /// <summary>
    /// On click.
    /// </summary>
    protected override void OnClick()
    {
        base.OnClick();


    }

    /// <summary>
    /// On checked.
    /// </summary>
    /// <param name="eventArgs">The event args.</param>
    protected override void OnChecked(RoutedEventArgs eventArgs)
    {
        base.OnChecked(eventArgs);

        if (CheckOnClick)
        {
            //IsChecked = !IsChecked;
        }
    }


    #region MyRegion
    #endregion

    /// <summary>
    /// Initializes a new instance of the tool strip button class.
    /// </summary>
    /// <param name="image">The image.</param>
    /// <param name="text">The text.</param>
    public ToolStripButton(ImageSource image, string text)
    {
        Image = image;
        Text = text;
    }

    /// <summary>
    /// Initializes a new instance of the tool strip button class.
    /// </summary>
    /// <param name="image">The image.</param>
    public ToolStripButton(ImageSource image)
    {
        Image = image;
    }

    /// <summary>
    /// Initializes a new instance of the tool strip button class.
    /// </summary>
    /// <param name="text">The text.</param>
    public ToolStripButton(string text)
    {
        Text = text;
    }

    /// <summary>
    /// The image.
    /// </summary>
    public ImageSource Image
    {
        get
        {
            return (ImageSource)GetValue(ImageProperty);
        }
        set
        {

            SetValue(ImageProperty, value);
            if (Image != null)
            {
                image = new Image();
                image.Source = value;
            }
            else
            {
                image = null;
            }
            Invalidate();
        }
    }

    /// <summary>
    /// The text.
    /// </summary>
    public string Text
    {
        get
        {
            return (string)GetValue(TextProperty);
        }
        set
        {
            SetValue(TextProperty, value);
            if (Text != null)
            {
                tb = new TextBlock();
                tb.TextAlignment = TextAlignment.Center;
                tb.Text = value;
            }
            else
            {
                tb = null;
            }
            Invalidate();
        }
    }

    /// <summary>
    /// The check on click.
    /// </summary>
    public bool CheckOnClick
    {
        get
        {
            return (bool)GetValue(CheckOnClickProperty);
        }
        set
        {
            SetValue(CheckOnClickProperty, value);
        }
    }

    /// <summary>
    /// The text image relation.
    /// </summary>
    public TextImageRelation TextImageRelation
    {
        get
        {
            return (TextImageRelation)GetValue(TextImageRelationProperty);
        }
        set
        {
            SetValue(TextImageRelationProperty, value);
            Invalidate();
        }
    }

    private void Invalidate()
    {
        switch (TextImageRelation)
        {
            case TextImageRelation.ImageAboveText:
                sp.Children.Clear();
                //sp.Height = 300;
                sp.Orientation = Orientation.Vertical;
                if (image != null)
                {
                    image.HorizontalAlignment = HorizontalAlignment.Center;
                    //image.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                    image.Width = FixedImageSize.Width;
                    image.Height = FixedImageSize.Height;
                    sp.Children.Add(image);
                }
                if (tb != null)
                {
                    tb.HorizontalAlignment = HorizontalAlignment.Center;
                    //tb.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                    sp.Children.Add(tb);
                }
                else
                {

                }
                break;
            case TextImageRelation.ImageBeforeText:
                break;
            default:
                break;
        }
        sp.Margin = new Thickness(5);
        Content = sp;
        //base.InvalidateVisual();
    }

    /// <summary>
    /// The fixed image size.
    /// </summary>
    public Size FixedImageSize
    {
        get
        {
            return (Size)GetValue(FixedImageSizeProperty);
        }
        set
        {
            SetValue(FixedImageSizeProperty, value);

            Invalidate();
        }
    }
}