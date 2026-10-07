#define ASYNC
namespace SunamoWpf.Helpers.BaseControls;

public static class DependencyObjectHelper
{
    public static object MarkupWriter { get; private set; }

    public static List<DependencyProperty> GetDependencyProperties(object element)
    {
        List<DependencyProperty> properties = new List<DependencyProperty>();
        MarkupObject markupObject = System.Windows.Markup.Primitives.MarkupWriter.GetMarkupObjectFor(element);
        if (markupObject != null)
        {
            foreach (MarkupProperty property in markupObject.Properties)
            {
                if (property.DependencyProperty != null)
                {
                    properties.Add(property.DependencyProperty);
                }
            }
        }

        return properties;
    }

    /// <summary>
    /// Return only real atteched in App
    /// Subtype of dependency property
    /// It's property as Grid.Row etc.
    /// </summary>
    /// <param name="element"></param>
    public static List<DependencyProperty> GetAttachedProperties(object element)
    {
        List<DependencyProperty> attachedProperties = new List<DependencyProperty>();
        MarkupObject markupObject = System.Windows.Markup.Primitives.MarkupWriter.GetMarkupObjectFor(element);
        if (markupObject != null)
        {
            foreach (MarkupProperty property in markupObject.Properties)
            {
                if (property.IsAttached)
                {
                    attachedProperties.Add(property.DependencyProperty);
                }
            }
        }

        return attachedProperties;
    }

    public static T CreatedWithCopiedValues<T>(T source, params DependencyProperty[] properties) where T : DependencyObject
    {
        dynamic expando = new System.Dynamic.ExpandoObject();
        expando.t = source;
        expando.p = properties;

        CreatedWithCopiedValuesWorker(expando);

        //Thread thread = new Thread(new ParameterizedThreadStart( ));
        //thread.SetApartmentState(ApartmentState.STA); //Set the thread to STA
        //thread.Start( d);
        //thread.Join(); //Wait for the thread to end <== here will be froze

        return (T)expando.r;
    }

    static void CreatedWithCopiedValuesWorker(object source)
    {
        dynamic data = source;
        object instance = null;
        WpfApp.cd.Invoke(() =>
        {

            instance = Activator.CreateInstance(data.t.GetType());
            foreach (var item in data.p)
            {
                object value = null;
                value = data.t.GetValue(item); ;
                (instance as DependencyObject).SetValue(item, value);
            }
        });
        data.r = instance;
    }
}