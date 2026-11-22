namespace SunamoWpf._shared;

/// <summary>
/// Represents the dependency reflection type.
/// </summary>
public class DependencyReflection
{
    #region Dependency
    /// <summary>
    /// Get attached properties.
    /// </summary>
    /// <param name="obj">The obj.</param>
    /// <returns>The get attached properties result.</returns>
    public IList<DependencyProperty> GetAttachedProperties(DependencyObject obj)
    {
        List<DependencyProperty> result = new List<DependencyProperty>();

        foreach (PropertyDescriptor propertyDescriptor in TypeDescriptor.GetProperties(obj,
            new Attribute[] { new PropertyFilterAttribute(PropertyFilterOptions.All) }))
        {
            DependencyPropertyDescriptor dpd =
                DependencyPropertyDescriptor.FromProperty(propertyDescriptor);

            if (dpd != null)
            {
                result.Add(dpd.DependencyProperty);
            }
        }

        return result;
    }
    #endregion
}