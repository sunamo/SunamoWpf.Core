namespace SunamoWpf;

public class SearchCodeElementsUCData
{
    public ComboBox txtSearchInCodeElementName;
    public ComboBox txtSearchInContent;
    public ComboBox txtSearchInPath;
    CheckBox chbSearchInContent;
    CheckBox chbSearchInPath;
    CheckBox chbSearchInCodeElementName;
    /// <summary>
    /// In key full path to file, in value lines
    /// Dávají se zde pouze value jež se našli ve CodeElements bez zakomentovaných
    /// 
    /// </summary>
    public Dictionary<string, List<FoundedCodeElementWpf>> _founded;
    public Dictionary<string, List<FoundedCodeElementWpf>> founded
    {
        get
        {
            return _founded;
        }
        set
        {
#if DEBUG
            if (value != null)
            {
                var where = value.Where(w => w.Value.Count == 5);
                if (where.Count() > 0)
                {
                }
            }
#endif
            _founded = value;
        }
    }
    string _file = null;
    public string file
    {
        get
        {
            return _file;
        }
        set
        {
            _file = value;
#if DEBUG
            //////DebugLogger.Instance.WriteLineNull(value);
#endif
        }
    }
    public List<FoundedCodeElementWpf> actualFileSearchOccurences
    {
        get
        {
            if (founded == null || file == null)
            {
                return new List<FoundedCodeElementWpf>();
            }
            return founded[file];
        }
    }
    public SearchCodeElementsUCData(ComboBox txtSearchInCodeElementName, ComboBox txtSearchInContent, ComboBox txtSearchInPath, CheckBox chbSearchInContent, CheckBox chbSearchInPath, CheckBox chbSearchInCodeElementName)
    {
        this.txtSearchInCodeElementName = txtSearchInCodeElementName;
        this.txtSearchInContent = txtSearchInContent;
        this.txtSearchInPath = txtSearchInPath;
        this.chbSearchInContent = chbSearchInContent;
        this.chbSearchInPath = chbSearchInPath;
        this.chbSearchInCodeElementName = chbSearchInCodeElementName;
    }
    public SearchCodeElementsUCData()
    {
    }
    public bool IsSearchingInElementName
    {
        get
        {
            return !string.IsNullOrWhiteSpace(txtSearchInCodeElementName.Text); // || ( string.IsNullOrWhiteSpace && 
        }
    }
    public bool IsSearchingInContent
    {
        get
        {
            return !string.IsNullOrWhiteSpace(txtSearchInContent.Text);
            //return chbSearchInContent.IsChecked.Value;
        }
    }
    public bool IsSearchingInPath
    {
        get
        {
            return !string.IsNullOrWhiteSpace(txtSearchInPath.Text);
            //return chbSearchInPath.IsChecked.Value;
        }
    }
}