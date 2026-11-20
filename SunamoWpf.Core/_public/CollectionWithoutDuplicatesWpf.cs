namespace SunamoWpf._public;

/// <summary>
/// Represents the collection without duplicates wpf t type.
/// </summary>
public class CollectionWithoutDuplicatesWpf<T> : CollectionWithoutDuplicatesBase<T>
{
    internal CollectionWithoutDuplicatesWpf()
    {
    }

    internal CollectionWithoutDuplicatesWpf(int count) : base(count)
    {
    }

    internal CollectionWithoutDuplicatesWpf(IList<T> items) : base(items)
    {
    }

    /// <summary>
    /// Is comparing by string.
    /// </summary>
    /// <returns>The is comparing by string result.</returns>
    protected override bool IsComparingByString()
    {
        return allowNull.HasValue && allowNull.Value;
    }

    internal override bool? Contains(T item)
    {
        return c.Contains(item);
    }
}