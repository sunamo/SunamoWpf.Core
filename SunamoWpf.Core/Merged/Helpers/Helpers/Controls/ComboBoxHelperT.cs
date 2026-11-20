#define ASYNC
namespace SunamoWpf.Helpers.Controls;

/// <summary>
/// Represents the combo box helper t type.
/// </summary>
public class ComboBoxHelper<T> : ComboBoxHelper
{
    

    /// <summary>
    /// Initializes a new instance of the combo box helper class.
    /// </summary>
    /// <param name="tsddb">The tsddb.</param>
    public ComboBoxHelper(ComboBox tsddb)
        : base(tsddb)
    { }

    /// <summary>
    /// Initializes a new instance of the combo box helper class.
    /// </summary>
    /// <param name="tsddb">The tsddb.</param>
    /// <param name="values">The values.</param>
    /// <param name="defaultValue">The default value.</param>
    public ComboBoxHelper(ComboBox tsddb, Array values, T defaultValue)
        : base(tsddb)
    {
        if (tsddb.ToolTip == null)
        {
            originalToolTipText = "";
        }
        else
        {
            originalToolTipText = tsddb.ToolTip.ToString();
        }
        AddValuesOfEnumAsItems(values);
        SelectedO = defaultValue;
        tsddb.SelectedItem = defaultValue;
        tsddb.ToolTip = originalToolTipText + " " + defaultValue.ToString();
    }

    /// <summary>
    /// The selected t.
    /// </summary>
    public T SelectedT
    {
        get
        {
            return (T)ComboBoxHelper.ValueFromTWithNameOrObject( SelectedO);
        }


    }

    
}