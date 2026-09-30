#define ASYNC
namespace SunamoWpf.Controls.Controls;

/// <summary>
/// NC = Not Commented
/// </summary>
public partial class TwoRadiosUC
{
    public static Type type = typeof(TwoRadiosUC);
    public static bool validated
    {
        get
        {
            return TwoRadiosUC.validated;
        }
        set
        {
            TwoRadiosUC.validated = value;
        }
    }

    public object GetBool()
    {
        if (rb1.IsCheckedSimple())
        {
            return true;
        }
        return false;
    }
    public bool Validate(ref ValidateDataWpf d)
    {
        if (d == null)
        {
            d = new ValidateDataWpf();
        }
        validated = BTS.GetValueOfNullable(rb1.IsChecked) || BTS.GetValueOfNullable(rb2.IsChecked);
        return validated;
    }
    public TwoRadiosUC(TwoState addRemove)
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
        switch (addRemove)
        {
            case TwoState.TrueFalse:
                rb1.Content = "True";
                rb2.Content = "False";
                break;
            case TwoState.AddRemove:
                rb1.Content = "Add";
                rb2.Content = Translate.FromKey(XlfKeys.Remove);
                break;
            case TwoState.AcceptDecline:
                rb1.Content = Translate.FromKey(XlfKeys.Accept);
                rb2.Content = Translate.FromKey(XlfKeys.Decline);
                break;
            default:
                break;
        }
        Tag = "TwoRadiosUC";
    }
}
public partial class TwoRadiosUC : UserControl
{
}
