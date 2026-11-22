namespace SunamoWpf.Collections;

using System.Collections.Specialized;

/// <summary>
/// Represents the auto indexed observable collection t type.
/// </summary>
public class AutoIndexedObservableCollection<T> : ObservableCollection<T>
    where T : INotifyPropertyChanged, IIdentificatorT<int>
{
    private int dex = 1;

    /// <summary>
    /// Initializes a new instance of the auto indexed observable collection class.
    /// </summary>
    public AutoIndexedObservableCollection()
    {
        CollectionChanged += FullObservableCollectionCollectionChanged;
    }

    /// <summary>
    /// Initializes a new instance of the auto indexed observable collection class.
    /// </summary>
    /// <param name="pItems">The p items.</param>
    public AutoIndexedObservableCollection(IList<T> pItems) : this()
    {
        foreach (var item in pItems) Add(item);
    }

    /// <summary>
    /// Checked indexes.
    /// </summary>
    /// <returns>The checked indexes result.</returns>
    public List<int> CheckedIndexes()
    {
        //List<int> result = new List<int>();
        return this.Where(item => item.IsChecked).Select(checkedItem => checkedItem.Id).ToList();
    }

    /// <summary>
    /// Checked elements.
    /// </summary>
    /// <returns>The checked elements result.</returns>
    public List<T> CheckedElements()
    {
        return this.Where(item => item.IsChecked).ToList();
    }

    /// <summary>
    /// Add range.
    /// </summary>
    /// <param name="items">The items.</param>
    public void AddRange(IList<T> items)
    {
        foreach (var item in items) Add(item);
    }

    /// <summary>
    /// Add.
    /// </summary>
    /// <param name="item">The item.</param>
    public new void Add(T item)
    {
        item.Id = dex++;
        base.Add(item);
    }

    private void FullObservableCollectionCollectionChanged(object sender, NotifyCollectionChangedEventArgs eventArgs)
    {
        if (eventArgs.NewItems != null)
            foreach (var item in eventArgs.NewItems)
                if (item != null)
                    ((INotifyPropertyChanged)item).PropertyChanged += ItemPropertyChanged;
        if (eventArgs.OldItems != null)
            foreach (var item in eventArgs.OldItems)
                if (item != null)
                    ((INotifyPropertyChanged)item).PropertyChanged -= ItemPropertyChanged;
    }

    private void ItemPropertyChanged(object sender, PropertyChangedEventArgs eventArgs)
    {
        var args = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, sender, sender,
            IndexOf((T)sender));
        OnCollectionChanged(args);
    }
}