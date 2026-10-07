#define ASYNC
namespace SunamoWpf.Controls.Collections;

    public partial class CompareInCheckBoxListUC : UserControl, IUserControl, IControlWithResultWpf, IUserControlWithSuMenuItemsList, IUserControlWithSizeChange, ICompareInCheckBoxListUC
    {
        List<CheckBoxListUC> chbls = null;

        public CompareInCheckBoxListUC()
        {
            InitializeComponent();

            Loaded += uc_Loaded;
        }

        public void FocusOnMainElement()
        {

        }
        public void RemoveWhichHaveNoItem() { }
        private void CompareInCheckBoxListUC_SizeChanged(object sender, SizeChangedEventArgs eventArgs)
        {
            foreach (CheckBoxListUC item in chbls)
            {
                if (item.ActualHeight == 0)
                {
                    continue;
                }
                //var size = item.ActualHeight;
                var listBox = item.lb;
                listBox.Height = listBox.MaxHeight = listBox.MinHeight = item.ActualHeight - r0.ActualHeight;
                listBox.UpdateLayout();

            }
            //r1.Height. = this.ActualHeight - r0.ActualHeight;
        }

        public bool? DialogResult { set => ChangeDialogResult(value); }

        public string Title => "Decide which to process";

        public event VoidBoolNullable ChangeDialogResult;

        public void Accept(object input)
        {

        }

        string autoYes, manuallyYes, manuallyNo, autoNo = null;

        /// <summary>
        /// Only check
        /// </summary>
        /// <param name="o"></param>
        private void ChblAutoNo_CollectionChanged(object sender, ListOperation operation, object data)
        {
            MoveCheckBox(sender, chblAutoNo, chblManuallyYes);
        }

        /// <summary>
        /// Only check
        /// </summary>
        private void ChblManuallyNo_CollectionChanged(object sender, ListOperation operation, object data)
        {
            MoveCheckBox(sender, chblManuallyNo, chblManuallyYes);
        }

        /// <summary>
        /// Only uncheck
        /// </summary>
        private void ChblManuallyYes_CollectionChanged(object sender, ListOperation operation, object data)
        {
            MoveCheckBox(sender, chblManuallyYes, chblManuallyNo);
        }

        /// <summary>
        /// Only uncheck
        /// </summary>
        /// <param name="o"></param>
        private void ChblAutoYes_CollectionChanged(object sender, ListOperation operation, object data)
        {
            MoveCheckBox(sender, chblAutoYes, chblManuallyNo);
        }

        int moved = 0;

        private void MoveCheckBox(object sender, CheckBoxListUC from, CheckBoxListUC target)
        {
            moved++;

            var fromName = from.Name;
            var toName = target.Name;

            var wrapper = ch(sender);
            var con = wrapper.o.Content;
            for (int index = from.l.l.Count - 1; index >= 0; index--)
            {
                if (from.l.l[index].o.Tag == wrapper.o.Tag)
                {
                    from.l.l.RemoveAt(index);
                    break;
                }
            }

            //from.l.l.Remove(c);

            wrapper.o.Content = con;
            // Tag is transfer OK
            //var tag = c.Tag;

            // Switch of IsChecked will be perfomed after click
            target.l.l.Add(wrapper);


            if (moved % 5 == 0)
            {
                Save(null, null);
            }
        }

        NotifyPropertyChangedWrapper<CheckBox> ch(object sender)
        {
            var casted = (CheckBoxListUC)sender;
            var chb = (NotifyPropertyChangedWrapper<CheckBox>)casted.Tag;

            // Debugger because I have changed from CheckBox to NotifyPropertyChangedWrapper< CheckBox>
            Debugger.Break();

            return chb;
        }


        private void Save(object sender, RoutedEventArgs eventArgs)
        {
            TF.WriteAllLines(autoYes, chblAutoYes.AllContentString());
            TF.WriteAllLines(manuallyYes, chblManuallyYes.AllContentString());
            TF.WriteAllLines(manuallyNo, chblManuallyNo.AllContentString());
            TF.WriteAllLines(autoNo, chblAutoNo.AllContentString());
        }


        public List<string> ExcludeToProcess()
        {
            List<string> resultNo = new List<string>(chblManuallyNo.Count + chblManuallyYes.Count);
            return resultNo;
        }

        public List<string> IncludeToProcess()
        {
            List<string> result = new List<string>(chblManuallyYes.Count + chblAutoYes.Count);

            return result;
        }

        /// <summary>
        /// If I want save state to files, must be set up all four
        /// </summary>
        /// <param name="autoYes"></param>
        /// <param name="manuallyYes"></param>
        /// <param name="manuallyNo"></param>
        /// <param name="autoNo"></param>
        public
#if ASYNC
    async Task
#else
    void
#endif
 Init(string autoYes, string manuallyYes, string manuallyNo, string autoNo)
        {
            this.autoYes = autoYes;
            this.manuallyYes = manuallyYes;
            this.manuallyNo = manuallyNo;
            this.autoNo = autoNo;

            Init(
#if ASYNC
    await
#endif
 TF.ReadAllLines(autoYes),
#if ASYNC
    await
#endif
 TF.ReadAllLines(manuallyYes),
#if ASYNC
    await
#endif
 TF.ReadAllLines(manuallyNo),
#if ASYNC
    await
#endif
 TF.ReadAllLines(autoNo));
        }

        public void Init(IList<string> autoYes, IList<string> autoNo)
        {
            Init(autoYes, null, null, autoNo);
        }

        /// <summary>
        /// A1-4 can be null
        /// </summary>
        /// <param name="autoYes"></param>
        /// <param name="manuallyYes"></param>
        /// <param name="manuallyNo"></param>
        /// <param name="autoNo"></param>
        public void Init(IList<string> autoYes, IList<string> manuallyYes, IList<string> manuallyNo, IList<string> autoNo)
        {
            chbls = CAG.ToList<CheckBoxListUC>(chblAutoYes, chblManuallyYes, chblManuallyNo, chblAutoNo);

            foreach (var item in chbls)
            {
                item.HideAllButtons();
            }

            // First must call Init due to create instance of NotifyChangesCollection
            chblAutoYes.Init(null, autoYes, EventOnArgs.allFalseOnlyCheckOn, true);
            chblManuallyYes.Init(null, manuallyYes, EventOnArgs.allFalseOnlyCheckOn);
            chblManuallyNo.Init(null, manuallyNo, EventOnArgs.allFalseOnlyCheckOn);
            chblAutoNo.Init(null, autoNo, EventOnArgs.allFalseOnlyCheckOn, false);

            #region Must init before to avoid raise breakpoints
            chblAutoYes.EventOn(new EventOnArgs(false, true, false, false, false, false));
            chblManuallyYes.EventOn(new EventOnArgs(false, true, false, false, false, false));
            chblManuallyNo.EventOn(new EventOnArgs(true, false, false, false, false, false));
            chblAutoNo.EventOn(new EventOnArgs(true, false, false, false, false, false));
            #endregion

            chblAutoYes.DefaultButtonsInit();
            chblManuallyYes.HideAllButtons();
            chblManuallyNo.HideAllButtons();
            chblAutoNo.HideAllButtons();

            chblAutoYes.CollectionChanged += ChblAutoYes_CollectionChanged;
            chblManuallyYes.CollectionChanged += ChblManuallyYes_CollectionChanged;
            chblManuallyNo.CollectionChanged += ChblManuallyNo_CollectionChanged;
            chblAutoNo.CollectionChanged += ChblAutoNo_CollectionChanged;

            SizeChanged += CompareInCheckBoxListUC_SizeChanged;

            CompareInCheckBoxListUC_SizeChanged(null, null);
        }

        /// <summary>
        /// Must be due to IUserControl
        /// </summary>
        public void Init()
        {

        }

        public List<SuMenuItem> SuMenuItems()
        {
            //SuMenuItem mi = SuMenuItemHelper.Get(Title);

            SuMenuItem miSave = SuMenuItemHelper.Get(new ControlInitData { text = "Save", OnClick = Save });
            //mi.Items.Add(miSave);

            return CAG.ToList<SuMenuItem>(miSave);
        }

        public void OnSizeChanged(DesktopSize maxSize)
        {
            chblAutoYes.OnSizeChanged(maxSize);
            chblManuallyYes.OnSizeChanged(maxSize);
            chblManuallyNo.OnSizeChanged(maxSize);
            chblAutoNo.OnSizeChanged(maxSize);
        }

        public void uc_Loaded(object sender, RoutedEventArgs eventArgs)
        {

        }
    }
