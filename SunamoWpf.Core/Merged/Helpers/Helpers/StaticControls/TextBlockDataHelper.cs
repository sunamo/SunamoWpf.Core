#define ASYNC
namespace SunamoWpf.Helpers.StaticControls;

/// <summary>
/// Represents the text block data helper type.
/// </summary>
public class TextBlockDataHelper
{
    /// <summary>
    /// Get for compare.
    /// </summary>
    /// <param name="value1">The value 1.</param>
    /// <param name="value2">The value 2.</param>
    /// <returns>The get for compare result.</returns>
    public static TextBlockDataCompare GetForCompare(decimal value1, decimal value2)
    {
        TextBlockDataCompare result = new TextBlockDataCompare();

        if (value1 > value2)
        {

            result.fg = Brushes.Green;

            result.fg2 = Brushes.Red;


            result.text = " > ";
        }
        else if (value2 > value1)
        {

            result.fg = Brushes.Red;

            result.fg2 = Brushes.Green;


            result.text = " < ";
        }
        else
        {
            result.text = " = ";
        }

        return result;
    }
}