#define ASYNC
namespace SunamoWpf.Controls;

/// <summary>
/// UC for deleting duplicate files
/// Only one file can keep
/// </summary>
public partial class DeleteDuplicitiesFilesRadioButton : UserControl, ISelectFromMany<TWithSizeInString<string>>
{
    #region Rewrite to pure cs. With xaml is often problems without building
    internal SelectFromManyHelper<TWithSizeInString<string>> sfmh = null;

    public DeleteDuplicitiesFilesRadioButton()
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
        spFolders.Children.Add(ControlsGenerator.RadioButtonWithDescription(data, !sfmh.sufficientFileName, tick));
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
    #endregion
}
