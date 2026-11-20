#define ASYNC
namespace SunamoWpf.Controls;

public partial class DeleteDuplicitiesFilesCheckBox : UserControl, ISelectFromMany<TWithSizeInString<string>>
{
    SelectFromManyHelper<TWithSizeInString<string>> sfmh = null;

    /// <summary>
    /// Initializes a new instance of the delete duplicities files check box class.
    /// </summary>
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

    /// <summary>
    /// Add control.
    /// </summary>
    /// <param name="data">The data.</param>
    /// <param name="tick">The tick.</param>
    public void AddControl(TWithSizeInString<string> data, bool tick)
    {
        spFolders.Children.Add(ControlsGenerator.CheckBoxWithDescription(data, !sfmh.sufficientFileName, tick));
    }

    /// <summary>
    /// Add controls.
    /// </summary>
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
