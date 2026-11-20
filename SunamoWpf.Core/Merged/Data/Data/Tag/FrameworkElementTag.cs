namespace SunamoWpf.Data.Tag;

/// <summary>
/// Represents the framework element tag type.
/// </summary>
public class FrameworkElementTag
{
    /// <summary>
    /// Tag which is set in CheckBoxListUC to avoid replace of other tag
    /// 
    /// </summary>
    public object tagCheckBoxListUC = null;
    /// <summary>
    /// Sub for default Tag of fw element
    /// </summary>
    public object Tag = null;

    /// <summary>
    /// To string.
    /// </summary>
    /// <returns>The to string result.</returns>
    public override string ToString()
    {
        return Tag.ToString();
    }
}