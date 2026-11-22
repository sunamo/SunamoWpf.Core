#define ASYNC
namespace SunamoWpf.Helpers.ContainerControls;

/// <summary>
/// Represents the window helper type.
/// </summary>
public partial class WindowHelper
{
    /// <summary>
    /// Pokud má být aplikace použitelná na mobilech, A1 musí být vždy True
    /// Pokud bude false, vrátí se výška i šířka 2x delší než jaká ve skutečnosti je(resp. vrátí se správná - 720x1136 ale na obrazovku se zvládne vykreslit jen 360x568)
    /// </summary>
    /// <param name="noScaleFactor"></param>
    public static Size WindowSize()
    {
        ThrowEx.NotImplementedMethod();
        return Size.Empty;
        //return WpfApp.mp.actualR.RenderSize;
    }
    /// <summary>
    /// Set dialog result.
    /// </summary>
    /// <param name="window">The window.</param>
    /// <param name="dialog">The dialog.</param>
    /// <param name="dialogResult">The dialog result.</param>
    /// <returns>The set dialog result result.</returns>
    public static bool? SetDialogResult(Window window, bool dialog, bool? dialogResult)
    {
        if (dialog)
        {
            var shownResult = window.ShowDialog();
            if (window.DialogResult != shownResult)
            {
                // Cant set DialogResult while window isnt show as dialog
                //DialogResult = dialogResult;
            }

            return shownResult;
        }
        else
        {
            return dialogResult;
        }
    }



    /// <summary>
    /// Show dialog.
    /// </summary>
    /// <param name="windowWithUserControl">The window with user control.</param>
    public static void ShowDialog(WindowWithUserControl windowWithUserControl)
    {
        dynamic windowWithUserControl2 = windowWithUserControl;
        if (windowWithUserControl2.dialogResult == null)
        {
            // 'Cannot set Visibility or call Show, ShowDialog, or WindowInteropHelper.EnsureHandle after a Window has closed.'
            /*
             e.Cancel = true;
        this.Visibility = Visibility.Hidden;
             */
            windowWithUserControl2.ShowDialog();
        }
    }

    /// <summary>
    /// Close.
    /// </summary>
    /// <param name="windowWithUserControl">The window with user control.</param>
    public static void Close(WindowWithUserControl windowWithUserControl)
    {
        try
        {
            if (windowWithUserControl != null)
            {
                windowWithUserControl.Close();
            }
        }
        catch (Exception)
        {
        }
    }
}
