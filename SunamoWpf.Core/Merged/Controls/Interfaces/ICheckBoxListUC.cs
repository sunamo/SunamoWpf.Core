#define ASYNC
namespace SunamoWpf.Controls.Interfaces;

public interface ICheckBoxListUC
{
    ListBox lb { get; }
    int Count { get; }
    bool? DialogResult { set; }
    NotifyChangesCollection<NotifyPropertyChangedWrapper<CheckBox>> l { get; set; }
    string Title { get; }
    event VoidBoolNullable ChangeDialogResult;
    event Action<object, ListOperation, object> CollectionChanged;
    void Accept(object input);
    void AddCheckbox(NotifyPropertyChangedWrapper<CheckBox> wrapper);
    List<StackPanel> AllContent();
    Dictionary<StackPanel, bool> AllContentDict();
    List<string> AllContentString();
    void AttachChangeDialogResult(VoidBoolNullable handler, bool throwException = true);
    IList<StackPanel> CheckedContent();
    IList<int> CheckedIndexes();
    List<string> CheckedStrings();
    void Clear();
    void ColButtons_Added(string text);
    int CountOfHandlersChangeDialogResult();
    void DefaultButtonsInit();
    void EventOn(EventOnArgs eventOnArgs);
    void FocusOnMainElement();
    bool HandleKey(KeyEventArgs eventArgs);
    void HideAllButtons();
    void Init();
    void Init(ImageButtonsInit imageButtonsInit, IList<string> list = null, EventOnArgs eventOnArgs = null, bool defChecked = false);
    void InitializeComponent();
    void OnSizeChanged(DesktopSize size);
    void uc_Loaded(object sender, RoutedEventArgs eventArgs);
    object Tag { get; set; }
}