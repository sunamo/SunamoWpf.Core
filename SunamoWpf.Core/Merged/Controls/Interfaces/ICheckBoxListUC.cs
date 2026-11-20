#define ASYNC
namespace SunamoWpf.Controls.Interfaces;

/// <summary>
/// Represents the i check box list UC type.
/// </summary>
public interface ICheckBoxListUC
{
    /// <summary>
    /// Gets the lb.
    /// </summary>
    ListBox lb { get; }
    /// <summary>
    /// Gets the count.
    /// </summary>
    int Count { get; }
    /// <summary>
    /// Gets or sets the dialog result.
    /// </summary>
    bool? DialogResult { set; }
    /// <summary>
    /// Gets or sets the l.
    /// </summary>
    NotifyChangesCollection<NotifyPropertyChangedWrapper<CheckBox>> l { get; set; }
    /// <summary>
    /// Gets the title.
    /// </summary>
    string Title { get; }
    /// <summary>
    /// The change dialog result.
    /// </summary>
    event VoidBoolNullable ChangeDialogResult;
    /// <summary>
    /// The collection changed.
    /// </summary>
    event Action<object, ListOperation, object> CollectionChanged;
    /// <summary>
    /// Accept.
    /// </summary>
    /// <param name="input">The input.</param>
    void Accept(object input);
    /// <summary>
    /// Add checkbox.
    /// </summary>
    /// <param name="wrapper">The wrapper.</param>
    void AddCheckbox(NotifyPropertyChangedWrapper<CheckBox> wrapper);
    /// <summary>
    /// All content.
    /// </summary>
    /// <returns>The all content result.</returns>
    List<StackPanel> AllContent();
    /// <summary>
    /// All content dict.
    /// </summary>
    /// <returns>The all content dict result.</returns>
    Dictionary<StackPanel, bool> AllContentDict();
    /// <summary>
    /// All content string.
    /// </summary>
    /// <returns>The all content string result.</returns>
    List<string> AllContentString();
    /// <summary>
    /// Attach change dialog result.
    /// </summary>
    /// <param name="handler">The handler.</param>
    /// <param name="throwException">The throw exception.</param>
    void AttachChangeDialogResult(VoidBoolNullable handler, bool throwException = true);
    /// <summary>
    /// Checked content.
    /// </summary>
    /// <returns>The checked content result.</returns>
    IList<StackPanel> CheckedContent();
    /// <summary>
    /// Checked indexes.
    /// </summary>
    /// <returns>The checked indexes result.</returns>
    IList<int> CheckedIndexes();
    /// <summary>
    /// Checked strings.
    /// </summary>
    /// <returns>The checked strings result.</returns>
    List<string> CheckedStrings();
    /// <summary>
    /// Clear.
    /// </summary>
    void Clear();
    /// <summary>
    /// Col buttons added.
    /// </summary>
    /// <param name="text">The text.</param>
    void ColButtons_Added(string text);
    /// <summary>
    /// Count of handlers change dialog result.
    /// </summary>
    /// <returns>The count of handlers change dialog result result.</returns>
    int CountOfHandlersChangeDialogResult();
    /// <summary>
    /// Default buttons init.
    /// </summary>
    void DefaultButtonsInit();
    /// <summary>
    /// Event on.
    /// </summary>
    /// <param name="eventOnArgs">The event on args.</param>
    void EventOn(EventOnArgs eventOnArgs);
    /// <summary>
    /// Focus on main element.
    /// </summary>
    void FocusOnMainElement();
    /// <summary>
    /// Handle key.
    /// </summary>
    /// <param name="eventArgs">The event args.</param>
    /// <returns>The handle key result.</returns>
    bool HandleKey(KeyEventArgs eventArgs);
    /// <summary>
    /// Hide all buttons.
    /// </summary>
    void HideAllButtons();
    /// <summary>
    /// Init.
    /// </summary>
    void Init();
    /// <summary>
    /// Init.
    /// </summary>
    /// <param name="imageButtonsInit">The image buttons init.</param>
    /// <param name="list">The list.</param>
    /// <param name="eventOnArgs">The event on args.</param>
    /// <param name="defChecked">The def checked.</param>
    void Init(ImageButtonsInit imageButtonsInit, IList<string> list = null, EventOnArgs eventOnArgs = null, bool defChecked = false);
    /// <summary>
    /// Initialize component.
    /// </summary>
    void InitializeComponent();
    /// <summary>
    /// On size changed.
    /// </summary>
    /// <param name="size">The size.</param>
    void OnSizeChanged(DesktopSize size);
    /// <summary>
    /// Uc loaded.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="eventArgs">The event args.</param>
    void uc_Loaded(object sender, RoutedEventArgs eventArgs);
    /// <summary>
    /// Gets or sets the tag.
    /// </summary>
    object Tag { get; set; }
}