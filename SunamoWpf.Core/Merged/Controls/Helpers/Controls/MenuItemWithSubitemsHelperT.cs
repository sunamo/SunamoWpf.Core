#define ASYNC
namespace SunamoWpf.Controls.Helpers.Controls;

/// <summary>
/// Generická třída třídy TSDDBH - ToolStripDropDownButtonHelper
/// </summary>
/// <typeparam name="T"></typeparam>
public class SuMenuItemWithSubitemsHelper<T> : SuMenuItemWithSubitemsHelper
{
    public SuMenuItemWithSubitemsHelper(SuMenuItem tsddb)
        : base(tsddb, true)
    { }
    public SuMenuItemWithSubitemsHelper(SuMenuItem tsddb, Array bs, T defaultValue)
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
        AddValuesOfEnumAsItems(bs, false);
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
    public void AddValuesOfEnumAsItems(T t)
    {
        base.AddValuesOfEnumAsItems<T>(t);
    }
}