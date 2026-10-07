#define ASYNC
namespace SunamoWpf.Storage;

public partial class ApplicationDataContainer
{
    #region SelectFolder
    public void Add(SelectFolder chb)
    {
        ApplicationDataContainerList adcl = AddFrameworkElement(chb);
        chb.SelectedFolder = adcl.GetString(SelectedFolder);
        chb.FolderChanged += Chb_FolderChanged;

    }

    private void Chb_FolderChanged(object sender, string folder)
    {
        var selectFolder = sender as SelectFolder;

        Set(selectFolder, SelectedFolder, folder);
        SaveControl(selectFolder);
    }
    #endregion

    #region SelectMoreFolders
    public void Add(SelectMoreFolders txtFolders)
    {
        var adcl = AddFrameworkElement(txtFolders);
        var folders = adcl.GetListString(SelectedFolders, innerDelimiter);
        foreach (var item in folders)
        {
            txtFolders.AddFolder(item);
        }
        txtFolders.FolderChanged += TxtFolders_FolderChanged;
        txtFolders.FolderRemoved += TxtFolders_FolderRemoved;
    }

    private void TxtFolders_FolderRemoved(object sender, List<string> selectedFolders)
    {
        SaveChangesSelectMoreFolders(sender, selectedFolders);
    }
    private void TxtFolders_FolderChanged(object sender, List<string> selectedFolders)
    {
        SaveChangesSelectMoreFolders(sender, selectedFolders);
    }
    private void SaveChangesSelectMoreFolders(object sender, List<string> selectedFolders)
    {
        SelectMoreFolders chb = sender as SelectMoreFolders;
        // bcoz every line has strictly structure - name|type|data. Never be | in data
        Set(sender, SelectedFolders, SF.PrepareToSerializationExplicit2(selectedFolders, innerDelimiter));

        SaveControl(chb);
    }
    #endregion
}