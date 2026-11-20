#define ASYNC
namespace SunamoWpf.Helpers.Controls;

/// <summary>
/// Represents the toolbar helper type.
/// </summary>
public static class ToolbarHelper
{
    /// <summary>
    /// Add button.
    /// </summary>
    /// <param name="tsAkce">The ts akce.</param>
    /// <param name="imageOnButton">The image on button.</param>
    /// <param name="tooltip">The tooltip.</param>
    /// <param name="commandBinding">The command binding.</param>
    /// <param name="whImage">The wh image.</param>
    /// <param name="whButton">The wh button.</param>
    public static void AddButton(ToolBar tsAkce, ImageSource imageOnButton, string tooltip, CommandBinding commandBinding, int whImage, int whButton)
    {
        Button button = new Button();
        button.Width = whButton;
        button.Height = whButton;
        button.ToolTip = tooltip;
        Image image = new Image(); //ImageHelper.ReturnImage(UnknownCacheImage);
        image.Source = imageOnButton;
        image.Width = whImage;
        image.Height = whImage;
        button.Content = image;
        button.Command = commandBinding.Command;
        tsAkce.Items.Add(button);
    }

    /// <summary>
    /// Add button.
    /// </summary>
    /// <param name="tsAkce">The ts akce.</param>
    /// <param name="imageOnButton">The image on button.</param>
    /// <param name="tooltip">The tooltip.</param>
    /// <param name="handler">The handler.</param>
    /// <param name="whImage">The wh image.</param>
    /// <param name="whButton">The wh button.</param>
    public static void AddButton(ToolBar tsAkce, ImageSource imageOnButton, string tooltip, RoutedEventHandler handler, int whImage, int whButton)
    {
        Button button = new Button();
        AddButton(tsAkce, imageOnButton, tooltip, handler, whImage, whButton, button);
    }

    /// <summary>
    /// Add toggle button.
    /// </summary>
    /// <param name="tsAkce">The ts akce.</param>
    /// <param name="imageOnButton">The image on button.</param>
    /// <param name="tooltip">The tooltip.</param>
    /// <param name="handler">The handler.</param>
    /// <param name="whImage">The wh image.</param>
    /// <param name="whButton">The wh button.</param>
    /// <param name="isChecked">The is checked.</param>
    public static void AddToggleButton(ToolBar tsAkce, ImageSource imageOnButton, string tooltip, RoutedEventHandler handler, int whImage, int whButton, bool isChecked)
    {
        ToggleButton button = new ToggleButton();
        button.IsChecked = isChecked;
        AddButton(tsAkce, imageOnButton, tooltip, handler, whImage, whButton, button);
    }

    private static void AddButton(ToolBar tsAkce, ImageSource imageOnButton, string tooltip, RoutedEventHandler handler, int whImage, int whButton, ButtonBase button)
    {
        button.Width = whButton;
        button.Height = whButton;
        button.ToolTip = tooltip;
        Image image = new Image();  //ImageHelper.ReturnImage(UnknownCacheImage);
        image.Source = imageOnButton;
        image.Width = whImage;
        image.Height = whImage;
        button.Content = image;
        button.Click += handler;
        tsAkce.Items.Add(button);
    }
}