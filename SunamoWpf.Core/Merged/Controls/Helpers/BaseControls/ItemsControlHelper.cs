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
        var sorted = mi2.OrderByDescending(d2 => d2.Key);
        foreach (var item in sorted)
        {
            for (int i = item.Value.Count - 1; i >= 0; i--)
            {
                var item2 = item.Value[i];
                var ic = item2 as SuMenuItem;
                string header = "(null)";
                if (ic != null)
                {
#if DEBUG
                    if (ic.Header != null)
                    {
                        header = ic.Header.ToString();
                        if (header == "Xlf")
                        {
                        }
                        else if (header == "Also project on which depend")
                        {
                        }
                    }
                    if (ic.Name != null)
                    {
                        if (ic.Name == "miAddSelectedSunamoProjectsToProjects")
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
                if (!ic.onClick)
                {
                    var mip = ic.Parent as MenuItem;
                    if (mip != null)
                    {
                        mip.Items.Remove(ic);
                        continue;
                    }
                }
                if (item2 == neverDelete)
                {
                    continue;
                }
                if (item2.Items.Count == 0)
                {
                    var mi = item2 as SuMenuItem;
                    if (mi.onClick)
                    {
                        continue;
                    }
                    var ic2 = item2.Parent as ItemsControl;
                    if (ic2 == null)
                    {
                        // ic is Grid etc.
                        continue;
                    }
                    if (ic.onClick)
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
        foreach (var i2 in item.Items)
        {
            var mi = i2 as ItemsControl;
            AddSubitems(list, mi);
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
    public static void RecursivelyAllSubItems<T>(List<ItemsControl> ic, ItemCollection items) where T : ItemsControl
    {
        foreach (T item in items)
        {
            ic.Add(item);
            RecursivelyAllSubItems<T>(ic, item.Items);
        }
    }
}
;