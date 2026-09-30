#define ASYNC
namespace SunamoWpf.Controls.Helpers.Controls;

/// <summary>
/// Třída s generickým typem je SuMenuItemWithSubitemsHelperT
/// Používá se pro automatické zaškrtávání posledního a zjištění která hodnota byla zaškrtnuta
/// </summary>
public class SuMenuItemWithSubitemsHelper
{
    static Type type = typeof(SuMenuItemWithSubitemsHelper);
    protected SuMenuItem tsddb = null;
    protected SuMenuItem prev = new SuMenuItem();
    protected string originalToolTipText = "";
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
    public void AddValuesOfEnumAsItems<T>(object defVal)
    {
        Dictionary<T, string> d = new Dictionary<T, string>();
        Type type = typeof(T);
        var en = Enum.GetValues(type);
        foreach (T item in en)
        {
            d.Add(item, item.ToString());
            //AddSuMenuItem(item);
        }
        AddValuesOfEnumAsItems<T>(d, defVal);
    }
    public void AddValuesOfEnumAsItems<T>(Dictionary<SuMenuItem, T> d, object defVal, SuMenuItem defMi)
    {
        Type type = typeof(T);
        if (defVal != null)
        {
            if (type.FullName != defVal.GetType().FullName)
            {
                ThrowEx.Custom(Translate.FromKey(XlfKeys.ParameterDefValInSuMenuItemWithSubitemsHelperAddValuesOfEnumAsItemsWasNotTypeOfEnum) + ".");
            }
        }
        T _def = (T)defVal;
        foreach (var item in d)
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
    public void AddValuesOfEnumAsItems<T>(Dictionary<T, string> d, object defVal)
    {
        Type type = typeof(T);
        if (defVal != null)
        {
            if (type.FullName != defVal.GetType().FullName)
            {
                ThrowEx.Custom(Translate.FromKey(XlfKeys.ParameterDefValInSuMenuItemWithSubitemsHelperAddValuesOfEnumAsItemsWasNotTypeOfEnum) + ".");
            }
        }
        T _def = (T)defVal;
        foreach (var item in d)
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
    public bool zaskrtavat = false;
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
    public string SelectedS
    {
        get
        {
            return SelectedO.ToString();
        }
    }
    public void AddValuesOfEnumAsItems(Array bs, bool zaskPrvni)
    {
        tsddb.Items.Clear();
        int i = 0;
        foreach (object item in bs)
        {
            SuMenuItem tsmi = AddSuMenuItem(item, item.ToString());
            if (zaskPrvni)
            {
                if (i == 0)
                {
                    tsmi.IsChecked = true;
                    prev = tsmi;
                }
            }
            i++;
        }
    }
    public void tsmi_Click(object sender, RoutedEventArgs e)
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
            SuMenuItemChecked(sender, e);
        }
    }
    public void AddValuesOfArrayAsItems(RoutedEventHandler eh, object[] o)
    {
        tsddb.Items.Clear();
        int i = 0;
        foreach (object item in o)
        {
            SuMenuItem tsmi = AddSuMenuItem(item, item.ToString());
            tsmi.Click += eh;
            i++;
        }
    }
    public void AddValuesOfArrayAsItems(ICommand eh, object[] o)
    {
        tsddb.Items.Clear();
        int i = 0;
        foreach (object item in o)
        {
            SuMenuItem tsmi = AddSuMenuItem(item, item.ToString());
            tsmi.Command = eh;
            tsmi.CommandParameter = item;
            i++;
        }
    }
    public void AddValuesOfArrayAsItems(RoutedCommand cmd0, object[] p, RoutedCommand cmd1, List<StringBuilder> stovky, RoutedCommand cmd2, /*List<StringBuilder> desitky,*/ RoutedCommand cmd3 /*, List<StringBuilder> jednotky*/)
    {
        mnoho = true;
        int pristePokracovatDesitky = 0;
        tsddb.Items.Clear();
        int i = 0;
        foreach (object item in p)
        {
            pristePokracovatDesitky = 0;
            string category = item.ToString();
            string categoryPipe = category + "|";
            SuMenuItem tsmi = new SuMenuItem();
            tsmi.Header = category;
            List<string> stovkyDivided = SHSplit.SplitChar(stovky[i].ToString(), '|');
            List<String> stovkyActual = new List<String>();
            StringBuilder stovkyActualTemp = new StringBuilder();
            for (int y = 0; y < stovkyDivided.Count; y++)
            {
                if ((y) % 100 == 0 && y != 0)
                {
                    stovkyActual.Add(stovkyActualTemp.ToString());
                    stovkyActualTemp.Clear();
                    stovkyActualTemp.Append(stovkyDivided[y] + ",");
                }
                else
                {
                    stovkyActualTemp.Append(stovkyDivided[y] + ",");
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
                    var o = (pristePokracovatJednotky - 1);
                    if (o % 10 == 0 && o % 100 != 0 && o != 0)
                    {
                        indexNaKteryUkladatDesitky++;
                        kVlozeniDoDesitky.Add(new List<SuMenuItem>());
                        idckaDesitky.Add(new StringBuilder());
                    }
                    kVlozeniDoDesitky[indexNaKteryUkladatDesitky].Add(tsmiJednotky);
                    idckaDesitky[indexNaKteryUkladatDesitky].Append(jednotka + ",");
                }
                for (int t = 0; t < kVlozeniDoDesitky.Count; t++)
                {
                    if (kVlozeniDoDesitky[kVlozeniDoDesitky.Count - 1].Count == 0)
                    {
                        int rat = kVlozeniDoDesitky.Count - 1;
                        kVlozeniDoDesitky.RemoveAt(rat);
                        idckaDesitky.RemoveAt(rat);
                    }
                }
                int e = 0;
                foreach (var item3 in kVlozeniDoDesitky)
                {
                    var u = idckaDesitky[e].ToString();
                    e++;
                    var desitkyPouze = SHSplit.Split(u, ",");
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
                    tsmiDesitky2.CommandParameter = tsmiDesitky2.Header.ToString() + "|" + categoryPipe + u;
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
            i++;
        }
    }
    public void AddValuesOfIntAsItems(RoutedEventHandler eh, int initialValue, int resizeOf, int degrees)
    {
        tsddb.Items.Clear();
        int akt = initialValue;
        List<int> pred = new List<int>();
        for (int i = 0; i < degrees; i++)
        {
            akt -= resizeOf;
            pred.Add(akt);
        }
        pred.Reverse();
        akt = initialValue;
        List<int> po = new List<int>();
        for (int i = 0; i < degrees; i++)
        {
            akt += resizeOf;
            po.Add(akt);
        }
        List<int> o = new List<int>();
        o.AddRange(pred);
        o.Add(initialValue);
        o.AddRange(po);
        int y = 0;
        foreach (int item in o)
        {
            SuMenuItem tsmi = new SuMenuItem();
            tsmi.Header = item.ToString();
            tsmi.Tag = item;
            tsmi.Click += tsmi_Click;
            tsmi.Click += eh;
            tsddb.Items.Add(tsmi);
            y++;
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
    public SuMenuItemWithSubitemsHelper(SuMenuItem tsddb)
    {
        this.tsddb = tsddb;
        tagy = true;
    }
}