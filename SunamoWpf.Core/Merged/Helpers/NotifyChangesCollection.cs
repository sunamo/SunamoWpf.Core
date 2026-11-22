#define ASYNC
namespace SunamoWpf;

/// <summary>
/// This is only one implement IList
/// Must be in SunamoWpf - Use WpfApp.cd and Dispatcher is not in standard
/// </summary>
/// <typeparam name="T"></typeparam>
public class NotifyChangesCollection<T> : IList<T> where T : INotifyPropertyChanged
{
    /// <summary>
    /// Gets the c.
    /// </summary>
    public NotifyChangesCollection<T> c => this;
    /// <summary>
    /// Its collection due to use also ObservableCollection and so
    /// </summary>
    public Collection<T> l = null;
    /// <summary>
    /// The collection changed.
    /// </summary>
    public event Action<object, ListOperation, object> CollectionChanged;
    /// <summary>
    /// sender is chbl but in Tag are last clicked chb
    /// </summary>
    private object _sender;
    /// <summary>
    /// The eoa.
    /// </summary>
    public EventOnArgs eoa = null;
    /// <summary>
    /// The eoa was changed.
    /// </summary>
    public EventOnArgs eoaWasChanged = new EventOnArgs(false);
    /// <summary>
    /// Event on.
    /// </summary>
    /// <param name="eventOnArgs">The event on args.</param>
    public void EventOn(EventOnArgs eventOnArgs)
    {
        this.eoa = eventOnArgs;
    }
    /// <summary>
    /// Into args you can insert sth like this, new ObservableCollection<NotifyPropertyChangedWrapper<CheckBox>>()
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="collection"></param>
    public NotifyChangesCollection(object sender, Collection<T> collection)
    {
        _sender = sender;
        l = collection;
    }
    /// <summary>
    /// Gets the this int.
    /// </summary>
    public T this[int index] { get => l[index]; set => l[index] = value; }
    /// <summary>
    /// Gets the count.
    /// </summary>
    public int Count => l.Count;
    /// <summary>
    /// Gets the is read only.
    /// </summary>
    public bool IsReadOnly => false;
    /// <summary>
    /// Add.
    /// </summary>
    /// <param name="item">The item.</param>
    public void Add(T item)
    {
        item.PropertyChanged += Item_PropertyChanged;
        WpfApp.cd.Invoke((Action)delegate // <--- HERE
        {
            //_matchObsCollection.Add(match);
            l.Add(item);
        });
        if (eoa.onAdd)
        {
            OnCollectionChanged(ListOperation.Add, item);
        }
    }
    private void Item_PropertyChanged(object sender, PropertyChangedEventArgs eventArgs)
    {
        if (eoa.onPropertyChanged)
        {
            T item = (T)sender;
            if (eventArgs.PropertyName == "IsChecked")
            {
                var toggleButton = (ToggleButton)sender;
                bool? isChecked = (bool?)toggleButton.GetValue(ToggleButton.IsCheckedProperty);
                if (isChecked.GetValueOrDefault())
                {
                    OnCollectionChanged(ListOperation.Checked, item);
                }
                else
                {
                    OnCollectionChanged(ListOperation.Unchecked, item);
                }
            }
            else
            {
                OnCollectionChanged(ListOperation.PropertyChanged, item);
            }
        }
    }
    /// <summary>
    /// Clear.
    /// </summary>
    public void Clear()
    {
        l.Clear();
        if (eoa.onClear)
        {
            OnCollectionChanged(ListOperation.Clear, null);
        }
    }
    /// <summary>
    /// Contains.
    /// </summary>
    /// <param name="item">The item.</param>
    /// <returns>The contains result.</returns>
    public bool Contains(T item)
    {
        return l.Contains(item);
    }
    /// <summary>
    /// Copy to.
    /// </summary>
    /// <param name="array">The array.</param>
    /// <param name="arrayIndex">The array index.</param>
    public void CopyTo(T[] array, int arrayIndex)
    {
        l.CopyTo(array, arrayIndex);
    }
    /// <summary>
    /// Get enumerator.
    /// </summary>
    /// <returns>The get enumerator result.</returns>
    public IEnumerator<T> GetEnumerator()
    {
        return l.GetEnumerator();
    }
    /// <summary>
    /// Index of.
    /// </summary>
    /// <param name="item">The item.</param>
    /// <returns>The index of result.</returns>
    public int IndexOf(T item)
    {
        return l.IndexOf(item);
    }
    /// <summary>
    /// Insert.
    /// </summary>
    /// <param name="index">The index.</param>
    /// <param name="item">The item.</param>
    public void Insert(int index, T item)
    {
        l.Insert(index, item);
        if (eoa.onAdd)
        {
            OnCollectionChanged(ListOperation.Insert, item);
        }
    }
    /// <summary>
    /// Remove.
    /// </summary>
    /// <param name="item">The item.</param>
    /// <returns>The remove result.</returns>
    public bool Remove(T item)
    {
        bool removed = l.Remove(item);
        if (eoa.onRemove)
        {
            OnCollectionChanged(ListOperation.Remove, item);
        }
        return removed;
    }
    /// <summary>
    /// Remove at.
    /// </summary>
    /// <param name="index">The index.</param>
    public void RemoveAt(int index)
    {
        l.RemoveAt(index);
        OnCollectionChanged(ListOperation.RemoveAt, index);
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return l.GetEnumerator();
    }
    /// <summary>
    /// On collection changed.
    /// </summary>
    /// <param name="operation">The operation.</param>
    /// <param name="data">The data.</param>
    public void OnCollectionChanged(ListOperation operation, object data)
    {
        if (CollectionChanged != null)
        {
            // must be _sender, not this
            CollectionChanged(_sender, operation, data);
        }
        switch (operation)
        {
            case ListOperation.RemoveAt:
            case ListOperation.Remove:
                eoaWasChanged.onRemove = true;
                break;
            case ListOperation.Insert:
            case ListOperation.Add:
                eoaWasChanged.onAdd = true;
                break;
            case ListOperation.Clear:
                eoaWasChanged.onClear = true;
                break;
            case ListOperation.Checked:
                eoaWasChanged.onCheck = true;
                break;
            case ListOperation.Unchecked:
                eoaWasChanged.onUnCheck = true;
                break;
            case ListOperation.PropertyChanged:
                eoaWasChanged.onPropertyChanged = true;
                break;
            default:
                break;
        }
    }
}