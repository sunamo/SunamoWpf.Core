#define ASYNC
namespace SunamoWpf.Controls.Controls;

public class SearchingInLbWPF
{
    /// <summary>
    /// ListBox ve kterEm se ukazujI vYsledky
    /// </summary>
    ListBox lb = null;
    /// <summary>
    /// TextBox do kterEho byl zadanY hledanY vYraz
    /// </summary>
    TextBox tstb = null;
    /// <summary>
    /// VYchozY poloZky. Nahraje se do LB po stornovAnI hledání.
    /// </summary>
    public object[] oc = null;
    string searchOnlyFromLastOccurenceOf = null;
    /// <param name="listBox"></param>
    /// <param name="tstb"></param>
    public SearchingInLbWPF(ListBox listBox, TextBox tstb, Button toolStripButton2, SuMenuItem tsmi, string searchOnlyFromLastOccurenceOf)
    {
        this.lb = listBox;
        this.tstb = tstb;
        this.searchOnlyFromLastOccurenceOf = searchOnlyFromLastOccurenceOf;
        tstb.TextChanged += tstb_TextChanged;
        tstb.KeyDown += tstb_KeyDown;
        toolStripButton2.Click += toolStripButton2_Click;
        tsmi.Click += tsmi_Click;
        List<object> result = new List<object>();
        foreach (object var in listBox.Items)
        {
            result.Add(var);
        }
        oc = result.ToArray();
    }
    void tsmi_Click(object sender, System.Windows.RoutedEventArgs eventArgs)
    {
        tstb.Text = "";
    }
    void toolStripButton2_Click(object sender, System.Windows.RoutedEventArgs eventArgs)
    {
        tstb.Text = "";
    }
    void tstb_KeyDown(object sender, System.Windows.Input.KeyEventArgs eventArgs)
    {
        if (eventArgs.Key == Key.Back)
        {
            tstb.Text = "";
        }
    }
    void tstb_TextChanged(object sender, TextChangedEventArgs eventArgs)
    {
        if (tstb.Text == "")
        {
            Searching(false);
        }
        else
        {
            Searching(true);
        }
    }
    /// <param name="zapnuto"></param>
    public void Searching(bool zapnuto)
    {
        if (zapnuto)
        {
            var tstbText = tstb.Text;
            List<object> nechat = new List<object>();
            if (searchOnlyFromLastOccurenceOf == "")
            {
                foreach (object var in oc)
                {
                    if (var.ToString().ToLower().Contains(tstbText.ToLower()))
                    {
                        nechat.Add(var);
                    }
                }
            }
            else
            {
                foreach (object var in oc)
                {
                    string trInListBox = var.ToString();
                    trInListBox = SH.GetLastPartByString(trInListBox, searchOnlyFromLastOccurenceOf);
                    if (trInListBox.ToLower().Contains(tstbText.ToLower()))
                    {
                        nechat.Add(var);
                    }
                }
            }
            lb.Items.Clear();
            WpfLogger.Info( Translate.FromKey(XlfKeys.WasFounded) + " " + nechat.Count + " items. ");
            AddRangeToListBox(nechat.ToArray());
        }
        else
        {
            lb.Items.Clear();
            WpfLogger.Info( Translate.FromKey(XlfKeys.SearchingWasStopped) + ".");
            AddRangeToListBox(oc);
        }
    }
    private void AddRangeToListBox(object[] items)
    {
        foreach (var item in items)
        {
            lb.Items.Add(item);
        }
    }
    public void ClickStop()
    {
        tstb.Text = "";
    }
}