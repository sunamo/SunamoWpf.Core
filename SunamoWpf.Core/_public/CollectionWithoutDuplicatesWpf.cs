namespace SunamoWpf._public;

public class CollectionWithoutDuplicatesWpf<T> : CollectionWithoutDuplicatesBase<T>
{
    internal CollectionWithoutDuplicatesWpf()
    {
    }

    internal CollectionWithoutDuplicatesWpf(int count) : base(count)
    {
    }

    internal CollectionWithoutDuplicatesWpf(IList<T> l) : base(l)
    {
    }

    protected override bool IsComparingByString()
    {
        return allowNull.HasValue && allowNull.Value;
    }

    internal override bool? Contains(T t2)
    {
        return c.Contains(t2);
    }
}