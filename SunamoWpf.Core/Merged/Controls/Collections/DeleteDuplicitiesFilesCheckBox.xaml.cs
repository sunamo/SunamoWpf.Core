#define ASYNC
namespace SunamoWpf.Controls;

public partial class DeleteDuplicitiesFilesCheckBox : UserControl, ISelectFromMany<TWithSizeInString<string>>
{
    SelectFromManyHelper<TWithSizeInString<string>> sfmh = null;

    public DeleteDuplicitiesFilesCheckBox()
    {
        try
        {
            InitializeComponent();
        }
        catch (Exception)
        {
#if DEBUG
            Debugger.Break();
#endif
        }

        sfmh = new SelectFromManyHelper<TWithSizeInString<string>>(this);
    }

    public void AddControl(TWithSizeInString<string> data, bool tick)
    {
        spFolders.Children.Add(ControlsGenerator.CheckBoxWithDescription(data, !sfmh.sufficientFileName, tick));
    }

    public void AddControls()
    {
        spFolders.Children.Clear();
        AddControl(new TWithSizeInString<string> { t = sfmh.defaultFileForLeave, sizeS = sfmh.defaultFileSize }, true);
        foreach (var item in sfmh.filesWithSize)
        {
            if (item.Key != sfmh.defaultFileForLeave)
            {
                AddControl(new TWithSizeInString<string> { t = item.Key, sizeS = item.Value }, false);
            }
        }
    }
}
