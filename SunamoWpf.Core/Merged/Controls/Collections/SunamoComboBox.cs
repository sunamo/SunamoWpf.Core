#define ASYNC
namespace SunamoWpf.Controls.Collections;

public class SunamoComboBox : ComboBox
{
    static Type type = typeof(SunamoComboBox);

    public SunamoComboBox()
    {
        this.KeyUp += SunamoComboBox_KeyUp;
    }

    public ComboBox cb
    {
        get
        {
            return this;
        }
    }

    TextBox editableTextBox;

    public override void OnApplyTemplate()
    {
        SetEditableTextbox();
    }

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