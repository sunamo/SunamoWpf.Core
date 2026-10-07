namespace SunamoWpf._public;

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

    protected override bool IsComparingByString()
    {
        return allowNull.HasValue && allowNull.Value;
    }

    internal override bool? Contains(T item)
    {
        return c.Contains(item);
    }
}