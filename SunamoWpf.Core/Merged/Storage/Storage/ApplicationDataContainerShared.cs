#define ASYNC
namespace SunamoWpf.Storage;

/// <summary>
/// Key is filename
/// Value is ApplicationDataContainerList (every instance has unique file)
/// ApplicationDataContainerSearchTextBox
/// </summary>
public partial class ApplicationDataContainer : ApplicationDataConsts
{
    public IApplicationDataContainerSearchTextBox apcSearchTextBox = null;

    static Type type = typeof(ApplicationDataContainer);
    /// <summary>
    /// In key are control
    /// In value its saved values
    /// Must be bcoz every line has strictly structure - name|type|data. Never be | in data. Access through methods Get / Set
    /// Never direct access also in this class!! 
    /// </summary>
    public Dictionary<object, ApplicationDataContainerList> data = new Dictionary<object, ApplicationDataContainerList>();

    string file = "";
    public string innerDelimiter = "*";
    /// <summary>
    /// ctor for old approach
    /// </summary>
    /// <param name="file"></param>
    public ApplicationDataContainer(string file)
    {
        this.file = file;
        data.Add(file, ApplicationDataContainerList.Init(null, file).Result);
    }

    /// <summary>
    /// Must be here due to sunamo.Tests
    /// </summary>
    public ApplicationDataContainerList Values
    {
        get
        {
            if (data.ContainsKey(file))
            {
                var list = data[file];
                return list;
            }
            return null;
        }
    }
    public ApplicationDataContainer()
    {
    }


    public void SaveControl(object o)
    {
        FrameworkElement fw = (FrameworkElement)o;
        if (fw != null)
        {
            data[fw].SaveFile().GetAwaiter().GetResult();
        }
        else
        {
            ThrowEx.DoesntHaveRequiredType("o");
        }
    }

    /// <summary>
    /// Must be AddUserControl, not Add coz many control is derived from UC like SelectFolder
    /// </summary>
    /// <param name="uc"></param>
    public void AddUserControl(UserControl uc)
    {
        var adcl = AddFrameworkElement(uc);
    }



    #region Add - list. Data do listů ukládám zásadně přes SF
    public void Add(ICheckBoxListUC chbl)
    {
        apcSearchTextBox.Add(chbl);
    }

    //public void Add(TwoWayTable twt)
    //{
    //    //twt.c = list;
    //    //twt.Save += Twt_Save;
    //}

    public void Add(ComboBox cb)
    {
        // Automatically load
        var adcl = AddFrameworkElement(cb);
        var list = adcl.GetListString(ItemsSource);
        cb.ItemsSource = list;
        cb.KeyUp += Cb_KeyUp;
        //cb.DataContextChanged += Cb_DataContextChanged;
    }





    #endregion

    private void Chb_Click(object sender, RoutedEventArgs e)
    {
        CheckBox chb = sender as CheckBox;
        Set(sender, IsChecked, chb.IsChecked);
        SaveControl(chb);
    }



    #region Add - single


    public void Add(Window cb)
    {
        // Automatically load
        var adcl = AddFrameworkElement(cb, ResolveControlFile(cb));
        var list = adcl.GetListString(ItemsSource);


        //cb.ItemsSource = list;
        //cb.KeyUp += Cb_KeyUp;
        //cb.DataContextChanged += Cb_DataContextChanged;
    }

    public void Add(TextBlock tb)
    {
        var tb2 = AddFrameworkElement(tb);
        //tb.TextChanged +=
    }

    public void Add(CheckBox chb)
    {
        ApplicationDataContainerList adcl = AddFrameworkElement(chb);
        chb.Click += Chb_Click;
        chb.IsChecked = adcl.GetNullableBool(IsChecked);
    }
    public void Add(TextBox txt)
    {
        var adcl = AddFrameworkElement(txt);
        txt.Text = adcl.GetString(Text);
        txt.TextChanged += Txt_TextChanged;
    }
    #endregion


    private void Txt_TextChanged(object sender, TextChangedEventArgs e)
    {
        TextBox chb = sender as TextBox;
        Set(sender, Text, chb.Text);
        SaveControl(chb);
    }

    public T Get<T>(object sender, string key)
    {

        var v = data[sender];
        if (v.Contains(key))
        {
            return (T)v[key];
        }

        return default(T);
    }
    public object Get(object sender, string key)
    {
        return data[sender][key];
    }
    public void Set(object sender, string key, object v)
    {
        // Here must be "|" because in file it is in format name|type|value
        ThrowEx.StringContainsUnallowedSubstrings(v.ToString(), "|");
        var f = data[sender];
        f[key] = v;
    }



    private void Cb_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
    {
        var cb = sender as ComboBox;
        if (e.Key == System.Windows.Input.Key.Enter)
        {
            //var items = cb.Items;
            //var itemsS = cb.ItemsSource;
            List<string> list = AddToListString(cb.ItemsSource, cb.Text);
            cb.ItemsSource = list;
            Set(sender, ItemsSource, list);
            SaveControl(cb);
        }
    }
    private List<string> AddToListString(object list, string text)
    {
        var list2 = ((List<string>)list);
        list2.Add(text);
        return list2;
    }
#pragma warning disable
    private void Cb_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
#pragma warning restore
    {
        //SaveControl(sender);
    }
    public ApplicationDataContainerList AddFrameworkElement(object key, ApplicationDataContainerList fw)
    {
        data.Add(key, fw);
        return fw;
    }
    public ApplicationDataContainerList AddFrameworkElement(FrameworkElement fw)
    {
        return AddFrameworkElement(fw, ResolveControlFile(fw));
    }

    /// <summary>
    /// Složka, do které se ukládají soubory s nastavením ovládacích prvků a oken. Výchozí je %APPDATA%\_Sunamo\proces\Controls, aplikace ji může přepsat.
    /// </summary>
    public static string ControlsFolder { get; set; } = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "_Sunamo",
        Path.GetFileNameWithoutExtension(Environment.ProcessPath ?? "App"), "Controls");

    /// <summary>
    /// Vrátí cestu k souboru s nastavením prvku (název prvku, u okna bez Name název typu).
    /// </summary>
    /// <param name="fw">Prvek, jehož nastavení se ukládá.</param>
    private static string ResolveControlFile(FrameworkElement fw)
    {
        var name = string.IsNullOrWhiteSpace(fw.Name) ? fw.GetType().Name : fw.Name;
        return Path.Combine(ControlsFolder, name + ".txt");
    }

    /// <summary>
    /// Načte nastavení prvku z daného souboru a zaregistruje ho pod prvkem.
    /// </summary>
    /// <param name="fw">Prvek, jehož nastavení se ukládá.</param>
    /// <param name="path">Cesta k souboru s nastavením.</param>
    private ApplicationDataContainerList AddFrameworkElement(FrameworkElement fw, string path)
    {
        ApplicationDataContainerList result = ApplicationDataContainerList.Init(fw, path).Result;
        return AddFrameworkElement(fw, result);
    }

}