#define ASYNC
namespace SunamoWpf.Controls.Helpers.Backend;

/// <summary>
/// IsDerived from TextBoxBackend
/// </summary>
public class FoundedFileUCBackend : IKeysHandler
{
    /// <summary>
    /// The old roots.
    /// </summary>
    public CollectionWithoutDuplicatesWpf<string> OldRoots = new CollectionWithoutDuplicatesWpf<string>();
    private SelectedCastHelper<string> selectedCastHelperString;
    /// <summary>
    /// The text box backend.
    /// </summary>
    public TextBoxBackend textBoxBackend = null;
    // aktuálně používá FoundedFilesResults2, ale mohl bych používat FoundedFilesResults
    private FoundedFilesUC/*<FoundedFileUC>*/ foundedFilesUC;
    FoundedFileUC lastSelected = null;

    /// <summary>
    /// A1 and A3 can be null - ReviewRestoredSourceFilesUC
    /// A5 = "0"
    /// </summary>
    /// <param name="selectedCastHelperString"></param>
    /// <param name="txtContent"></param>
    /// <param name="foundedFilesUC"></param>
    public FoundedFileUCBackend(TextBlock txtTextBoxState, TextEditor txtContent, SelectedCastHelper<string> selectedCastHelperString, object foundedFilesUC2, int addRowsDuringScrolling)
    {
        if (foundedFilesUC2 is FoundedFilesUC)
        {
            foundedFilesUC = (FoundedFilesUC)foundedFilesUC2;
        }
        this.selectedCastHelperString = selectedCastHelperString;

        #region TODO: fixing Everyline not searching
        //this.foundedFilesUC = foundedFilesUC;
        foundedFilesUC.AttachSelected(new VoidString(FoundedFilesUC_Selected));
        #endregion

        textBoxBackend = new TextBoxBackend(txtTextBoxState, txtContent, addRowsDuringScrolling);
    }

    private void FoundedFilesUC_Selected(string path)
    {
        ControlHelper.SwitchBorder((Control)lastSelected, BorderData.Black1);

        #region TODO: fixing Everyline not searching
        lastSelected = foundedFilesUC.GetFoundedFileByPath(path);
        #endregion
        ControlHelper.SwitchBorder((Control)lastSelected, BorderData.Black1);
    }

    /// <summary>
    /// The full path selected file.
    /// </summary>
    public string FullPathSelectedFile
    {
        get
        {
            return selectedCastHelperString.SelectedItem;
        }
    }

    /// <summary>
    /// The file is right event.
    /// </summary>
    public event VoidString FileIsRightEvent;
    /// <summary>
    /// The leave in actual folder.
    /// </summary>
    public event VoidString LeaveInActualFolder;
    /// <summary>
    /// The move last file.
    /// </summary>
    public event VoidString MoveLastFile;
    /// <summary>
    /// The return moved file back.
    /// </summary>
    public event VoidString ReturnMovedFileBack;


    /// <summary>
    /// Handle key.
    /// </summary>
    /// <param name="eventArgs">The event args.</param>
    /// <returns>The handle key result.</returns>
    public bool HandleKey(KeyEventArgs eventArgs)
    {
        if (FullPathSelectedFile == null)
        {
            return false;
        }

        if (eventArgs.Key == Key.Right)
        {
            // Is right
            if (FileIsRightEvent != null)
            {
                FileIsRightEvent(FullPathSelectedFile);
                return true;
            }

        }
        else if (eventArgs.Key == Key.Left)
        {
            // Is wrong, keep where is
            if (LeaveInActualFolder != null)
            {
                LeaveInActualFolder(FullPathSelectedFile);
                return true;
            }

        }
        else if (eventArgs.Key == Key.Up)
        {
            // Action
            if (MoveLastFile != null)
            {
                MoveLastFile(FullPathSelectedFile);
                return true;
            }

        }
        else if (eventArgs.Key == Key.Down)
        {
            // Undo action
            if (ReturnMovedFileBack != null)
            {
                ReturnMovedFileBack(FullPathSelectedFile);
                return true;
            }

        }
        return false;
    }


}