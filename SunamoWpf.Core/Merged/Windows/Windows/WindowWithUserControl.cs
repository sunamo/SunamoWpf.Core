#define ASYNC
namespace SunamoWpf.Windows;

/// <summary>
/// With this is allowed use logging via ThisApp (has own statusbar)
/// </summary>
public class WindowWithUserControl : Window//, IControlWithResult, IUserControlWithSizeChange
{
    #region Rewrite to pure cs. With xaml is often problems without building
    UserControl userControl = null;
    DockPanel dock = null;
    IUserControl uc = null;
    IControlWithResultWpf userControlWithResult = null;
    IControlWithResultDebugWpf controlWithResultDebug = null;
    bool isControlWithResultDebug = false;
    IControlWithResultWpf controlWithResult = null;
    /// <summary>
    /// Na false se nastaví při zavírání. Pokud tedy bude false, znamená to že okno se zavřelo křížkem a má tato hodnota false přednost
    /// </summary>
    public bool? dialogResult = null;
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
    WindowWithUserControlArgs args = null;
    IUserControlWithSizeChange userControlWithSizeChange = null;
    static Type type = typeof(WindowWithUserControl);
    StatusBar statusBar = null;
    public DialogButtons dialogButtons = null;
    Menu menu = null;
    private void WindowWithUserControl_SizeChanged(object sender, SizeChangedEventArgs eventArgs)
    {
        var hMenu = menu.ActualHeight;
        var staturBarH = statusBar.ActualHeight;
        double dialogButtonsH = 0;
        if (dialogButtons != null)
        {
            dialogButtonsH = dialogButtons.ActualHeight;
        }
        var height = ControlHelper.ActualInnerSize(this).Height;
        var growingRow = height - hMenu - staturBarH - dialogButtonsH;
        if (args.showInTitleSizeOfWindowAndContent)
        {
            var content = (FrameworkElement)Content;
            WindowHelper.SizeOfWindowToTitle(this, growingRow, content);
        }
        OnSizeChanged(new DesktopSize(ActualWidth, growingRow));
    }
    private double ah(FrameworkElement dialogButtons)
    {
        return dialogButtons.ActualHeight();
    }
    /// <summary>
    /// A3 addDialogButtons only when uc dont have own button!
    /// </summary>
    /// <param name="iUserControlInWindow"></param>
    /// <param name="resizeMode"></param>
    /// <param name="addDialogButtons"></param>
    /// <param name="tag"></param>
    public WindowWithUserControl(object iUserControlInWindow, ResizeMode resizeMode, bool addDialogButtons = false, string tag = null) : this(new WindowWithUserControlArgs { iUserControlInWindow = iUserControlInWindow, addDialogButtons = addDialogButtons, tag = tag, rm = resizeMode })
    { }
    /// <summary>
    /// A1 can be IControlWithResult, if have own buttons for accepting
    /// A1.addDialogButtons only when uc dont have own button!
    /// </summary>
    /// <param name="iUserControlInWindow"></param>
    /// <param name="rm"></param>
    /// <param name="addDialogButtons"></param>
    public WindowWithUserControl(WindowWithUserControlArgs args2)
    {
        Tag = args2.tag;
        userControl = (UserControl)args2.iUserControlInWindow;
        this.uc = userControl as IUserControl;
        controlWithResultDebug = uc as IControlWithResultDebugWpf;
        userControlWithSizeChange = uc as IUserControlWithSizeChange;
        controlWithResult = uc as IControlWithResultWpf;
        this.Closed += WindowWithUserControl_Closed;
        this.Closing += WindowWithUserControl_Closing;
        args = args2;
        dock = new DockPanel();
        dock.LastChildFill = true;
        menu = new Menu();
        DockPanel.SetDock(menu, Dock.Top);
        dock.Children.Add(menu);
        var textBlock = TextBlockHelper.Get(new ControlInitData { text = Translate.FromKey(XlfKeys.EnterForFastClosing) });
        DockPanel.SetDock(textBlock, Dock.Top);
        dock.Children.Add(textBlock);
        if (uc is IUserControlWithSuMenuItemsList)
        {
            IUserControlWithSuMenuItemsList userControlWithSuMenuItemsList = (IUserControlWithSuMenuItemsList)uc;
            var miUc = SunamoWpf.Controls.Helpers.ControlsWithGet.SuMenuItemHelper.Get(new ControlInitData { text = userControlWithSuMenuItemsList.Title });
            foreach (var item in userControlWithSuMenuItemsList.SuMenuItems())
            {
                miUc.Items.Add(item);
            }
            miUc.UpdateLayout();
            menu.Items.Add(miUc);
        }
        isControlWithResultDebug = controlWithResultDebug != null;
        if (controlWithResult != null)
        {
            controlWithResult.ChangeDialogResult += ControlWithResult_ChangeDialogResult;
        }
        statusBar = new StatusBar();
        statusBar.Height = 25;
        // Stupid - I have to save reference to control, because contains data
        //DialogButtons dialogButtons = new DialogButtons();
        //DockPanel.SetDock(dialogButtons, Dock.Bottom);
        //dialogButtons.ChangeDialogResult += DialogButtons_ChangeDialogResult;
        //dock.Children.Add(dialogButtons);
        TextBlock textBlockStatus = TextBlockHelper.Get(new ControlInitData { text = "" });
        WpfApp.SaveReferenceToTextBlockStatus(false, textBlockStatus, textBlockStatus);
        statusBar.Items.Add(textBlockStatus);
        DockPanel.SetDock(statusBar, Dock.Bottom);
        dock.Children.Add(statusBar);
        if (args.addDialogButtons)
        {
            dialogButtons = new DialogButtons();
            dialogButtons.ChangeDialogResult += DialogButtons_ChangeDialogResult;
            DockPanel.SetDock(dialogButtons, Dock.Bottom);
            dock.Children.Add(dialogButtons);
        }
        this.ResizeMode = args2.rm;
        // Původně bylo WidthAndHeight, pak Manual, pak opět WidthAndHeight - pokud zobrazuji LoginDialog např. chci aby to vypadalo profesionálně
        this.SizeToContent = System.Windows.SizeToContent.WidthAndHeight;
        //this.MaxWidth = System.Windows.SystemParameters.PrimaryScreenWidth * 0.75d;
        //this.MaxHeight = System.Windows.SystemParameters.PrimaryScreenHeight * 0.75d;
        this.Content = dock;
        this.HorizontalContentAlignment = HorizontalAlignment.Stretch;
        this.VerticalContentAlignment = VerticalAlignment.Stretch;
        this.HorizontalAlignment = HorizontalAlignment.Stretch;
        this.VerticalAlignment = VerticalAlignment.Stretch;
        AddUC();
        Loaded += WindowWithUserControl_Loaded;
        SizeChanged += WindowWithUserControl_SizeChanged;
        PreviewKeyDown += WindowWithUserControl_PreviewKeyDown;
    }
    public WindowWithUserControl()
    {
    }
    private void ControlWithResult_ChangeDialogResult(bool? result)
    {
        UserControlWithResult_ChangeDialogResult(result);
    }
    private void WindowWithUserControl_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs eventArgs)
    {
        if (eventArgs.Key == System.Windows.Input.Key.Enter)
        {
            if (ChangeDialogResult != null)
            {
                //DialogResult = true;
                OnChangeDialogResult(true);
            }
            else
            {
                if (controlWithResultDebug != null)
                {
                    controlWithResultDebug.DialogResult = true;
                }
            }
            Close();
        }
        else if (eventArgs.Key == System.Windows.Input.Key.Escape)
        {
            OnChangeDialogResult(false);
            Close();
        }
    }
    private void OnChangeDialogResult(bool value)
    {
        if (ChangeDialogResult != null)
        {
            ChangeDialogResult(value);
        }
    }
    private void WindowWithUserControl_Closing(object sender, CancelEventArgs eventArgs)
    {
        dialogResult = false;
    }
    private void DialogButtons_ChangeDialogResult(bool? result)
    {
        UserControlWithResult_ChangeDialogResult(result);
    }
    public bool EnableBtnOk
    {
        set
        {
            dialogButtons.btnOk.IsEnabled = value;
        }
    }
    /// <summary>
    /// Cant be used as handler, then is called multiple times becaues UserControlWithResult_ChangeDialogResult call the same method
    /// </summary>
    /// <param name="result"></param>
    void uc_ChangeDialogResult(bool? result)
    {
        // Throwed exception, output is captured by ChangeDialogResult
        //DialogResult = b;
        if (ChangeDialogResult != null)
        {
            //var tag2 = Tag.ToString();
            if (dialogResult.HasValue && !dialogResult.Value)
            {
                result = dialogResult;
            }
            // If is registered, will close window exteranlly
            ChangeDialogResult?.Invoke(result);
            WindowHelper.Close(this);
        }
        else
        {
            if (args.useResultOfShowDialog)
            {
                base.DialogResult = result;
            }
            // Otherwise close here
            Close();
        }
    }
    private void UserControlWithResult_ChangeDialogResult(bool? result)
    {
        if (userControl is ICheckBoxListUC)
        {
            ICheckBoxListUC checkBoxListUC = (ICheckBoxListUC)userControl;
            var checked2 = checkBoxListUC.CheckedIndexes();
            if (dialogButtons != null)
            {
                if (dialogButtons.clickedOk || dialogButtons.clickedApply || dialogButtons.clickedCancel)
                {
                    UserControlWithResult_ChangeDialogResult2(result);
                }
                if (checked2.Count() > 0)
                {
                    dialogButtons.IsEnabledBtnOk = true;
                }
                else
                {
                    dialogButtons.IsEnabledBtnOk = false;
                }
            }
        }
        else if (userControl is RadioButtonsList)
        {
            RadioButtonsList rbl = (RadioButtonsList)userControl;
            var tag = rbl.clickedTag;
            if (dialogButtons != null)
            {
                if (dialogButtons.clickedOk || dialogButtons.clickedApply || dialogButtons.clickedCancel)
                {
                    UserControlWithResult_ChangeDialogResult2(result);
                }
                if (tag != null)
                {
                    dialogButtons.IsEnabledBtnOk = true;
                }
                else
                {
                    dialogButtons.IsEnabledBtnOk = false;
                }
            }
        }
        else
        {
            UserControlWithResult_ChangeDialogResult2(result);
        }
    }
    private void UserControlWithResult_ChangeDialogResult2(bool? result)
    {
        if (dialogButtons != null)
        {
            // not only when click ok, could also when click cancel or apply
            //if (dialogButtons.clickedOk)
            //{
            uc_ChangeDialogResult(result);
            //}
        }
        else
        {
            ////////////DebugLogger.Instance.ClipboardOrDebug("Calling uc_ChangeDialogResult with NO window dialog buttons");
            uc_ChangeDialogResult(result);
        }
    }
    private void WindowWithUserControl_Loaded(object sender, RoutedEventArgs eventArgs)
    {
        var before = ActualHeight;
        if (args.sizeWindow != Size.Empty)
        {
            WpfApp.cd.Invoke(() =>
           {
               //Application.Current.MainWindow = this;
               //Application.Current.MainWindow.Width = args.sizeWindow.Width;
               //Application.Current.MainWindow.Height = args.sizeWindow.Height;
               var width = args.sizeWindow.Width;
               var height = args.sizeWindow.Height;
               if (width != 0)
               {
                   this.Width = width;
               }
               if (height != 0)
               {
                   this.Height = height;
               }
           }, System.Windows.Threading.DispatcherPriority.ContextIdle);
        }
        var after = ActualHeight;
    }
    private void AddUC()
    {
        // TODO: Find method where is mass setted all aligments
        userControl.VerticalAlignment = VerticalAlignment.Stretch;
        userControl.VerticalContentAlignment = VerticalAlignment.Stretch;
        userControl.HorizontalAlignment = HorizontalAlignment.Stretch;
        userControl.HorizontalContentAlignment = HorizontalAlignment.Stretch;
        dock.Children.Add(userControl);
        int countOfHandlers = 0;
        if (userControl is IControlWithResultWpf)
        {
            userControlWithResult = (IControlWithResultWpf)userControl;
            if (isControlWithResultDebug)
            {
                controlWithResultDebug.AttachChangeDialogResult(new VoidBoolNullable(UserControlWithResult_ChangeDialogResult), false);
                countOfHandlers = controlWithResultDebug.CountOfHandlersChangeDialogResult();
            }
            userControlWithResult.FocusOnMainElement();
        }
        /* Is not only when addDialogButtons, in case of Lb_AddCompilerRulesToRuleset I attach ChangeDialogResult for
         * both IControlWithResult and IControlWithResultDebug
         */
        //if (addDialogButtons)
        //{
        if (userControlWithResult != null)
        {
            if (!args.useResultOfShowDialog)
            {
                // IF USER CONTROL HAVE OWN ChangeDialogResult, MUST USE ALWAYS IT
                // In CheckBoxListUC must handle whether at least one is selected
                var typeName = uc.GetType().ToString();
                // Check for comparing, delete BP
                if (typeName != TypesControlsSunamo.CheckBoxListUC)
                {
                    userControlWithResult.ChangeDialogResult -= uc_ChangeDialogResult;
                    userControlWithResult.ChangeDialogResult -= UserControlWithResult_ChangeDialogResult;
                }
            }
        }
        //}
        Activate();
        // V InvalidateMeasure není volání na žádné Invalidate
        InvalidateMeasure();
        // Díval jsem se do ReferenceSource, InvalidateVisual volá jen InvalidateArrange
        InvalidateVisual();
    }
    public event VoidBoolNullable ChangeDialogResult;
    public event TaskBoolNullable ChangeDialogResultAsync;
    private void WindowWithUserControl_Closed(object sender, System.EventArgs eventArgs)
    {
        WpfApp.SaveReferenceToTextBlockStatus(true, null, null);
    }
    public static void AvailableShortcut(Dictionary<string, string> dictionary)
    {
        ShowTextResult result = new ShowTextResult(SHJoin.JoinDictionary(dictionary, " - "));
        WindowWithUserControl window = new WindowWithUserControl(result, ResizeMode.NoResize);
        window.ShowDialog();
    }
    public void Accept(object input)
    {
        if (userControlWithResult != null)
        {
            userControlWithResult.Accept(input);
        }
    }
    public void OnSizeChanged(DesktopSize maxSize)
    {
        if (userControlWithSizeChange != null)
        {
            userControlWithSizeChange.OnSizeChanged(maxSize);
        }
    }
    public void Init()
    {
    }
    public void FocusOnMainElement()
    {
    }
    #endregion
    //private ShowTextResult result;
    //private ResizeMode canResizeWithGrip;
    //public WindowWithUserControl(ShowTextResult result, ResizeMode canResizeWithGrip)
    //{
    //    this.result = result;
    //    this.canResizeWithGrip = canResizeWithGrip;
    //}
    //public static void AvailableShortcut(Dictionary<string, string> availableShortcuts)
    //{
    //    throw new NotImplementedException();
    //}
}