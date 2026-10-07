#define ASYNC
namespace SunamoWpf.Controls.Helpers.BaseControls;

public class ItemsControlHelper
{
    public static void RemoveWhichHaveNoItem(ItemsControl neverDelete, List<ItemsControl> rootMis)
    {
        // 1) Rekurzivně zjistím vš. položky
        List<ItemsControl> list = new List<ItemsControl>();
        foreach (var item in rootMis)
        {
            // Rekurzivně přidá
            AddSubitems(list, item);
        }
        // 2) Procházím je a mažu
        Dictionary<int, List<ItemsControl>> mi2 = new Dictionary<int, List<ItemsControl>>();
        foreach (var item in list)
        {
            var coa = FrameworkElementHelper.CountOfAncestor(item);
            DictionaryHelper.AddOrCreate<int, ItemsControl>(mi2, coa, item);
        }
        var sorted = mi2.OrderByDescending(entry => entry.Key);
        foreach (var item in sorted)
        {
            for (int index = item.Value.Count - 1; index >= 0; index--)
            {
                var item2 = item.Value[index];
                var itemsControl = item2 as SuMenuItem;
                string header = "(null)";
                if (itemsControl != null)
                {
#if DEBUG
                    if (itemsControl.Header != null)
                    {
                        header = itemsControl.Header.ToString();
                        if (header == "Xlf")
                        {
                        }
                        else if (header == "Also project on which depend")
                        {
                        }
                    }
                    if (itemsControl.Name != null)
                    {
                        if (itemsControl.Name == "miAddSelectedSunamoProjectsToProjects")
                        {
                        }
                    }
#endif
                }
                if (item2.GetType() == TypesControls.tMenu)
                {
                    continue;
                }
                if (item2.Items.Count != 0)
                {
                    continue;
                }
                if (!itemsControl.onClick)
                {
                    var mip = itemsControl.Parent as MenuItem;
                    if (mip != null)
                    {
                        mip.Items.Remove(itemsControl);
                        continue;
                    }
                }
                if (item2 == neverDelete)
                {
                    continue;
                }
                if (item2.Items.Count == 0)
                {
                    var menuItem = item2 as SuMenuItem;
                    if (menuItem.onClick)
                    {
                        continue;
                    }
                    var ic2 = item2.Parent as ItemsControl;
                    if (ic2 == null)
                    {
                        // ic is Grid etc.
                        continue;
                    }
                    if (itemsControl.onClick)
                    {
                        //DebugLogger.instance.WriteLine(header);
                    }
                    ic2.Items.Remove(item2);
                }
            }
        }
    }
    private static void AddSubitems(List<ItemsControl> list, ItemsControl item)
    {
        if (item == null)
        {
            return;
        }
        list.Add(item);
        foreach (var subItem in item.Items)
        {
            var subItemsControl = subItem as ItemsControl;
            AddSubitems(list, subItemsControl);
        }
    }
    public static List<ItemsControl> RecursivelyAllSubItems<T>(ItemCollection items) where T : ItemsControl
    {
        List<ItemsControl> result = new List<ItemsControl>();
        RecursivelyAllSubItems<T>(result, items);
#if DEBUG
        var mis = new List<MenuItem>();
        foreach (var item in result)
        {
            mis.Add((MenuItem)item);
        }
        var n = mis.Where(d => d.Header.ToString() == "Split all strings");
#endif
        return result;
    }
    public static void RecursivelyAllSubItems<T>(List<ItemsControl> result, ItemCollection items) where T : ItemsControl
    {
        foreach (T item in items)
        {
            result.Add(item);
            RecursivelyAllSubItems<T>(result, item.Items);
        }
    }
}
;