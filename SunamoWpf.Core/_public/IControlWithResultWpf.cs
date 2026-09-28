namespace SunamoWpf._public;

public interface IControlWithResultWpf
{




    event VoidBoolNullable ChangeDialogResult;





    bool? DialogResult { set; }

    void Accept(object input);
    void FocusOnMainElement();

}