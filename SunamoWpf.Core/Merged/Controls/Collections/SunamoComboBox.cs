#define ASYNC
namespace SunamoWpf.Controls.Collections;

/// <summary>
/// Represents the sunamo combo box type.
/// </summary>
public class SunamoComboBox : ComboBox
{
    static Type type = typeof(SunamoComboBox);

    /// <summary>
    /// Initializes a new instance of the sunamo combo box class.
    /// </summary>
    public SunamoComboBox()
    {
        this.KeyUp += SunamoComboBox_KeyUp;
    }

    /// <summary>
    /// The cb.
    /// </summary>
    public ComboBox cb
    {
        get
        {
            return this;
        }
    }

    TextBox editableTextBox;

    /// <summary>
    /// On apply template.
    /// </summary>
    public override void OnApplyTemplate()
    {
        SetEditableTextbox();
    }

    /// <summary>
    /// Set caret.
    /// </summary>
    /// <param name="position">The position.</param>
    public void SetCaret(int position)
    {
        this.editableTextBox.SelectionStart = position;
        this.editableTextBox.SelectionLength = 0;
    }

    void SetEditableTextbox()
    {
        base.OnApplyTemplate();
        string nameChild = "PART_EditableTextBox";
        //var d = GetTemplateChild(nameChild);
        var child = Template.FindName(nameChild, this);
        if (child != null)
        {
            string type = child.GetType().FullName;
            var myTextBox = child as TextBox;
            if (myTextBox != null)
            {
                this.editableTextBox = myTextBox;
            }
        }
    }

    private void SunamoComboBox_KeyUp(object sender, System.Windows.Input.KeyEventArgs eventArgs)
    {
        if (eventArgs.Key == Key.Space)
        {
            this.Text += " ";
            SetCaret(editableTextBox.Text.Length);
        }
    }
}