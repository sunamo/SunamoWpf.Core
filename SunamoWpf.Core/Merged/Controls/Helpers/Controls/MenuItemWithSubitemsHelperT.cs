#define ASYNC
namespace SunamoWpf.Controls.Helpers.Controls;

/// <summary>
/// Generická třída třídy TSDDBH - ToolStripDropDownButtonHelper
/// </summary>
/// <typeparam name="T"></typeparam>
public class SuMenuItemWithSubitemsHelper<T> : SuMenuItemWithSubitemsHelper
{
    /// <summary>
    /// Initializes a new instance of the su menu item with subitems helper class.
    /// </summary>
    /// <param name="tsddb">The tsddb.</param>
    public SuMenuItemWithSubitemsHelper(SuMenuItem tsddb)
        : base(tsddb, true)
    { }
    /// <summary>
    /// Initializes a new instance of the su menu item with subitems helper class.
    /// </summary>
    /// <param name="tsddb">The tsddb.</param>
    /// <param name="values">The values.</param>
    /// <param name="defaultValue">The default value.</param>
    public SuMenuItemWithSubitemsHelper(SuMenuItem tsddb, Array values, T defaultValue)
        : base(tsddb, true)
    {
        if (tsddb.ToolTip == null)
        {
            originalToolTipText = "";
        }
        else
        {
            originalToolTipText = tsddb.ToolTip.ToString();
        }
        AddValuesOfEnumAsItems(values, false);
        SelectedO = defaultValue;
        prev = GetItemWithTag(defaultValue);
        tsddb.ToolTip = originalToolTipText + " " + defaultValue.ToString();
    }
    private SuMenuItem GetItemWithTag(T defaultValue)
    {
        foreach (SuMenuItem item in tsddb.Items)
        {
            if (item.Tag.ToString() == defaultValue.ToString())
            {
                return item;
            }
        }
        return null;
    }
    /// <summary>
    /// The selected enum value.
    /// </summary>
    public T SelectedEnumValue
    {
        get
        {
            if (Selected)
            {
                return (T)Enum.Parse(typeof(T), SelectedS);
            }
            return default(T);
        }
    }
    /// <summary>
    /// Add values of enum as items.
    /// </summary>
    /// <param name="value">The value.</param>
    public void AddValuesOfEnumAsItems(T value)
    {
        base.AddValuesOfEnumAsItems<T>(value);
    }
}