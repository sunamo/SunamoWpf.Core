namespace SunamoWpf._shared;

public class DependencyReflection
{
    #region Dependency
    public IList<DependencyProperty> GetAttachedProperties(DependencyObject obj)
    {
        List<DependencyProperty> result = new List<DependencyProperty>();

        foreach (PropertyDescriptor pd in TypeDescriptor.GetProperties(obj,
            new Attribute[] { new PropertyFilterAttribute(PropertyFilterOptions.All) }))
        {
            DependencyPropertyDescriptor dpd =
                DependencyPropertyDescriptor.FromProperty(pd);

            if (dpd != null)
            {
                result.Add(dpd.DependencyProperty);
            }
        }

        return result;
    }
    #endregion
}