namespace SunamoWpf.Args;

public class EventOnArgs
{
    public static EventOnArgs allFalse= new EventOnArgs(false);
    public static EventOnArgs allFalseOnlyCheckOn= new EventOnArgs(true, true, false, false, false, false);

    public EventOnArgs()
    {

    }

    public EventOnArgs(bool value)
    {
        SetAllFor(value);
    }

    public void SetAllFor(bool value)
    {
        onCheck = value;
        onUnCheck = value;
        onAdd = value;
        onRemove = value;
        onClear = value;
        onPropertyChanged = value;
    }

    public EventOnArgs(bool onCheck, bool onUnCheck, bool onAdd, bool onRemove, bool onClear, bool onPropertyChanged)
    {
        this.onCheck = onCheck;
        this.onUnCheck = onUnCheck;
        this.onAdd = onAdd;
        this.onRemove = onRemove;
        this.onClear = onClear;
        this.onPropertyChanged = onPropertyChanged;
    }

    public bool onCheck; public bool onUnCheck; public bool onAdd; public bool onRemove; public bool onClear; public bool onPropertyChanged;

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