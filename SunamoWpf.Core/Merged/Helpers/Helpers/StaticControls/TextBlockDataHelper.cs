#define ASYNC
namespace SunamoWpf.Helpers.StaticControls;

public class TextBlockDataHelper
{
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