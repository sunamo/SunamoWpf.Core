#define ASYNC
namespace SunamoWpf.Controls.Collections;
public partial class Compare3InCheckBoxListUC : UserControl, IUserControl, IControlWithResultWpf, IUserControlWithSuMenuItemsList, IUserControlWithSizeChange
    {
        public List<CheckBoxListUC> chbls = null;

        public Compare3InCheckBoxListUC()
        {
            InitializeComponent();

            Loaded += uc_Loaded;
        }

        public void RemoveWhichHaveNoItem() { }

        public void FocusOnMainElement()
        {

        }

        private void Compare3InCheckBoxListUC_SizeChanged(object sender, SizeChangedEventArgs eventArgs)
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

        public void Init(List<string> left, List<string> right)
        {
            var both = left.Intersect(right).ToList();
            Init(left, right, both);
        }

        //Compare3InheckBoxListUCInit compare3InCheckBoxListUCInit = null;

        public void Init(string tbleft, string tbRight, string tbBoth, IList<string> left, IList<string> right, IList<string> both)
        {
            tblAutoYes.Text = tbleft;
            tblManuallyYes.Text = tbRight;
            tblManuallyNo.Text = tbBoth;

            Init(left, right, both);
        }

        /// <summary>
        /// A1-4 can be null
        /// Must be IList to avoid
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="both"></param>
        /// <param name="autoNo"></param>
        public void Init(IList<string> left, IList<string> right, IList<string> both)
        {
            //compare3InCheckBoxListUCInit = new Compare3InCheckBListUCInit();

            chbls = CAG.ToList<CheckBoxListUC>(chblAutoYes, chblManuallyYes, chblManuallyNo);

            foreach (var item in chbls)
            {
                item.HideAllButtons();
            }

            // First must call Init due to create instance of NotifyChangesCollection
            chblAutoYes.Init(null, left, EventOnArgs.allFalseOnlyCheckOn, false);
            chblManuallyYes.Init(null, right, EventOnArgs.allFalseOnlyCheckOn);
            chblManuallyNo.Init(null, both, EventOnArgs.allFalseOnlyCheckOn);


            #region Must init before to avoid raise breakpoints
            chblAutoYes.EventOn(new EventOnArgs(false, true, false, false, false, false));
            chblManuallyYes.EventOn(new EventOnArgs(false, true, false, false, false, false));
            chblManuallyNo.EventOn(new EventOnArgs(true, false, false, false, false, false));

            #endregion

            chblAutoYes.DefaultButtonsInit();
            chblManuallyYes.HideAllButtons();
            chblManuallyNo.HideAllButtons();


            chblAutoYes.CollectionChanged += ChblAutoYes_CollectionChanged;
            chblManuallyYes.CollectionChanged += ChblManuallyYes_CollectionChanged;
            chblManuallyNo.CollectionChanged += ChblManuallyNo_CollectionChanged;


            SizeChanged += Compare3InCheckBoxListUC_SizeChanged;

            Compare3InCheckBoxListUC_SizeChanged(null, null);
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


            //if (moved % 5 == 0)
            //{
            //    Save(null, null);
            //}
        }

        NotifyPropertyChangedWrapper<CheckBox> ch(object sender)
        {
            var casted = (CheckBoxListUC)sender;
            var chb = (NotifyPropertyChangedWrapper<CheckBox>)casted.Tag;

            // Debugger because I have changed from CheckBox to NotifyPropertyChangedWrapper< CheckBox>
            Debugger.Break();

            return chb;
        }

        /// <summary>
        /// Must be due to IUserControl
        /// </summary>
        public void Init()
        {

        }

#if ASYNC
        async Task
#else
        void
#endif
         SaveToDrive(object sender, RoutedEventArgs eventArgs)
        {
            var autoYes = chblAutoYes.AllContentString();
            var manuallyNo = chblManuallyNo.AllContentString();
            var manuallyYes = chblManuallyYes.AllContentString();

            var tog = new StringBuilder();

            foreach (var (title, items) in new[] { (tblAutoYes.Text, autoYes), (tblManuallyNo.Text, manuallyNo), (tblManuallyYes.Text, manuallyYes) })
            {
                tog.AppendLine(title);
                foreach (var item in items)
                {
                    tog.AppendLine(item);
                }
                tog.AppendLine();
            }

            var folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Sunamo", "Output");
            Directory.CreateDirectory(folder);
            var file = Path.Combine(folder, nameof(Compare3InCheckBoxListUC) + ".txt");

#if ASYNC
            await
#endif
            TF.WriteAllText(file, tog.ToString());
            Process.Start(new ProcessStartInfo(file) { UseShellExecute = true });
        }

        public List<SuMenuItem> SuMenuItems()
        {
            SuMenuItem menuItem = SuMenuItemHelper.Get(new ControlInitData { content = "Save to drive", OnClickAsync = SaveToDrive });

            //SuMenuItem miSave = SuMenuItemHelper.Get(new ControlInitData { text = "Save", OnClick = Save });
            //mi.Items.Add(miSave);

            return CAG.ToList<SuMenuItem>();
        }

        public void OnSizeChanged(DesktopSize maxSize)
        {
            chblAutoYes.OnSizeChanged(maxSize);
            chblManuallyYes.OnSizeChanged(maxSize);
            chblManuallyNo.OnSizeChanged(maxSize);

        }

        public void uc_Loaded(object sender, RoutedEventArgs eventArgs)
        {

        }
    }
