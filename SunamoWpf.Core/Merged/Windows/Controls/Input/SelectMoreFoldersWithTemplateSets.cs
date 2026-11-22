#define ASYNC
namespace SunamoWpf.Controls.Input;

/// <summary>
/// Represents the select more folders with template sets type.
/// </summary>
public class SelectMoreFoldersWithTemplateSets
{
    EnterOneValueWindow enterNameOfSet = null;
    ComboBoxHelper<string> cbSetsFoldersHelper = null;
    /// <summary>
    /// The cb sets folders.
    /// </summary>
    public ComboBox cbSetsFolders = new ComboBox();
    TextBlock tbSetsFolders = new TextBlock();
    /// <summary>
    /// The tb sets folders key.
    /// </summary>
    public string tbSetsFoldersKey = "SavedFoldersSets";
    /// <summary>
    /// The tb folders.
    /// </summary>
    public TextBlock tbFolders = new TextBlock();
    /// <summary>
    /// The tb folders key.
    /// </summary>
    public string tbFoldersKey = "Folders";
    /// <summary>
    /// The txt folders.
    /// </summary>
    public SelectMoreFolders txtFolders = new SelectMoreFolders();
    string pathFromCtor;
    /// <summary>
    /// A1,A3 can be zero, then wont add to grid and create content
    /// </summary>
    /// <param name="gridCbSets"></param>
    /// <param name="rowCbSets"></param>
    /// <param name="gridSmf"></param>
    /// <param name="rowSmf"></param>
    public SelectMoreFoldersWithTemplateSets(Grid gridCbSets, int rowCbSets, Grid gridSmf, int rowSmf, string path)
    {
        this.pathFromCtor = path;
        txtFolders.Name = "txtFoldersSelectMoreFoldersWithTemplateSets";
        #region CbSets
        if (gridCbSets != null)
        {
            Grid.SetRow(cbSetsFolders, rowCbSets);
            Grid.SetRow(tbSetsFolders, rowCbSets);
            Grid.SetColumn(cbSetsFolders, 1);
            tbSetsFolders.Text = tbSetsFoldersKey;
            gridCbSets.Children.Add(tbSetsFolders);
            gridCbSets.Children.Add(cbSetsFolders);
        }
        #endregion
        #region Smf
        if (gridSmf != null)
        {
            Grid.SetRow(txtFolders, rowSmf);
            Grid.SetRow(tbFolders, rowSmf);
            Grid.SetColumn(txtFolders, 1);
            tbFolders.Text = tbFoldersKey;
            gridSmf.Children.Add(tbFolders);
            gridSmf.Children.Add(txtFolders);
        }
        #endregion
        cbSetsFoldersHelper = new ComboBoxHelper<string>(cbSetsFolders);
        var lines = SF.GetAllElementsFile(path);
        foreach (var item in lines)
        {
            cbSetsFolders.Items.Add(item[0]);
        }
        cbSetsFoldersHelper.SelectionChanged += CbSetsFolders_SelectionChanged;
        txtFolders.SaveSetAsTemplate += this_SaveSetAsTemplate;
    }
    private void EnterOneValueUC_ChangeDialogResult(bool? result)
    {
        if (BTS.GetValueOfNullable(result))
        {
            string text = enterNameOfSet.enterOneValueUC.txtEnteredText.Text;
            if (cbSetsFolders.Items.Contains(text))
            {
                WpfLogger.Warning("Set " + "withName" + " " + text + " " + "alreadyExists");
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(text))
                {
                    List<string> pass = new List<string>(txtFolders.SelectedFolders());
                    pass.Add(text);
                    var line = SF.PrepareToSerializationExplicit2(pass);
                    SF.AppendAllText(pathFromCtor, line).RunSynchronously();
                    cbSetsFolders.Items.Add(text);
                }
            }
        }
    }
    private void CbSetsFolders_SelectionChanged(object sender, SelectionChangedEventArgs eventArgs)
    {
        string selected = cbSetsFoldersHelper.SelectedS;
        List<List<string>> lines = SF.GetAllElementsFile(pathFromCtor);
        foreach (var item in lines)
        {
            if (item[0] == selected)
            {
                txtFolders.RemoveAllFolders();
                for (int index = 1; index < item.Count; index++)
                {
                    txtFolders.AddFolder(item[index]);
                }
            }
        }
    }
    private void this_SaveSetAsTemplate()
    {
        enterNameOfSet = new EnterOneValueWindow("nameOfSet");
        // TODO Replaced during repair 0xc0000374
        //enterNameOfSet.enterOneValueUC.ChangeDialogResult += EnterOneValueUC_ChangeDialogResult;
        //enterNameOfSet.enterOneValueUC.Accept("Websites");
        enterNameOfSet.ShowDialog();
        //SF.PrepareToSerialization()
    }
}
