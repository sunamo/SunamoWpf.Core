namespace SunamoWpf.Enums;

/// <summary>
/// Represents the list operation type.
/// </summary>
public enum ListOperation
{
    /// <summary>
    /// The remove at value.
    /// </summary>
    RemoveAt,
    /// <summary>
    /// The insert value.
    /// </summary>
    Insert,
    /// <summary>
    /// The add value.
    /// </summary>
    Add,
    /// <summary>
    /// The remove value.
    /// </summary>
    Remove,
    /// <summary>
    /// The clear value.
    /// </summary>
    Clear,
    /// <summary>
    /// Property in item
    /// like IsChecked of CheckBox
    /// </summary>
    PropertyChanged,
    /// <summary>
    /// The checked value.
    /// </summary>
    Checked,
    /// <summary>
    /// The unchecked value.
    /// </summary>
    Unchecked
}