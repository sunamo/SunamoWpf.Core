namespace SunamoWpf.Args;

/// <summary>
/// Represents the event on args type.
/// </summary>
public class EventOnArgs
{
    /// <summary>
    /// The all false.
    /// </summary>
    public static EventOnArgs allFalse= new EventOnArgs(false);
    /// <summary>
    /// The all false only check on.
    /// </summary>
    public static EventOnArgs allFalseOnlyCheckOn= new EventOnArgs(true, true, false, false, false, false);

    /// <summary>
    /// Initializes a new instance of the event on args class.
    /// </summary>
    public EventOnArgs()
    {

    }

    /// <summary>
    /// Initializes a new instance of the event on args class.
    /// </summary>
    /// <param name="value">The value.</param>
    public EventOnArgs(bool value)
    {
        SetAllFor(value);
    }

    /// <summary>
    /// Set all for.
    /// </summary>
    /// <param name="value">The value.</param>
    public void SetAllFor(bool value)
    {
        onCheck = value;
        onUnCheck = value;
        onAdd = value;
        onRemove = value;
        onClear = value;
        onPropertyChanged = value;
    }

    /// <summary>
    /// Initializes a new instance of the event on args class.
    /// </summary>
    /// <param name="onCheck">The on check.</param>
    /// <param name="onUnCheck">The on un check.</param>
    /// <param name="onAdd">The on add.</param>
    /// <param name="onRemove">The on remove.</param>
    /// <param name="onClear">The on clear.</param>
    /// <param name="onPropertyChanged">The on property changed.</param>
    public EventOnArgs(bool onCheck, bool onUnCheck, bool onAdd, bool onRemove, bool onClear, bool onPropertyChanged)
    {
        this.onCheck = onCheck;
        this.onUnCheck = onUnCheck;
        this.onAdd = onAdd;
        this.onRemove = onRemove;
        this.onClear = onClear;
        this.onPropertyChanged = onPropertyChanged;
    }

    /// <summary>
    /// Gets or sets the on check.
    /// </summary>
    public bool onCheck;

    /// <summary>
    /// Gets or sets the on un check.
    /// </summary>
    public bool onUnCheck;

    /// <summary>
    /// Gets or sets the on add.
    /// </summary>
    public bool onAdd;

    /// <summary>
    /// Gets or sets the on remove.
    /// </summary>
    public bool onRemove;

    /// <summary>
    /// Gets or sets the on clear.
    /// </summary>
    public bool onClear;

    /// <summary>
    /// Gets or sets the on property changed.
    /// </summary>
    public bool onPropertyChanged;

    /// <summary>
    /// Is something true.
    /// </summary>
    /// <returns>The is something true result.</returns>
    public bool IsSomethingTrue()
    {
        if (onCheck)
        {
            return true;
        }
        if (onUnCheck)
        {
            return true;
        }
        if (onAdd)
        {
            return true;
        }
        if (onRemove)
        {
            return true;
        }
        if (onClear)
        {
            return true;
        }
        if (onPropertyChanged)
        {
            return true;
        }
        return false;
    }
}