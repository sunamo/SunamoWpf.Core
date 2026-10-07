#define ASYNC
namespace SunamoWpf.Helpers.ControlsWithGet;

/// <summary>
/// Must use SelectionChanged of ComboBoxHelper, not ComboBox. Otherwise first in called in Control, then is set into Selected* properties and app goes wrong!!
/// </summary>
public partial class ComboBoxHelper
{
    public static void AddRange2List(ComboBox cbInterpret, IList allInterprets)
    {
        for (int index = 0; index < allInterprets.Count; index++)
        {
            object item = allInterprets[index];
            if (item != null)
            {
                if (item.ToString().Trim() != "")
                {
                    cbInterpret.Items.Add(item);

                }
            }
        }
    }

    public static object ValueFromTWithNameOrObject(object value)
    {
        if (value is TWithNameTWpf<object>)
        {
            return ((TWithNameTWpf<object>)value).t;
        }
        return value;
    }

    public static void SetFocus(ComboBox comboBox1)
    {
        Keyboard.Focus(comboBox1);
    }



    public void AddValuesOfEnumAsItems<T>() where T : struct
    {
        IList arr = EnumHelper.GetValues<T>(true, true);
        AddValuesOfEnumAsItems(arr);
    }

    public void AddValuesOfEnumAsItems(IList values)
    {
        int index = 0;
        foreach (object item in values)
        {
            cb.Items.Add(item);
            if (index == 0)
            {
                cb.SelectedIndex = 0;

            }
            index++;
        }

    }


    public void AddValuesOfEnumerableAsItems(IList items)
    {
        AddValuesOfArrayAsItems(null, null, items);
    }

    public void AddValuesOfArrayAsItems(params object[] items)
    {
        AddValuesOfArrayAsItems(null, items);
    }

    /// <summary>
    /// A1 is out of using - set null
    /// </summary>
    /// <param name="eventHandler"></param>
    /// <param name="items"></param>
    public void AddValuesOfArrayAsItems(RoutedEventHandler eventHandler, params object[] items)
    {
        AddValuesOfArrayAsItems(null, eventHandler, items);
    }


    /// <summary>
    /// A1 can be null
    /// A2 was handler of MouseDown, now without using - set null.
    /// </summary>
    /// <param name="eh"></param>
    /// <param name="items"></param>
    public void AddValuesOfArrayAsItems(Func<object, string> toMakeNameInTWithName, /*RoutedEventHandler eh,*/ params object[] items)
    {
        var enu = CAG.ToList<object>(items);
        // cant add here because A1 will try cast added string to Encoding and throw exception
        //if (enu[0].ToString().Trim() != string.Empty)
        //{
        //    enu.Insert(0, string.Empty);
        //}
        int index = 0;
        foreach (object item in enu)
        {
            if (toMakeNameInTWithName != null)
            {
                TWithNameTWpf<object> item2 = new TWithNameTWpf<object>();
                item2.name = toMakeNameInTWithName.Invoke(item);
                item2.t = item;
                cb.Items.Add(item2);
            }
            else
            {
                cb.Items.Add(item);
            }

            index++;
        }
    }



    /// <summary>
    /// A1 was handler of MouseDown, now without using. Use second method without A1.
    /// </summary>
    /// <param name="eh"></param>
    /// <param name="initialValue"></param>
    /// <param name="resizeOf"></param>
    /// <param name="degrees"></param>
    public void AddValuesOfIntAsItems(int initialValue, int resizeOf, int degrees)
    {
        int akt = initialValue;
        List<int> pred = new List<int>();
        for (int index = 0; index < degrees; index++)
        {
            akt -= resizeOf;
            pred.Add(akt);

        }
        pred.Reverse();
        akt = initialValue;
        List<int> following = new List<int>();
        for (int index2 = 0; index2 < degrees; index2++)
        {
            akt += resizeOf;
            pred.Add(akt);
        }
        List<int> values = new List<int>();
        values.AddRange(pred);
        values.Add(initialValue);
        values.AddRange(following);
        int index3 = 0;
        foreach (int item in values)
        {
            cb.Items.Add(item);
            index3++;
        }
    }
}