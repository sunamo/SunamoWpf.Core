#define ASYNC
namespace SunamoWpf.Controls.Helpers.Backend;

/// <summary>
/// IsDerived from TextBoxBackend
/// </summary>
public class FoundedFileUCBackend : IKeysHandler
{
    public CollectionWithoutDuplicatesWpf<string> OldRoots = new CollectionWithoutDuplicatesWpf<string>();
    private SelectedCastHelper<string> selectedCastHelperString;
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

    private void FoundedFilesUC_Selected(string s)
    {
        ControlHelper.SwitchBorder((Control)lastSelected, BorderData.Black1);

        #region TODO: fixing Everyline not searching
        lastSelected = foundedFilesUC.GetFoundedFileByPath(s);
        #endregion
        ControlHelper.SwitchBorder((Control)lastSelected, BorderData.Black1);
    }

    public string FullPathSelectedFile
    {
        get
        {
            return selectedCastHelperString.SelectedItem;
        }
    }

    public event VoidString FileIsRightEvent;
    public event VoidString LeaveInActualFolder;
    public event VoidString MoveLastFile;
    public event VoidString ReturnMovedFileBack;


    public bool HandleKey(KeyEventArgs e)
    {
        if (FullPathSelectedFile == null)
        {
            return false;
        }

        if (e.Key == Key.Right)
        {
            // Is right
            if (FileIsRightEvent != null)
            {
                FileIsRightEvent(FullPathSelectedFile);
                return true;
            }

        }
        else if (e.Key == Key.Left)
        {
            // Is wrong, keep where is
            if (LeaveInActualFolder != null)
            {
                LeaveInActualFolder(FullPathSelectedFile);
                return true;
            }

        }
        else if (e.Key == Key.Up)
        {
            // Action
            if (MoveLastFile != null)
            {
                MoveLastFile(FullPathSelectedFile);
                return true;
            }

        }
        else if (e.Key == Key.Down)
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