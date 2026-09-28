namespace SunamoWpf._sunamo;

internal class SelectFromManyHelper<T>
{
    private readonly ISelectFromMany<T> _selectFromManyControl;
    internal string defaultFileForLeave;
    internal string defaultFileSize;

    internal Dictionary<string, string> filesWithSize = new();
    internal bool sufficientFileName;

    internal SelectFromManyHelper(ISelectFromMany<T> selectFromManyControl)
    {
        _selectFromManyControl = selectFromManyControl;
    }

    #region Files

    internal void InitializeByFolder(bool sufficientFileName, string defaultFileForLeave, string folderForSearch)
    {
        filesWithSize.Clear();
        SetBasicVariable(sufficientFileName, defaultFileForLeave);

        var fn = Path.GetFileName(defaultFileForLeave);
        var files = Directory.GetFiles(folderForSearch, fn, SearchOption.AllDirectories).ToList();

        ProcessFilesWithoutSize(files);
        _selectFromManyControl.AddControls();
    }

    private void ProcessFilesWithoutSize(List<string> files)
    {
        if (sufficientFileName)
            foreach (var item in files)
                filesWithSize.Add(item, null);
        else
            foreach (var item in files)
                filesWithSize.Add(item, FS.GetSizeInAutoString(new FileInfo(item).Length, ComputerSizeUnitsWpf.B));
    }

    private void SetBasicVariable(bool sufficientFileName, string defaultFileForLeave)
    {
        this.sufficientFileName = sufficientFileName;
        this.defaultFileForLeave = defaultFileForLeave;

        if (!sufficientFileName)
            defaultFileSize = FS.GetSizeInAutoString(new FileInfo(defaultFileForLeave).Length, ComputerSizeUnitsWpf.B);
    }

    internal void InitializeByFiles(bool sufficientFileName, string defaultFileForLeave, List<string> files)
    {
        filesWithSize.Clear();
        SetBasicVariable(sufficientFileName, defaultFileForLeave);

        ProcessFilesWithoutSize(files);
        _selectFromManyControl.AddControls();
    }

    internal void InitializeByFilesWithSize(bool sufficientFileName, string defaultFileForLeave,
        Dictionary<string, long> files)
    {
        filesWithSize.Clear();
        SetBasicVariable(sufficientFileName, defaultFileForLeave);

        foreach (var item in files)
            filesWithSize.Add(item.Key, FS.GetSizeInAutoString(item.Value, ComputerSizeUnitsWpf.B));
        _selectFromManyControl.AddControls();
    }

    #endregion
}