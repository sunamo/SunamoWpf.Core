#define ASYNC
namespace SunamoWpf.Helpers.Controls;

public delegate void VoidMouseButtonGeneric1<in T>(MouseButton mouseButton, T value);
public class LBHT<T> : LBH
{
    /// <summary>
    /// Vychozy pro A2 bylo SelectionMode.Extended
    /// </summary>
    /// <param name="listBox"></param>
    /// <param name="selectionMode"></param>
    public LBHT(ListBox listBox, SelectionMode selectionMode = SelectionMode.Single)
        : base(listBox, selectionMode)
    {
        listBox.SelectionChanged += Lb_SelectionChanged;
        ItemRemoved += LBHT_ItemRemoved;
        listBox.PreviewMouseDoubleClick += Lb_MouseDoubleClick;
    }
    private void LBHT_ItemRemoved(object item)
    {
        ItemRemovedT((T)item);
    }
    public event VoidT<T> ItemRemovedT;
    private void Lb_SelectionChanged(object sender, SelectionChangedEventArgs eventArgs)
    {
        SaveSelectedItem();
    }
    private void SaveSelectedItem()
    {
        if (lb.SelectedItem is T)
        {
            T item = (T)lb.SelectedItem;
            SaveSelectedItem(item);
        }
        else if (lb.SelectedItem is FrameworkElement)
        {
            // Vlastnost Tag je ve tzd FrameworkElement
            FrameworkElement frameworkElement = lb.SelectedItem as FrameworkElement;
            if (frameworkElement.Tag is T)
            {
                T item2 = (T)frameworkElement.Tag;
                SaveSelectedItem(item2);
            }
        }
    }
    private void SaveSelectedItem(T item)
    {
        Selected = item;
        if (MouseDown != null)
        {
            MouseDown(mb, item);
        }
    }
    private void Lb_MouseDoubleClick(object sender, MouseButtonEventArgs eventArgs)
    {
        mb = eventArgs.ChangedButton;
        SaveSelectedItem();
        if (IsSelected)
        {
            if (eventArgs.ChangedButton == MouseButton.Left)
            {
                if (runOne)
                {
                    RunSelected();
                }
            }
        }
    }
    public event VoidMouseButtonGeneric1<T> MouseDown;
    public T SelectedT
    {
        get
        {
            return (T)SelectedO;
        }
    }
    public static List<T> GetItemsListT(ItemCollection items)
    {
        List<T> result = new List<T>();
        foreach (object var in items)
        {
            if (var is T)
            {
                result.Add((T)var);
            }
        }
        return result;
    }
}
/// <summary>
/// Um. lepsi man. s LB.
/// </summary>
public class LBH
{
    protected object Selected = null;
    public static void AddRange2List(ListBox listBox, IList items)
    {
        foreach (var item in items)
        {
            listBox.Items.Add(item);
        }
    }
    public static void AddRange2(ListBox listBox, params object[] list)
    {
        foreach (var item in list)
        {
            listBox.Items.Add(item);
        }
    }
    public void AddRange(params object[] list)
    {
        //var enu = CA.ToEnumerable(list);
        foreach (var item in list)
        {
            lb.Items.Add(item);
        }
    }
    /// <summary>
    /// Zkopiruje do schranky vsechny polozky v lb
    /// </summary>
    public void CopyToClipboard()
    {
        StringBuilder stringBuilder = new StringBuilder();
        foreach (IListBoxHelperItem var in lb.Items)
        {
            stringBuilder.AppendLine(var.ToString());
        }
        ClipboardService.SetText(stringBuilder.ToString());
    }
    public void CopyToClipboardShort()
    {
        StringBuilder stringBuilder = new StringBuilder();
        foreach (IListBoxHelperItem var in lb.Items)
        {
            stringBuilder.AppendLine(var.ShortName);
        }
        ClipboardService.SetText(stringBuilder.ToString());
    }
    #region DPP
    public event Action<object> ItemRemoved;
    /// <summary>
    /// Dont register 
    /// </summary>
    public event Action ItemSelected;
    /// <summary>
    /// LB, na kt. se kont.
    /// </summary>
    protected ListBox lb;
    #endregion
    protected MouseButton mb = MouseButton.XButton1;
    private void Lb_MouseDown(object sender, MouseButtonEventArgs eventArgs)
    {
        mb = eventArgs.ChangedButton;
    }
    #region base
    /// <summary>
    /// EK, OOP.
    /// Vychozy pro A2 bylo SelectionMode.Extended
    /// </summary>
    /// <param name="listBox"></param>
    public LBH(ListBox listBox, SelectionMode selectionMode)
    {
        this.lb = listBox;
        listBox.SelectionMode = selectionMode;
        listBox.KeyDown += new KeyEventHandler(lb_KeyDown);
        listBox.PreviewMouseDown += Lb_MouseDown;
        listBox.SelectionChanged += Lb_SelectionChanged;
    }
    private void Lb_SelectionChanged(object sender, SelectionChangedEventArgs eventArgs)
    {
        if (eventArgs.AddedItems.Count > 0)
        {
            Selected = eventArgs.AddedItems[0];
            if (ItemSelected != null)
            {
                ItemSelected();
            }
        }
        else
        {
            Selected = null;
        }
    }
    public bool Tag = false;
    public bool runOne = false;
    public bool saveToClipboard = false;
    public bool removeOne = false;
    /// <summary>
    /// Back - otevrit v browseru
    /// Enter - ulozit do schranky
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="eventArgs"></param>
    void lb_KeyDown(object sender, KeyEventArgs eventArgs)
    {
        if (IsSelected)
        {
            #region Enter - Spusti akt. polozku v LB. Nepridava k ni nic.
            if (eventArgs.Key == Key.Enter)
            {
                if (runOne)
                {
                    RunSelected();
                }
            }
            #endregion
            #region C - Ulozi do schr.
            else if (eventArgs.Key == Key.C)
            {
                if (saveToClipboard)
                {
                    ClipboardService.SetText(SelectedS);
                }
            }
            #endregion
            #region del - smaze tuto domenu
            else if (eventArgs.Key == Key.Delete)
            {
                if (removeOne)
                {
                    if (IsSelected)
                    {
                        if (ItemRemoved != null)
                        {
                            ItemRemoved(SelectedO);
                        }
                        lb.Items.Remove(SelectedO);
                    }
                }
            }
            #endregion
        }
    }
    protected void RunSelected()
    {
        if (Selected is IListBoxHelperItem)
        {
            IListBoxHelperItem lbi = Selected as IListBoxHelperItem;
            PH.Start();
        }
        else
        {
            PH.Start();
        }
    }
    #endregion
    #region H
    /// <summary>
    /// G zda byla v LB vybr. polozka.
    /// </summary>
    public object SelectedO
    {
        get
        {
            return Selected;
            //return lb.SelectedItem;
        }
    }
    /// <summary>
    /// G zda byla v LB vybr. polozka.
    /// </summary>
    public bool IsSelected
    {
        get
        {
            string selectedText = SelectedS;
            return !string.IsNullOrEmpty(selectedText);
            //return lb;
        }
    }
    /// <summary>
    /// Nek. aut. Vybrana, musi se volat tedy az po.
    /// G Tr vybr. polozky.
    /// </summary>
    public string SelectedS
    {
        get
        {
            //object o = lb.SelectedItem;
            object selected = Selected;
            if (selected == null)
            {
                return null;
            }
            return selected.ToString();
        }
        set
        {
            lb.Items[lb.SelectedIndex] = value;
        }
    }
    #endregion
    #region MyRegion
    /// <summary>
    /// Prida do pp lb polozku. Nekontroluje, zda jiz existuje.
    /// </summary>
    /// <param name="item"></param>
    public void Add(object item)
    {
        lb.Items.Add(item);
    }
    /// <summary>
    /// Odebere do pp lb polozku. Nekontroluje, zda jiz neexistuje.
    /// </summary>
    /// <param name="item"></param>
    public void Remove(object item)
    {
        lb.Items.Remove(item);
    }
    #endregion
    public List<string> GetItemsListString()
    {
        List<string> result = new List<string>();
        foreach (object item in lb.Items)
        {
            result.Add(item.ToString());
        }
        return result;
    }
    public static List<string> GetSelectedListString(IList selectedObjectCollection)
    {
        List<string> result = new List<string>();
        foreach (object var in selectedObjectCollection)
        {
            result.Add(var.ToString());
        }
        return result;
    }
    public static List<T1> GetItemsListT<T1>(ItemCollection objectCollection)
    {
        List<T1> result = new List<T1>();
        foreach (T1 var in objectCollection)
        {
            result.Add(var);
        }
        return result;
    }
    public static List<string> GetItemsListString(ItemCollection objectCollection)
    {
        List<string> result = new List<string>();
        foreach (object var in objectCollection)
        {
            result.Add(var.ToString());
        }
        return result;
    }
}