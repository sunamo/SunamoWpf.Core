namespace SunamoWpf.Data;

/// <summary>
/// Represents the image buttons init type.
/// </summary>
public class ImageButtonsInit
{
    /// <summary>
    /// Gets or sets the copy to clipboard.
    /// </summary>
    public object copyToClipboard = null;

    /// <summary>
    /// Gets or sets the clear.
    /// </summary>
    public object clear = null;

    /// <summary>
    /// Gets or sets the add.
    /// </summary>
    public object add = null;

    /// <summary>
    /// Gets or sets the select all.
    /// </summary>
    public object selectAll = null;

    /// <summary>
    /// Gets or sets the deselect all.
    /// </summary>
    public object deselectAll = null;

    /// <summary>
    /// If everything is null
    /// </summary>
    public ImageButtonsInit()
    {

    }

    /// <summary>
    /// all is object = can be true, false or new VoidString(ColButtons_Added) for example
    /// </summary>
    /// <param name="copyToClipboard"></param>
    /// <param name="clear"></param>
    /// <param name="add"></param>
    /// <param name="selectAll"></param>
    /// <param name="deselectAll"></param>
    public ImageButtonsInit(object copyToClipboard, object clear, object add, object selectAll, object deselectAll)
    {
        this.copyToClipboard = copyToClipboard;
        this.clear = clear;
        this.add = add;
        this.selectAll = selectAll;
        this.deselectAll = deselectAll;
    }

    /// <summary>
    /// visible: add, selectAll, deselectAll
    /// </summary>
    //public static ImageButtonsInit DefaultButtons = new ImageButtonsInit(false, false, new VoidString(ColButtons_Added), true, true);
    public static ImageButtonsInit HideAllButtons = new ImageButtonsInit(false, false, false, false, false);
    /// <summary>
    /// The only select.
    /// </summary>
    public static ImageButtonsInit OnlySelect = new ImageButtonsInit(false, false, false, true, true);

    /// <summary>
    /// A1 can be new VoidString(ColButtons_Added)
    /// </summary>
    /// <param name="vs"></param>
    /// <returns></returns>
    public static ImageButtonsInit ShowAllButtons(VoidString ColButtons_Added)
    {
        return new ImageButtonsInit(true, true, ColButtons_Added, true, true);
    }
}