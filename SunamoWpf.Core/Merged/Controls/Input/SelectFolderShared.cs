#define ASYNC
namespace SunamoWpf.Controls.Input;

partial class SelectFolder
{
    /// <summary>
    /// The type.
    /// </summary>
    public static Type type = typeof(SelectFolder);
    /// <summary>
    /// The validated.
    /// </summary>
    public static bool validated
    {
        get => ValidationHelper.validated;
        set => ValidationHelper.validated = value;
    }
    /// <summary>
    /// Validate.
    /// </summary>
    public void Validate()
    {
        SelectFolder.Validate(this);
    }

    /// <summary>
    /// Before first calling I have to set validated = true
    /// Its instance to avoid include another namespace
    /// </summary>
    /// <param name="validated"></param>
    /// <param name="tb"></param>
    /// <param name="control"></param>
    /// <param name="trim"></param>
    public static void Validate(SelectFolder control/*, ref ValidateDataWpf d*/)
    {
        if (!validated)
        {
            return;
        }
        string text = RH.GetValueOfPropertyOrField(control, "SelectedFolder").ToString();
        text = text.Trim();
        if (text == string.Empty)
        {
            //InitApp.TemplateLogger.MustHaveValue(TextBlockHelper.TextOrToString(tb));
            validated = false;
        }
        else if (!FS.ExistsDirectory(text))
        {
            //InitApp.TemplateLogger.FolderDontExists(text);
            validated = false;
        }
        else
        {
            validated = true;
        }
    }
}