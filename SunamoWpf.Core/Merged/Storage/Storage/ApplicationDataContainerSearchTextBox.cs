

namespace SunamoWpf.Storage;

public class ApplicationDataContainerSearchTextBox : ApplicationDataContainer, IApplicationDataContainerSearchTextBox
{
    // Nemůžu použít statický ctor protože mám ve třídách jen interface
    //static ApplicationDataContainerSearchTextBox()
    //{
    //    ApplicationDataContainer.apcSearchTextBox = new ApplicationDataContainerSearchTextBox();
    //}

    public ApplicationDataContainerSearchTextBox()
    {

    }

    private void Chbl_CollectionChanged(object sender, ListOperation operation, object data)
    {
        CheckBoxListUC chb = sender as CheckBoxListUC;
        var items = new List<string>();
        foreach (var item in chb.l.l)
        {
            items.Add(ContentControlHelper.ExtractContent(item.o.Content)?.ToString() ?? string.Empty);
            items.Add(BTS.BoolToInt(item.o.IsChecked.Value).ToString());
        }
        var sb = string.Join(innerDelimiter, items);
        Set(sender, chbAdded, sb);
        SaveControl(chb);
    }


    public void Add(ICheckBoxListUC chbl)
    {
        var adcl = AddFrameworkElement(chbl as FrameworkElement);
        var list = adcl.GetListString(chbAdded, innerDelimiter);
        for (int i = 0; i < list.Count; i++)
        {
            var chb = CheckBoxHelper.Get(new ControlInitData { text = list[i] });
            var maybeInt = list[++i];
            if (!BTS.IsInt(maybeInt))
            {
            }
            chb.IsChecked = BTS.IntToBool(maybeInt);

            NotifyPropertyChangedWrapper<CheckBox> notifyChb = new NotifyPropertyChangedWrapper<CheckBox>(chb, ToggleButton.IsCheckedProperty);

            chbl.l.l.Add(notifyChb);
        }
        chbl.l.CollectionChanged += Chbl_CollectionChanged;
    }
}
