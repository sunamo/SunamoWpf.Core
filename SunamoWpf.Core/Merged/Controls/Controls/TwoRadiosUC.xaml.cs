#define ASYNC
namespace SunamoWpf.Controls.Controls;

/// <summary>
/// NC = Not Commented
/// </summary>
public partial class TwoRadiosUC
{
    /// <summary>
    /// The type.
    /// </summary>
    public static Type type = typeof(TwoRadiosUC);
    /// <summary>
    /// The validated.
    /// </summary>
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

    /// <summary>
    /// Get bool.
    /// </summary>
    /// <returns>The get bool result.</returns>
    public object GetBool()
    {
        if (rb1.IsCheckedSimple())
        {
            return true;
        }
        return false;
    }
    /// <summary>
    /// Validate.
    /// </summary>
    /// <param name="validateData">The validate data.</param>
    /// <returns>The validate result.</returns>
    public bool Validate(ref ValidateDataWpf validateData)
    {
        if (validateData == null)
        {
            validateData = new ValidateDataWpf();
        }
        validated = BTS.GetValueOfNullable(rb1.IsChecked) || BTS.GetValueOfNullable(rb2.IsChecked);
        return validated;
    }
    /// <summary>
    /// Initializes a new instance of the two radios UC class.
    /// </summary>
    /// <param name="addRemove">The add remove.</param>
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
                rb2.Content = "Remove";
                break;
            case TwoState.AcceptDecline:
                rb1.Content = "Accept";
                rb2.Content = "Decline";
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
