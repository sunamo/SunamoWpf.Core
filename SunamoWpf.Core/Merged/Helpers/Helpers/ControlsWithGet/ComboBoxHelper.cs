#define ASYNC
namespace SunamoWpf.Helpers.ControlsWithGet;

/// <summary>
/// Must use SelectionChanged of ComboBoxHelper, not ComboBox. Otherwise first in called in Control, then is set into Selected* properties and app goes wrong!!
/// </summary>
public partial class ComboBoxHelper
{
    /// <summary>
    /// Add range 2 list.
    /// </summary>
    /// <param name="cbInterpret">The cb interpret.</param>
    /// <param name="allInterprets">The all interprets.</param>
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

    /// <summary>
    /// Value from t with name or object.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>The value from t with name or object result.</returns>
    public static object ValueFromTWithNameOrObject(object value)
    {
        if (value is TWithNameTWpf<object>)
        {
            return ((TWithNameTWpf<object>)value).t;
        }
        return value;
    }

    /// <summary>
    /// Set focus.
    /// </summary>
    /// <param name="comboBox1">The combo box 1.</param>
    public static void SetFocus(ComboBox comboBox1)
    {
        Keyboard.Focus(comboBox1);
    }



    /// <summary>
    /// Add values of enum as items t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    public void AddValuesOfEnumAsItems<T>() where T : struct
    {
        IList arr = EnumHelper.GetValues<T>(true, true);
        AddValuesOfEnumAsItems(arr);
    }

    /// <summary>
    /// Add values of enum as items.
    /// </summary>
    /// <param name="values">The values.</param>
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


    /// <summary>
    /// Add values of enumerable as items.
    /// </summary>
    /// <param name="items">The items.</param>
    public void AddValuesOfEnumerableAsItems(IList items)
    {
        AddValuesOfArrayAsItems(null, null, items);
    }

    /// <summary>
    /// Add values of array as items.
    /// </summary>
    /// <param name="items">The items.</param>
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
                TWithNameTWpf<object> namedItem = new TWithNameTWpf<object>();
                namedItem.name = toMakeNameInTWithName.Invoke(item);
                namedItem.t = item;
                cb.Items.Add(namedItem);
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
        for (int degreeIndex = 0; degreeIndex < degrees; degreeIndex++)
        {
            akt += resizeOf;
            pred.Add(akt);
        }
        List<int> values = new List<int>();
        values.AddRange(pred);
        values.Add(initialValue);
        values.AddRange(following);
        int valueIndex = 0;
        foreach (int item in values)
        {
            cb.Items.Add(item);
            valueIndex++;
        }
    }
}