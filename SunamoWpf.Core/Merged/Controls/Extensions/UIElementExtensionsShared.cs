#define ASYNC
namespace SunamoWpf.Controls.Extensions;

public static partial class UIElementExtensions
{
    static Type type = typeof(UIElementExtensions);
    public static Func<UIElement, string, ValidateDataWpf, bool?> Validate2FullDelegate = null;
    public static Func<UIElement, bool, bool> SetValidatedFullDelegate = null;
    public static bool validatedInFull = false;
    /// <summary>
    /// Must be be Validate2 due to different with Validate which is defi
    /// From A3 removed = null & add ref => Validate2() is only one place which ci ValidateData
    /// </summary>
    /// <param name = "uiElement"></param>
    /// <param name = "name"></param>
    public static bool? Validate2(this UIElement uiElement, string name, ref ValidateDataWpf validateData)
    {
        if (Validate2FullDelegate != null)
        {
            var result = Validate2FullDelegate.Invoke(uiElement, name, validateData);
            if (validatedInFull)
            {
                return result;
            }
        }
        if (validateData == null)
        {
            validateData = new ValidateDataWpf();
        }
        var type2 = uiElement.GetType();
        if (type2 == TypesControls.tTextBox)
        {
            var textBox = uiElement as TextBox;
            textBox.Validate(name, ref validateData);
            return TextBoxHelper.validated;
        }
        // ListBoxHelper
        //else if (t == TypesControls.tListBox)
        //{
        //    var c = ui as ListBox;
        //    c.Validate(/*name,*/ d);
        //    return ListBoxHelper.validated;
        //}
        // ListViewHelper doesnt exists
        //else if (t == TypesControls.tListView)
        //{
        //    var c = ui as ListView;
        //    c.Validate(/*name,*/ d);
        //    return ListViewHelper.validated;
        //}
        else if (type2 == TypesControls.tComboBox)
        {
            var comboBox = uiElement as ComboBox;
            comboBox.Validate(/*name,*/ ref validateData);
            return ComboBoxHelper.validated;
        }
        else if (type2 == SelectFile.type)
        {
            var selectFile = uiElement as SelectFile;
            selectFile.Validate(/*name,*/ ref validateData);
            return SelectFile.validated;
        }
        else if (type2 == SelectManyFiles.type)
        {
            var selectManyFiles = uiElement as SelectManyFiles;
            selectManyFiles.Validate(ref validateData);
            return SelectManyFiles.validated;
        }
        else if (type2 == TwoRadiosUC.type)
        {
            var twoRadios = uiElement as TwoRadiosUC;
            twoRadios.Validate(/*name,*/ ref validateData);
            return TwoRadiosUC.validated;
        }
        else if (type2 == TypesControlsSunamo.tPathEditor)
        {
            IValidateControl validateControl = (IValidateControl)uiElement;
            return validateControl.Validate(name, ref validateData);
        }
        else
        {
            ThrowEx.NotImplementedCase(type2);
        }
        return null;
    }
    public static void SetValidated(this UIElement uiElement, bool value)
    {
        if (SetValidatedFullDelegate != null)
        {
            if (SetValidatedFullDelegate.Invoke(uiElement, value))
            {
                return;
            }
        }
        var type2 = uiElement.GetType();
        if (type2 == TypesControls.tTextBox)
        {
            TextBoxHelper.validated = value;
        }
        else if (type2 == TypesControls.tListBox)
        {
            ListBoxExtensions.validated = value;
        }
        else if (type2 == TypesControls.tListView)
        {
            ListViewExtensions.validated = value;
        }
        else if (type2 == TypesControls.tComboBox)
        {
            ComboBoxExtensions.validated = value;
        }
        else if (type2 == SelectFile.type)
        {
            SelectFile.validated = value;
        }
        else if (type2 == SelectManyFiles.type)
        {
            SelectManyFiles.validated = value;
        }
        else if (type2 == TypesControlsSunamo.tPathEditor)
        {
            var ivc = (IValidateControl)uiElement;
            ivc.Validated = value;
        }
        else
        {
            ThrowEx.NotImplementedCase(type2.FullName);
        }
    }
    /// <summary>
    /// There is no Enum with all controls
    /// </summary>
    /// <param name="uiElement"></param>
    public static object GetContent(this UIElement uiElement)
    {
        var type2 = uiElement.GetType();
        if (type2 == TypesControls.tListBox)
        {
            var selector = (ListBox)uiElement;
            return selector.SelectedItems;
        }
        else if (type2 == TypesControls.tListView)
        {
            var listView = (ListView)uiElement;
            return listView.SelectedItems;
        }
        else if (type2 == TypesControls.tComboBox)
        {
            var comboBox = uiElement as ComboBox;
            return comboBox.Text;
        }
        else if (type2 == TypesControls.tTextBox)
        {
            var txt = (TextBox)uiElement;
            return txt.Text;
        }
        else if (type2 == TypesControls.tCheckBox)
        {
            var txt = (CheckBox)uiElement;
            return txt.Content;
        }
        else if (type2 == TwoRadiosUC.type)
        {
            var txt = (TwoRadiosUC)uiElement;
            return txt.GetBool();
        }
        else if (type2 == TypesControlsSunamo.tPathEditor)
        {
            var txt = (IValidateControl)uiElement;
            return txt.GetContent();
        }
        else if (type2 == TypesControls.tTextBlock)
        {
            var txt = (TextBlock)uiElement;
            return txt.Text;
        }
        else
        {
            ThrowEx.NotImplementedCase(type2);
        }
        return null;
    }
}