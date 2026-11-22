#define ASYNC
namespace SunamoWpf;

/// <summary>
/// Represents the text block data type.
/// </summary>
public class TextBlockData
{
    /// <summary>
    /// The fg.
    /// </summary>
    public SolidColorBrush fg = Brushes.Black;
    /// <summary>
    /// The text.
    /// </summary>
    public string text = "";
    /// <summary>
    /// The font weight.
    /// </summary>
    public System.Windows.FontWeight fontWeight = FontWeightHelper.FromEnum(SunamoWpf.Enums.FontWeights.normal);

    /// <summary>
    /// The font weight 2.
    /// </summary>
    public SunamoWpf.Enums.FontWeights fontWeight2
    {
        set
        {
            FontWeightHelper.FromEnum(value);
        }
    }
}

/// <summary>
/// Represents the text block data compare type.
/// </summary>
public class TextBlockDataCompare : TextBlockData
{
    /// <summary>
    /// The fg 2.
    /// </summary>
    public SolidColorBrush fg2 = Brushes.Black;
}