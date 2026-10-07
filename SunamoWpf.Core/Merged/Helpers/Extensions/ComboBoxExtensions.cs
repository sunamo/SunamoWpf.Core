#define ASYNC
namespace SunamoWpf.Extensions;

public static class ComboBoxExtensions
{
    public static bool validated
    {
        get => ValidationHelper.validated;
        set => ValidationHelper.validated = value;
    }

    /// <summary>
    /// Before first calling I have to set validated = true
    /// </summary>
    /// <param name="validated"></param>
    /// <param name="tb"></param>
    /// <param name="control"></param>
    /// <param name="trim"></param>
    public static void Validate(this ComboBox control, ref ValidateDataWpf validateData)
    {
        if (!validated)
        {
            return;
        }
        if (validateData == null)
        {
            validateData = new ValidateDataWpf();
        }
        string text = control.Text;
        if (validateData.trim)
        {
            text = text.Trim();
        }
        if (text == string.Empty)
        {
            //InitApp.TemplateLogger.MustHaveValue(TextBlockHelper.TextOrToString(tb));
            validated = false;
        }
        else
        {
            validated = true;
        }
    }
}