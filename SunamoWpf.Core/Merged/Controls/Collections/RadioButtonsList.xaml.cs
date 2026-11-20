#define ASYNC
namespace SunamoWpf.Controls.Collections;

public partial class RadioButtonsList : UserControl, IUserControl, IControlWithResultDebugWpf
{
    /// <summary>
    /// The dialog result.
    /// </summary>
    public bool? DialogResult
    {
        set
        {
            if (ChangeDialogResult != null)
            {
                ChangeDialogResult(value);
            }
        }
    }

    /// <summary>
    /// Gets the title.
    /// </summary>
    public string Title => string.Empty;
    /// <summary>
    /// The change dialog result.
    /// </summary>
    public event VoidBoolNullable ChangeDialogResult;

    /// <summary>
    /// Initializes a new instance of the radio buttons list class.
    /// </summary>
    public RadioButtonsList()
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
    }

    /// <summary>
    /// Must be ControlInitData[], not object[]
    /// 
    /// </summary>
    /// <param name="contents"></param>
    public void AddRadioButtons(bool addHandler, params ControlInitData[] contents)
    {
        foreach (var content in contents)
        {
            if (addHandler)
            {
                content.OnClick = RbClicked;
            }
            AddRadioButton(content);
        }
    }

    /// <summary>
    /// Add radio button.
    /// </summary>
    /// <param name="controlInitData">The control init data.</param>
    public void AddRadioButton(ControlInitData controlInitData)
    {
        spRbs.Children.Add(RadioButtonHelper.Get(controlInitData));
    }

    /// <summary>
    /// The clicked tag.
    /// </summary>
    public object clickedTag = null;

    /// <summary>
    /// Rb clicked.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="eventArgs">The event args.</param>
    public void RbClicked(object sender, RoutedEventArgs eventArgs)
    {
        var radioButton = (RadioButton)sender;
        clickedTag = radioButton.Tag;
        ChangeDialogResult(true);
    }


    /// <summary>
    /// A1 should be always true
    /// </summary>
    /// <param name="addHandlers"></param>
    /// <param name="all"></param>
    public void Init(bool addHandlers, List<string> all)
    {
        foreach (var item in all)
        {
            var initData = new ControlInitData { content = item, tag = item, group = "g" };
            if (addHandlers)
            {
                initData.OnClick = RbClicked;
            }

            AddRadioButton(initData);
        }
    }

    /// <summary>
    /// Count of handlers change dialog result.
    /// </summary>
    /// <returns>The count of handlers change dialog result result.</returns>
    public int CountOfHandlersChangeDialogResult()
    {
        return RuntimeHelper.GetInvocationList(ChangeDialogResult).Count;
    }

    /// <summary>
    /// Attach change dialog result.
    /// </summary>
    /// <param name="handler">The handler.</param>
    /// <param name="throwException">The throw exception.</param>
    public void AttachChangeDialogResult(VoidBoolNullable handler, bool throwException = true)
    {
        RuntimeHelper.AttachChangeDialogResult(this, handler, throwException);
    }

    /// <summary>
    /// Accept.
    /// </summary>
    /// <param name="input">The input.</param>
    public void Accept(object input)
    {

    }

    /// <summary>
    /// Focus on main element.
    /// </summary>
    public void FocusOnMainElement()
    {

    }

    /// <summary>
    /// Init.
    /// </summary>
    public void Init()
    {
    }
}
