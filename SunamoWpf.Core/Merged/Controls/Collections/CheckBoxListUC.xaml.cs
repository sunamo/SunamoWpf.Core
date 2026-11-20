#define ASYNC

namespace SunamoWpf.Controls.Collections;
public partial class CheckBoxListUC : UserControl
        , IControlWithResultDebugWpf, IUserControlWithSizeChange, IUserControl, IKeysHandler, ICheckBoxListUC
    {

        /// <summary>
        /// The type.
        /// </summary>
        public static Type type = typeof(CheckBoxListUC);
        #region IControlWithResult implementation
        /// <summary>
        /// The dialog result.
        /// </summary>
        public bool? DialogResult
        {
            set
            {
                // because ChangeDialogResult is nowhere use and is set in CheckedIndexes, check for null
                if (ChangeDialogResult != null)
                {
                    ChangeDialogResult(value);
                }
            }
        }

        /// <summary>
        /// Gets the title.
        /// </summary>
        public string Title => "Check box list";

        /// <summary>
        /// Accept.
        /// </summary>
        /// <param name="input">The input.</param>
        public void Accept(object input)
        {

        }

        /// <summary>
        /// For now is usage nowhere
        /// </summary>
        public event VoidBoolNullable ChangeDialogResult;
        #endregion

        /// <summary>
        /// Gets the count.
        /// </summary>
        public int Count => lb2.Items.Count;

        /// <summary>
        /// Focus on main element.
        /// </summary>
        public void FocusOnMainElement()
        {

        }

        /// <summary>
        /// Args are: object sender, string operation, object data
        /// </summary>
        public event Action<object, ListOperation, object> CollectionChanged;
        /// <summary>
        /// Gets or sets the l.
        /// </summary>
        public NotifyChangesCollection<NotifyPropertyChangedWrapper<CheckBox>> l { get; set; } = null;
        /// <summary>
        /// Whether have raise CollectionChanged after check
        /// </summary>

        public bool initialized = false;

        EventOnArgs eoa = null;

        bool eventOn = false;

        /// <summary>
        /// Must be called after Init
        /// </summary>
        /// <param name="e"></param>
        public void EventOn(EventOnArgs eoa)
        {
            if (!eventOn)
            {
                eventOn = true;
                if (eoa != null)
                {
                    this.eoa = eoa;
                }
                l.EventOn(eoa);

                if (list != null)
                {
                    foreach (var item in list)
                    {
                        AddCheckbox(item, defChecked);
                    }
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the check box list UC class.
        /// </summary>
        public CheckBoxListUC()
        {
            InitializeComponent();

            Loaded += uc_Loaded;
        }

        /// <summary>
        /// Clear.
        /// </summary>
        public void Clear()
        {
            l.l.Clear();
            lb.ItemsSource = l.l;
        }

        IList<string> list = null;
        bool defChecked = false;
        ImageButtonsInit imageButtonsInit = null;

        /// <summary>
        /// A2 can be null
        /// Into A1.add can be CheckBoxListUC.ColButtons_Added
        /// A1 can be null but then is needed to call () which contains Buttons in name like DefaultButtonsInit,HideAllButtons, etc.
        /// </summary>
        /// <param name="list"></param>
        public void Init(ImageButtonsInit imageButtonsInit, IList<string> list = null, EventOnArgs eoa = null, bool defChecked = false)
        {
            this.eoa = this.eoa;

            if (!initialized)
            {
                #region Přesunuto z loaded aby to bylo hotové již při Init a bylo k dispozici colButtons
                #region colButtons
                colButtons = ImageButtons.CreateWithBackgroundIcons();
                sp.Children.Add(colButtons);

                colButtons.MaxHeight = 16 + 2 * 10;

                if (imageButtonsInit != null)
                {
                    colButtons.Init(imageButtonsInit);
                }
                else
                {
                    colButtons.Init(new ImageButtonsInit { });
                }

                colButtons.SelectAll += ColButtons_SelectAll;
                colButtons.UnselectAll += ColButtons_UnselectAll;
                #endregion

                if (initAfterLoaded != null)
                {
                    initAfterLoaded();
                }

                searchTextBox.TextChanged += SearchTextBox_TextChanged;
                #endregion

                this.imageButtonsInit = imageButtonsInit;

                initialized = true;

                l = new NotifyChangesCollection<NotifyPropertyChangedWrapper<CheckBox>>(this, new ObservableCollection<NotifyPropertyChangedWrapper<CheckBox>>());
                l.CollectionChanged += L_CollectionChanged;

                //var iso = NotifyPropertyHelper.InnerObjectsOfNotifyPropertyChangedWrapper<CheckBox>(l.l); ;
                lb2.ItemsSource = l.l;

                // zde je to zajímavé. Položky by se měli načítat z lb2.ItemsSource ale list vkládám do this.list = list;
                this.list = list;
                this.defChecked = defChecked;

                this.DataContext = this;

                SizeChanged += CheckBoxListUC_SizeChanged;
            }

            EventOn(eoa);
        }

        /// <summary>
        /// All content string.
        /// </summary>
        /// <returns>The all content string result.</returns>
        public List<string> AllContentString()
        {
            var allContent = AllContent();
            List<string> result = new List<string>();
            string text = null;

            foreach (var item in allContent)
            {
                //null; //
                //IList<TextBlock> textboxes = null;
                ////textboxes = VisualTreeHelpers.FindDescendents<TextBlock>(item);

                ////textboxes = item.Children.Where(i=>i);

                //var first = textboxes.First();
                //text = first.Text;

                text = ContentControlHelper.ExtractContent(item);

                result.Add(text);
            }

            return result;
        }

        /// <summary>
        /// Content of text block.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>The content of text block result.</returns>
        public static string ContentOfTextBlock(StackPanel key)
        {
            var value = WpfApp.cd;

            UIElementCollection children = PanelHelper.Children(key, value);
            object first = null;
            WpfApp.cd.Invoke(() =>
            {
                first = children.Count > 0 ? children[0] : null;
            }, WpfApp.cdp);
            var textBlock = first as TextBlock;

            IH.tb = textBlock;
            return value.Invoke<string>(IH.getTextOfTextBlock);
        }

        private void CheckBoxListUC_SizeChanged(object sender, SizeChangedEventArgs eventArgs)
        {
            // Cant be, otherwise set wrong size into checkbox and button will be out of window
            //OnSizeChanged(new DesktopSize( e.NewSize.Width, e.NewSize.Height));

        }

        /// <summary>
        /// visible: add, selectAll, deselectAll
        /// </summary>
        public void DefaultButtonsInit()
        {
            colButtons.Init(new ImageButtonsInit(false, false, new VoidString(ColButtons_Added), true, true));
        }

        /// <summary>
        /// Hide all buttons.
        /// </summary>
        public void HideAllButtons()
        {
            colButtons.Init(ImageButtonsInit.HideAllButtons);
        }

        /// <summary>
        /// Args are: object sender, string operation, object data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="operation"></param>
        /// <param name="data"></param>
        private void L_CollectionChanged(object sender, ListOperation operation, object data)
        {
            if (CollectionChanged != null)
            {
                CollectionChanged(sender, operation, data);
            }
            DialogResult = CheckedIndexes().Count() > 0;
        }

        private void ColButtons_UnselectAll()
        {
            SelectAll(false);
        }

        private void ColButtons_SelectAll()
        {
            SelectAll(true);
        }

        void SelectAll(bool select)
        {
            foreach (var item in l.l)
            {
                item.o.IsChecked = select;
            }
        }

        private void NotifyWrapper_PropertyChanged(CheckBox obj)
        {

        }

        #region AddCheckbox - everything is private, wiht object input, bool defChecked is even important in that. It must be added to underlying NotifyChangesCollection<NotifyPropertyChangedWrapper<CheckBox>> l and l.l set as ItemsSource
        /// <summary>
        ///
        /// </summary>
        /// <param name="input"></param>
        /// <param name="defChecked"></param>
        /// <returns></returns>
        private NotifyPropertyChangedWrapper<CheckBox> AddCheckbox(object input, bool defChecked)
        {
            var lines = SHGetLines.GetLines(input.ToString());
            NotifyPropertyChangedWrapper<CheckBox> notifyWrapper = null;

            foreach (var item in lines)
            {
                var contents = l.Select(checkBoxItem => checkBoxItem.o.Content);
                var contents2 = new List<string>(contents.Count());

                StackPanel stackPanel = null;

                foreach (var item2 in contents)
                {
                    stackPanel = (StackPanel)item2;
                    contents2.Add(CheckBoxListUC.ContentOfTextBlock(stackPanel));
                }

                if (contents2.Contains(item))
                {
                    continue;
                }

                var chb = CheckBoxHelper.Get(new ControlInitData { text = item });

                notifyWrapper = new NotifyPropertyChangedWrapper<CheckBox>(chb, FrameworkElement.VisibilityProperty);
                NotifyPropertyHelper.CheckBox(notifyWrapper);

                notifyWrapper.o.IsChecked = defChecked;
                AddCheckbox(notifyWrapper);
            }
            return notifyWrapper;
        }


        /// <summary>
        /// Add checkbox.
        /// </summary>
        /// <param name="wrapper">The wrapper.</param>
        public void AddCheckbox(NotifyPropertyChangedWrapper<CheckBox> wrapper)
        {
            var chb = wrapper.o;

            // Must handling Checked / Unchecked, otherwise won't working dialogbuttons and cant exit dialog
            chb.Checked += CheckBox_Checked;
            chb.Unchecked += CheckBox_Unchecked;
            l.Add(wrapper);
        }
        #endregion

        int dexLastChecked = -1;

        /// <summary>
        /// Col buttons added.
        /// </summary>
        /// <param name="text">The text.</param>
        public void ColButtons_Added(string text)
        {
            AddCheckbox(text, true);
        }

        /// <summary>
        /// Checked indexes.
        /// </summary>
        /// <returns>The checked indexes result.</returns>
        public IList<int> CheckedIndexes()
        {
            var innerObjects = NotifyPropertyHelper.InnerObjectsOfNotifyPropertyChangedWrapper<CheckBox>(l.l);
            return CheckBoxListHelper.CheckedIndexes(innerObjects);
        }

        /// <summary>
        /// Apply method CheckBoxListUC.ContentOfTextBlock if it!s possible (lower hardware consumptation)
        /// </summary>
        public IList<StackPanel> CheckedContent()
        {
            var innerObjects = NotifyPropertyHelper.InnerObjectsOfNotifyPropertyChangedWrapper<CheckBox>(l.l);
            return CheckBoxListHelper.CheckedContent(innerObjects);
        }

        /// <summary>
        /// Checked strings.
        /// </summary>
        /// <returns>The checked strings result.</returns>
        public List<string> CheckedStrings()
        {
            var innerObjects = NotifyPropertyHelper.InnerObjectsOfNotifyPropertyChangedWrapper<CheckBox>(l.l);
            return CheckBoxListHelper.CheckedStrings(innerObjects);
        }

        /// <summary>
        /// All content dict.
        /// </summary>
        /// <returns>The all content dict result.</returns>
        public Dictionary<StackPanel, bool> AllContentDict()
        {
            var innerObjects = NotifyPropertyHelper.InnerObjectsOfNotifyPropertyChangedWrapper<CheckBox>(l.l);
            return CheckBoxListHelper.CheckedContentDict(innerObjects);
        }

        //public void CheckBox_Click(object sender, RoutedEventArgs e, Checkboxes chb2)
        //{
        //    if (Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift))
        //    {
        //        var chb = (CheckBox)sender;
        //        var lastId2 = BTS.ParseInt(chb.Tag.ToString());
        //        GridView2_MultiCheck(lastId, lastId2, chb2);
        //    }
        //    else
        //    {
        //        var chb = (CheckBox)sender;
        //        lastId = BTS.ParseInt(chb.Tag.ToString());
        //    }
        //}

        //public void GridView2_MultiCheck(int arg1, int arg2, Checkboxes chb2)
        //{
        //    var p = NH.Sort<int>(arg1, arg2);
        //    p[1]++;
        //    // is already checked actully, so i dont negate
        //    var col = ((ObservableCollection<T>)lstViewXamlColumnNames.ItemsSource);
        //    var first = col.First(d => d.Id == arg1);

        //    bool setUp = false;
        //    switch (chb2)
        //    {
        //        case Checkboxes.IsChecked:
        //            setUp = first.IsChecked;
        //            break;
        //        case Checkboxes.IsSelected:
        //            setUp = first.IsSelected;
        //            break;
        //        default:
        //            ThrowEx.NotImplementedCase();
        //            break;
        //    }

        //    for (int i = p[0]; i < p[1]; i++)
        //    {
        //        first = col.FirstOrDefault(d => d.Id == i);
        //        if (!EqualityComparer<T>.Default.Equals(default(T), first))
        //        {
        //            switch (chb2)
        //            {
        //                case Checkboxes.IsChecked:
        //                    first.IsChecked = setUp;
        //                    break;
        //                case Checkboxes.IsSelected:
        //                    first.IsSelected = setUp;
        //                    break;
        //                default:
        //                    break;
        //            }

        //        }

        //    }
        //}

        private void CheckBox_Checked(object sender, RoutedEventArgs eventArgs)
        {
            MultiCheck(sender);
            s(sender, true);

            if (eoa.onCheck)
            {
                l.OnCollectionChanged(ListOperation.Checked, sender);
            }
        }

        private void MultiCheck(object sender)
        {
            var UIElement = (CheckBox)sender;

            var actChecked = lb2.Items.IndexOf(UIElement);

            if (actChecked == -1)
            {
                var sp2 = (StackPanel)UIElement.Content;
                var text = ContentControlHelper.ExtractContent(sp2);
                int index = 0;

                foreach (var item in lb2.Items)
                {
                    var chb2 = (NotifyPropertyChangedWrapper<CheckBox>)item;
                    var stackPanel = (StackPanel)chb2.o.Content;
                    var contentText = ContentControlHelper.ExtractContent(stackPanel);

                    if (contentText != string.Empty)
                    {

                    }

                    if (text != string.Empty)
                    {

                    }

                    if (contentText == text)
                    {
                        actChecked = index;
                        break;
                    }
                    index++;
                }
            }

            if (actChecked != -1)
            {
                if (KeyboardHelper.IsModifier(Key.LeftShift))
                {
                    if (dexLastChecked != -1)
                    {
                        var sorted = NH.Sort<int>(actChecked, dexLastChecked);
                        sorted[1]++;

                        for (int checkIndex = sorted[0]; checkIndex < sorted[1]; checkIndex++)
                        {
                            var ich2 = l[checkIndex].o.GetValue(CheckBox.IsCheckedProperty);

                            l[checkIndex].o.IsChecked = UIElement.IsChecked;

                            var ich = l[checkIndex].o.GetValue(CheckBox.IsCheckedProperty);
                            int count = 0;
                        }
                    }
                }

                dexLastChecked = actChecked;
            }
        }

        /// <summary>
        /// All content.
        /// </summary>
        /// <returns>The all content result.</returns>
        public List<StackPanel> AllContent()
        {
            var innerObjects = NotifyPropertyHelper.InnerObjectsOfNotifyPropertyChangedWrapper<CheckBox>(l.l);
            return CheckBoxListHelper.AllContent(innerObjects);
        }

        /// <summary>
        /// Save IsChecked to elements in chbAdded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="value"></param>
        private void s(object sender, bool value)
        {
            var element = ((FrameworkElement)sender);
            var name = element.Tag;

            if (Tag != null)
            {
                if (RH.IsOrIsDeriveFromBaseClass(Tag.GetType(), typeof(FrameworkElementTag)))
                {
                    var frameworkElementTag = (FrameworkElementTag)Tag;
                    frameworkElementTag.tagCheckBoxListUC = sender;
                }
                else
                {
                    FrameworkElementTag tag = new FrameworkElementTag();
                    tag.tagCheckBoxListUC = sender;
                    tag.Tag = Tag;
                    Tag = tag;
                }
            }
            else
            {
                Tag = sender;
            }

            var where = l.Where(checkBoxWrapper => checkBoxWrapper.o.Tag == element.Tag);

            foreach (var item in where)
            {
                // Uložím do
                item.o.IsChecked = value;
            }
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs eventArgs)
        {
            MultiCheck(sender);
            s(sender, false);
            if (eoa.onUnCheck)
            {
                l.OnCollectionChanged(ListOperation.Unchecked, sender);
            }
        }

        /// <summary>
        /// new DesktopSize( columnGrowing.ActualWidth, rowGrowing.ActualHeight)
        /// </summary>
        /// <param name="size"></param>
        public void OnSizeChanged(DesktopSize size)
        {
            if (Visibility != Visibility.Collapsed)
            {
                var firstButton = colButtons.HeightOfFirstVisibleButton();
                var height = size.Height - firstButton;
                if (height >= 0)
                {
                    //r0.Height = new GridLength(h);
                    lb2.Height = lb2.MaxHeight = lb2.MinHeight = height;
                    //lb.InvalidateVisual();
                    //lb.Invali

                    lb2.UpdateLayout();

                    ////////////DebugLogger.Instance.WriteArgs("Height", h, "First button", firstButton, "sp", colButtons.sp.ActualHeight, "colButtons", colButtons.ActualHeight);

                    Debug.WriteLine(string.Join(" , ", height, lb2.ActualHeight.ToString(), lb2.Height));
                }
            }
        }

        /// <summary>
        /// Gets the tag.
        /// </summary>
        public new object Tag { get => base.Tag; set => base.Tag = value; }

        /// <summary>
        /// Gets the lb.
        /// </summary>
        public ListBox lb { get => lb2; }

        /// <summary>
        /// THEN MUST BE CALLED HideAllButtons(), DefaultButtons() atd.
        /// </summary>
        /// <param name="i"></param>
        public void Init()
        {
            Init(null, null, EventOnArgs.allFalseOnlyCheckOn, false);
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
        /// The col buttons.
        /// </summary>
        public ImageButtons colButtons = null;

        /// <summary>
        /// Uc loaded.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="eventArgs">The event args.</param>
        public void uc_Loaded(object sender, RoutedEventArgs eventArgs)
        {
            // Is also in ctor
            if (initAfterLoaded != null)
            {
                initAfterLoaded();
            }
        }

        /// <summary>
        /// Filters the list by the text typed into the search box.
        /// </summary>
        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs eventArgs)
        {
            DoSearch(searchTextBox.Text);
        }

        private void DoSearch(string text)
        {
            /*
Here its is not possible with set up visibility
             * */

            if (text.Trim() == string.Empty)
            {
                foreach (var item in l)
                {
                    item.IsActive = true;
                }
            }
            else
            {
                foreach (var item in l)
                {
                    var wrapper = item.o;
                    var stackPanel = (StackPanel)wrapper.Content;
                    var contentText = CheckBoxListUC.ContentOfTextBlock(stackPanel);

                    if (contentText.Contains(text))
                    {
                        item.IsActive = true;
                    }
                    else
                    {
                        //o.Visibility = Visibility.Collapsed;
                        //sp.Visibility = Visibility.Collapsed;
                        item.IsActive = false;
                    }
                }
            }

            //lb.UpdateLayout();
        }

        /// <summary>
        /// Handle key.
        /// </summary>
        /// <param name="eventArgs">The event args.</param>
        /// <returns>The handle key result.</returns>
        public bool HandleKey(KeyEventArgs eventArgs)
        {
            return false;
        }

        Action initAfterLoaded = null;

        /// <summary>
        /// Set init after loaded.
        /// </summary>
        /// <param name="action">The action.</param>
        public void SetInitAfterLoaded(Action action)
        {
            initAfterLoaded = action;
        }
    }
