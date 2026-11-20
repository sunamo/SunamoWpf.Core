namespace SunamoWpf.Data;

/// <summary>
/// Represents the check box data t type.
/// </summary>
public class CheckBoxData<T>
{
    /// <summary>
    ///     Na to co se má zobrazit
    /// </summary>
    public T t = default;

    /// <summary>
    ///     Set to IsChecked when TwoWayTable.DataCellWrapper == AddBeforeControl.CheckBox
    /// </summary>
    public bool? tick = false;
}