#define ASYNC
namespace SunamoWpf.Controls.Helpers.Controls;

/// <summary>
/// Třída s generickým typem je SuMenuItemWithSubitemsHelperT
/// Používá se pro automatické zaškrtávání posledního a zjištění která hodnota byla zaškrtnuta
/// </summary>
public class SuMenuItemWithSubitemsHelper
{
    static Type type = typeof(SuMenuItemWithSubitemsHelper);
    /// <summary>
    /// The tsddb.
    /// </summary>
    protected SuMenuItem tsddb = null;
    /// <summary>
    /// The prev.
    /// </summary>
    protected SuMenuItem prev = new SuMenuItem();
    /// <summary>
    /// The original tool tip text.
    /// </summary>
    protected string originalToolTipText = "";
    /// <summary>
    /// The su menu item checked.
    /// </summary>
    public event EventHandler SuMenuItemChecked;
    object selectedO = null;
    bool mnoho = false;
    /// <summary>
    /// Objekt, ve kterém je vždy aktuální zda v tsddb něco je
    /// Takže se nelekni že to je promměná
    /// </summary>
    public object SelectedO
    {
        get
        {
            return selectedO;
        }
        set
        {
            selectedO = value;
            if (!mnoho)
            {
                foreach (SuMenuItem item in tsddb.Items)
                {
                    if (tagy)
                    {
                        if (item.Tag.ToString() == value.ToString())
                        {
                            item.IsChecked = true;
                        }
                    }
                    else
                    {
                        if (item == value)
                        {
                            item.IsChecked = true;
                        }
                    }
                }
            }
        }
    }
    /// <summary>
    /// Add values of enum as items t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="defVal">The def val.</param>
    public void AddValuesOfEnumAsItems<T>(object defVal)
    {
        Dictionary<T, string> result = new Dictionary<T, string>();
        Type type = typeof(T);
        var values = Enum.GetValues(type);
        foreach (T item in values)
        {
            result.Add(item, item.ToString());
            //AddSuMenuItem(item);
        }
        AddValuesOfEnumAsItems<T>(result, defVal);
    }
    /// <summary>
    /// Add values of enum as items t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="items">The items.</param>
    /// <param name="defVal">The def val.</param>
    /// <param name="defMi">The def mi.</param>
    public void AddValuesOfEnumAsItems<T>(Dictionary<SuMenuItem, T> items, object defVal, SuMenuItem defMi)
    {
        Type type = typeof(T);
        if (defVal != null)
        {
            if (type.FullName != defVal.GetType().FullName)
            {
                ThrowEx.Custom("Parameter def val in su menu item with subitems helper add values of enum as items was not type of enum" + ".");
            }
        }
        T _def = (T)defVal;
        foreach (var item in items)
        {
            item.Key.Tag = item.Value;
            AddSuMenuItem(item.Key);
        }
        if (defVal != null)
        {
            SelectedO = defVal;
        }
        prev = defMi;
    }
    /// <summary>
    /// Add values of enum as items t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="items">The items.</param>
    /// <param name="defVal">The def val.</param>
    public void AddValuesOfEnumAsItems<T>(Dictionary<T, string> items, object defVal)
    {
        Type type = typeof(T);
        if (defVal != null)
        {
            if (type.FullName != defVal.GetType().FullName)
            {
                ThrowEx.Custom("Parameter def val in su menu item with subitems helper add values of enum as items was not type of enum" + ".");
            }
        }
        T _def = (T)defVal;
        foreach (var item in items)
        {
            AddSuMenuItem(item.Key, item.Value);
        }
        if (defVal != null)
        {
            SelectedO = defVal;
        }
    }
    private SuMenuItem AddSuMenuItem(object tag, string header)
    {
        SuMenuItem tsmi = new SuMenuItem();
        tsmi.Header = header;
        tsmi.Tag = tag;
        AddSuMenuItem(tsmi);
        return tsmi;
    }
    private void AddSuMenuItem(SuMenuItem tsmi)
    {
        tsmi.Click += new RoutedEventHandler(tsmi_Click);
        tsddb.Items.Add(tsmi);
    }
    /// <summary>
    /// Používá se pokud chci porovnávat rychleji na reference SuMenuItem ale chci zjistit Tag zvolené položky.
    /// </summary>
    public object SelectedTag()
    {
        if (Selected)
        {
            return ((SuMenuItem)SelectedO).Tag;
        }
        return null;
    }
    /// <summary>
    /// The zaskrtavat.
    /// </summary>
    public bool zaskrtavat = false;
    /// <summary>
    /// The selected.
    /// </summary>
    public bool Selected
    {
        get
        {
            if (SelectedO != null)
            {
                return SelectedO.ToString().Trim() != "";
            }
            return false;
            //return SelectedO != null;
        }
    }
    /// <summary>
    /// The selected s.
    /// </summary>
    public string SelectedS
    {
        get
        {
            return SelectedO.ToString();
        }
    }
    /// <summary>
    /// Add values of enum as items.
    /// </summary>
    /// <param name="values">The values.</param>
    /// <param name="zaskPrvni">The zask prvni.</param>
    public void AddValuesOfEnumAsItems(Array values, bool zaskPrvni)
    {
        tsddb.Items.Clear();
        int index = 0;
        foreach (object item in values)
        {
            SuMenuItem tsmi = AddSuMenuItem(item, item.ToString());
            if (zaskPrvni)
            {
                if (index == 0)
                {
                    tsmi.IsChecked = true;
                    prev = tsmi;
                }
            }
            index++;
        }
    }
    /// <summary>
    /// Tsmi click.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="eventArgs">The event args.</param>
    public void tsmi_Click(object sender, RoutedEventArgs eventArgs)
    {
        prev.IsChecked = false;
        SuMenuItem tsmi = (SuMenuItem)sender;
        if (zaskrtavat)
        {
            tsmi.IsChecked = true;
            prev = tsmi;
        }
        if (tagy)
        {
            selectedO = tsmi.Tag;
        }
        else
        {
            selectedO = tsmi;
        }
        tsddb.ToolTip = originalToolTipText + " " + SelectedO.ToString();
        if (SuMenuItemChecked != null)
        {
            SuMenuItemChecked(sender, eventArgs);
        }
    }
    /// <summary>
    /// Add values of array as items.
    /// </summary>
    /// <param name="eventHandler">The event handler.</param>
    /// <param name="items">The items.</param>
    public void AddValuesOfArrayAsItems(RoutedEventHandler eventHandler, object[] items)
    {
        tsddb.Items.Clear();
        int index = 0;
        foreach (object item in items)
        {
            SuMenuItem tsmi = AddSuMenuItem(item, item.ToString());
            tsmi.Click += eventHandler;
            index++;
        }
    }
    /// <summary>
    /// Add values of array as items.
    /// </summary>
    /// <param name="command">The command.</param>
    /// <param name="items">The items.</param>
    public void AddValuesOfArrayAsItems(ICommand command, object[] items)
    {
        tsddb.Items.Clear();
        int index = 0;
        foreach (object item in items)
        {
            SuMenuItem tsmi = AddSuMenuItem(item, item.ToString());
            tsmi.Command = command;
            tsmi.CommandParameter = item;
            index++;
        }
    }
    /// <summary>
    /// Add values of array as items.
    /// </summary>
    /// <param name="cmd0">The cmd 0.</param>
    /// <param name="items">The items.</param>
    /// <param name="cmd1">The cmd 1.</param>
    /// <param name="stovky">The stovky.</param>
    /// <param name="cmd2">The cmd 2.</param>
    /// <param name="desitky">The desitky.</param>
    /// <param name="/*">The /*.</param>
    /// <param name="jednotky*/">The jednotky.</param>
    public void AddValuesOfArrayAsItems(RoutedCommand cmd0, object[] items, RoutedCommand cmd1, List<StringBuilder> stovky, RoutedCommand cmd2, /*List<StringBuilder> desitky,*/ RoutedCommand cmd3 /*, List<StringBuilder> jednotky*/)
    {
        mnoho = true;
        int pristePokracovatDesitky = 0;
        tsddb.Items.Clear();
        int index = 0;
        foreach (object item in items)
        {
            pristePokracovatDesitky = 0;
            string category = item.ToString();
            string categoryPipe = category + "|";
            SuMenuItem tsmi = new SuMenuItem();
            tsmi.Header = category;
            List<string> stovkyDivided = SHSplit.SplitChar(stovky[index].ToString(), '|');
            List<String> stovkyActual = new List<String>();
            StringBuilder stovkyActualTemp = new StringBuilder();
            for (int valueIndex = 0; valueIndex < stovkyDivided.Count; valueIndex++)
            {
                if ((valueIndex) % 100 == 0 && valueIndex != 0)
                {
                    stovkyActual.Add(stovkyActualTemp.ToString());
                    stovkyActualTemp.Clear();
                    stovkyActualTemp.Append(stovkyDivided[valueIndex] + ",");
                }
                else
                {
                    stovkyActualTemp.Append(stovkyDivided[valueIndex] + ",");
                }
                //
            }
            int pristePokracovatJednotky = 0;
            int pristePokracovatStovky = 0;
            stovkyActual.Add(stovkyActualTemp.ToString());
            //int aktualniIndexStovky = 0;
            foreach (var idcka in stovkyActual)
            {
                SuMenuItem tsmiStovky = new SuMenuItem();
                tsmiStovky.Header = (pristePokracovatStovky + 1).ToString() + " - " + (pristePokracovatStovky + SHSplit.Split(idcka, ",").Count).ToString();
                List<List<SuMenuItem>> kVlozeniDoDesitky = new List<List<SuMenuItem>>();
                List<StringBuilder> idckaDesitky = new List<StringBuilder>();
                kVlozeniDoDesitky.Add(new List<SuMenuItem>());
                idckaDesitky.Add(new StringBuilder());
                var jednotkyDivided = SHSplit.Split(idcka, ",");
                int indexNaKteryUkladatDesitky = 0;
                foreach (var jednotka in jednotkyDivided)
                {
                    SuMenuItem tsmiJednotky = new SuMenuItem();
                    tsmiJednotky.Header = (pristePokracovatJednotky + 1).ToString();
                    pristePokracovatJednotky++;
                    tsmiJednotky.Command = cmd3;
                    tsmiJednotky.CommandParameter = tsmiJednotky.Header.ToString() + "|" + categoryPipe + jednotka;
                    var unitNumber = (pristePokracovatJednotky - 1);
                    if (unitNumber % 10 == 0 && unitNumber % 100 != 0 && unitNumber != 0)
                    {
                        indexNaKteryUkladatDesitky++;
                        kVlozeniDoDesitky.Add(new List<SuMenuItem>());
                        idckaDesitky.Add(new StringBuilder());
                    }
                    kVlozeniDoDesitky[indexNaKteryUkladatDesitky].Add(tsmiJednotky);
                    idckaDesitky[indexNaKteryUkladatDesitky].Append(jednotka + ",");
                }
                for (int tensLoopIndex = 0; tensLoopIndex < kVlozeniDoDesitky.Count; tensLoopIndex++)
                {
                    if (kVlozeniDoDesitky[kVlozeniDoDesitky.Count - 1].Count == 0)
                    {
                        int rat = kVlozeniDoDesitky.Count - 1;
                        kVlozeniDoDesitky.RemoveAt(rat);
                        idckaDesitky.RemoveAt(rat);
                    }
                }
                int tensIndex = 0;
                foreach (var item3 in kVlozeniDoDesitky)
                {
                    var text = idckaDesitky[tensIndex].ToString();
                    tensIndex++;
                    var desitkyPouze = SHSplit.Split(text, ",");
                    SuMenuItem tsmiDesitky = new SuMenuItem();
                    tsmiDesitky.Header = (pristePokracovatDesitky + 1).ToString() + " - " + (pristePokracovatDesitky + desitkyPouze.Count).ToString();
                    foreach (var item4 in item3)
                    {
                        tsmiDesitky.Items.Add(item4);
                    }
                    SuMenuItem tsmiDesitky2 = new SuMenuItem();
                    tsmiDesitky2.Header = (pristePokracovatDesitky + 1).ToString() + " - " + (pristePokracovatDesitky + desitkyPouze.Count).ToString();
                    tsmiDesitky2.Command = cmd2;
                    //
                    tsmiDesitky2.CommandParameter = tsmiDesitky2.Header.ToString() + "|" + categoryPipe + text;
                    tsmiStovky.Items.Add(tsmiDesitky2);
                    tsmiStovky.Items.Add(tsmiDesitky);
                    pristePokracovatDesitky += 10;
                }
                SuMenuItem tsmiStovky2 = new SuMenuItem();
                tsmiStovky2.Header = (pristePokracovatStovky + 1).ToString() + " - " + (pristePokracovatStovky + SHSplit.Split(idcka, ",").Count).ToString();
                pristePokracovatStovky += 100;
                tsmiStovky2.Command = cmd1;
                //
                tsmiStovky2.CommandParameter = tsmiStovky2.Header.ToString() + "|" + categoryPipe + idcka;
                tsmi.Items.Add(tsmiStovky2);
                tsmi.Items.Add(tsmiStovky);
            }
            SuMenuItem tsmi2 = new SuMenuItem();
            tsmi2.Header = category;
            tsmi2.Command = cmd0;
            tsmi2.CommandParameter = category;
            tsddb.Items.Add(tsmi2);
            tsmi.IsEnabled = true;
            tsddb.Items.Add(tsmi);
            index++;
        }
    }
    /// <summary>
    /// Add values of int as items.
    /// </summary>
    /// <param name="eventHandler">The event handler.</param>
    /// <param name="initialValue">The initial value.</param>
    /// <param name="resizeOf">The resize of.</param>
    /// <param name="degrees">The degrees.</param>
    public void AddValuesOfIntAsItems(RoutedEventHandler eventHandler, int initialValue, int resizeOf, int degrees)
    {
        tsddb.Items.Clear();
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
            following.Add(akt);
        }
        List<int> values = new List<int>();
        values.AddRange(pred);
        values.Add(initialValue);
        values.AddRange(following);
        int valueIndex = 0;
        foreach (int item in values)
        {
            SuMenuItem tsmi = new SuMenuItem();
            tsmi.Header = item.ToString();
            tsmi.Tag = item;
            tsmi.Click += tsmi_Click;
            tsmi.Click += eventHandler;
            tsddb.Items.Add(tsmi);
            valueIndex++;
        }
    }
    bool tagy = true;
    /// <summary>
    /// A2 zda se má do SelectedO uložit tsmi.Tag nebo jen tsmi
    /// </summary>
    /// <param name="tsddb"></param>
    /// <param name="tagy"></param>
    public SuMenuItemWithSubitemsHelper(SuMenuItem tsddb, bool tagy)
    {
        this.tsddb = tsddb;
        this.tagy = tagy;
    }
    /// <summary>
    /// Initializes a new instance of the su menu item with subitems helper class.
    /// </summary>
    /// <param name="tsddb">The tsddb.</param>
    public SuMenuItemWithSubitemsHelper(SuMenuItem tsddb)
    {
        this.tsddb = tsddb;
        tagy = true;
    }
}