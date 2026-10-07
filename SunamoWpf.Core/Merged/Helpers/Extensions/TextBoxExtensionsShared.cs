#define ASYNC
namespace SunamoWpf.Extensions;

public static partial class TextBoxExtensions
{
    /// <summary>
    /// Before first calling I have to set validated = true
    /// </summary>
    /// <param name = "validated"></param>
    /// <param name = "textBox"></param>
    /// <param name = "control"></param>
    /// <param name = "trim"></param>
    public static void Validate(this TextBox control, object textBox, ref ValidateDataWpf validateData)
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
        var tbTos = TextBlockHelper.TextOrToString(textBox);
        if (validateData.validateMethod != null)
        {
            // ContainsInvalidFileNameChars return true if fails, therefore here cant be!
            if (!validateData.validateMethod(text))
            {
                if (validateData.messageWhenValidateMethodFails == null)
                {
                    validateData.messageWhenValidateMethodFails = tbTos + " must be filled";
                }
                validateData.messageToReallyShow = validateData.messageWhenValidateMethodFails;
                validated = false;
                return;
            }
        }
        if (CAG.IsEqualToAnyElement<string>(text.Trim(), validateData.excludedStrings))
        {
            //InitApp.TemplateLogger.HaveUnallowedValue(tbTos);
            validated = false;
            return;
        }
        if (text == string.Empty && !validateData.allowEmpty)
        {
            //InitApp.TemplateLogger.MustHaveValue(tbTos);
            validated = false;
        }
        else
        {
            validated = true;
        }
    }
    public static bool validated
    {
        get => ValidationHelper.validated;
        set => ValidationHelper.validated = value;
    }
}