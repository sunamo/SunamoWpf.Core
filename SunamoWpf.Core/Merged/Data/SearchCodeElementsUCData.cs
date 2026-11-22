namespace SunamoWpf;

/// <summary>
/// Represents the search code elements UC data type.
/// </summary>
public class SearchCodeElementsUCData
{
    /// <summary>
    /// The txt search in code element name.
    /// </summary>
    public ComboBox txtSearchInCodeElementName;
    /// <summary>
    /// The txt search in content.
    /// </summary>
    public ComboBox txtSearchInContent;
    /// <summary>
    /// The txt search in path.
    /// </summary>
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
    /// <summary>
    /// The founded.
    /// </summary>
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
    /// <summary>
    /// The file.
    /// </summary>
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
    /// <summary>
    /// The actual file search occurences.
    /// </summary>
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
    /// <summary>
    /// Initializes a new instance of the search code elements UC data class.
    /// </summary>
    /// <param name="txtSearchInCodeElementName">The txt search in code element name.</param>
    /// <param name="txtSearchInContent">The txt search in content.</param>
    /// <param name="txtSearchInPath">The txt search in path.</param>
    /// <param name="chbSearchInContent">The chb search in content.</param>
    /// <param name="chbSearchInPath">The chb search in path.</param>
    /// <param name="chbSearchInCodeElementName">The chb search in code element name.</param>
    public SearchCodeElementsUCData(ComboBox txtSearchInCodeElementName, ComboBox txtSearchInContent, ComboBox txtSearchInPath, CheckBox chbSearchInContent, CheckBox chbSearchInPath, CheckBox chbSearchInCodeElementName)
    {
        this.txtSearchInCodeElementName = txtSearchInCodeElementName;
        this.txtSearchInContent = txtSearchInContent;
        this.txtSearchInPath = txtSearchInPath;
        this.chbSearchInContent = chbSearchInContent;
        this.chbSearchInPath = chbSearchInPath;
        this.chbSearchInCodeElementName = chbSearchInCodeElementName;
    }
    /// <summary>
    /// Initializes a new instance of the search code elements UC data class.
    /// </summary>
    public SearchCodeElementsUCData()
    {
    }
    /// <summary>
    /// The is searching in element name.
    /// </summary>
    public bool IsSearchingInElementName
    {
        get
        {
            return !string.IsNullOrWhiteSpace(txtSearchInCodeElementName.Text); // || ( string.IsNullOrWhiteSpace && 
        }
    }
    /// <summary>
    /// The is searching in content.
    /// </summary>
    public bool IsSearchingInContent
    {
        get
        {
            return !string.IsNullOrWhiteSpace(txtSearchInContent.Text);
            //return chbSearchInContent.IsChecked.Value;
        }
    }
    /// <summary>
    /// The is searching in path.
    /// </summary>
    public bool IsSearchingInPath
    {
        get
        {
            return !string.IsNullOrWhiteSpace(txtSearchInPath.Text);
            //return chbSearchInPath.IsChecked.Value;
        }
    }
}