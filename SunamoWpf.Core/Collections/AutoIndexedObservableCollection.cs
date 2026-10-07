namespace SunamoWpf.Collections;

using System.Collections.Specialized;

public class AutoIndexedObservableCollection<T> : ObservableCollection<T>
    where T : INotifyPropertyChanged, IIdentificatorT<int>
{
    private int dex = 1;

    public AutoIndexedObservableCollection()
    {
        CollectionChanged += FullObservableCollectionCollectionChanged;
    }

    public AutoIndexedObservableCollection(IList<T> pItems) : this()
    {
        foreach (var item in pItems) Add(item);
    }

    public List<int> CheckedIndexes()
    {
        //List<int> result = new List<int>();
        return this.Where(item => item.IsChecked).Select(checkedItem => checkedItem.Id).ToList();
    }

    public List<T> CheckedElements()
    {
        return this.Where(item => item.IsChecked).ToList();
    }

    public void AddRange(IList<T> items)
    {
        foreach (var item in items) Add(item);
    }

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