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
        return this.Where(d => d.IsChecked).Select(r => r.Id).ToList();
    }

    public List<T> CheckedElements()
    {
        return this.Where(d => d.IsChecked).ToList();
    }

    public void AddRange(IList<T> t)
    {
        foreach (var item in t) Add(item);
    }

    public new void Add(T item)
    {
        item.Id = dex++;
        base.Add(item);
    }

    private void FullObservableCollectionCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        if (e.NewItems != null)
            foreach (var item in e.NewItems)
                if (item != null)
                    ((INotifyPropertyChanged)item).PropertyChanged += ItemPropertyChanged;
        if (e.OldItems != null)
            foreach (var item in e.OldItems)
                if (item != null)
                    ((INotifyPropertyChanged)item).PropertyChanged -= ItemPropertyChanged;
    }

    private void ItemPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        var args = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, sender, sender,
            IndexOf((T)sender));
        OnCollectionChanged(args);
    }
}