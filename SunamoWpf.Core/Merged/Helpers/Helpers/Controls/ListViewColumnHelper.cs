#define ASYNC
namespace SunamoWpf.Helpers.Controls;

/// <summary>
/// Must be IIdentificatorDesktop to avoid checking ltems which isnt visible 
/// </summary>
/// <typeparam name="T"></typeparam>
public class ListViewColumnHelper<T> where T : IIdentificatorDesktop<int>
{
    /// <summary>
    /// The type.
    /// </summary>
    public static Type type = typeof(ListViewColumnHelper<T>);
    /// <summary>
    /// The last id.
    /// </summary>
    public int lastId = int.MinValue;
    private ListView lstViewXamlColumns;
    /// <summary>
    /// Initializes a new instance of the list view column helper class.
    /// </summary>
    /// <param name="lstViewXamlColumns">The lst view xaml columns.</param>
    public ListViewColumnHelper(ListView lstViewXamlColumns)
    {
        this.lstViewXamlColumns = lstViewXamlColumns;
    }
    //public event Action<int, int> MultiCheck;
    /// <summary>
    /// Check box click.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The e.</param>
    /// <param name="chb2">The chb 2.</param>
    public void CheckBox_Click(object sender, /*RoutedEventArgs e, */Checkboxes chb2)
    {
        if (Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift))
        {
            var chb = (CheckBox)sender;
            var lastId2 = BTS.ParseInt(chb.Tag.ToString());
            GridView2_MultiCheck(lastId, lastId2, chb2);
        }
        else
        {
            var chb = (CheckBox)sender;
            lastId = BTS.ParseInt(chb.Tag.ToString());
        }
    }
    /// <summary>
    /// Grid view 2 multi check.
    /// </summary>
    /// <param name="arg1">The arg 1.</param>
    /// <param name="arg2">The arg 2.</param>
    /// <param name="chb2">The chb 2.</param>
    public void GridView2_MultiCheck(int arg1, int arg2, Checkboxes chb2)
    {
        List<int> sorted = NH.Sort<int>(arg1, arg2);
        sorted[1]++;
        // is already checked actully, so i dont negate
        var col = ((ObservableCollection<T>)lstViewXamlColumns.ItemsSource);
        var first = col.First(column => column.Id == arg1);
        bool setUp = false;
        switch (chb2)
        {
            case Checkboxes.IsChecked:
                setUp = first.IsChecked;
                break;
            case Checkboxes.IsSelected:
                setUp = first.IsSelected;
                break;
            default:
                ThrowEx.NotImplementedCase(chb2);
                break;
        }
        for (int index = sorted[0]; index < sorted[1]; index++)
        {
            first = col.FirstOrDefault(gridColumn => gridColumn.Id == index);
            if (!EqualityComparer<T>.Default.Equals(default(T), first))
            {
                switch (chb2)
                {
                    case Checkboxes.IsChecked:
                        if (first.Visibility == Visibility.Visible)
                        {
                            first.IsChecked = setUp;
                        }
                        break;
                    case Checkboxes.IsSelected:
                        if (first.Visibility == Visibility.Visible)
                        {
                            first.IsSelected = setUp;
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}