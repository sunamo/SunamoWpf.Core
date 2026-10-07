using System.Drawing;
using System.Windows.Media.Imaging;
using SunamoWf.Helpers;
using SunamoWpf.Helpers.Content.Resources;

namespace SunamoWpf.Core.Tests;

public class BitmapImageHelperTests
{
    string GetFile(string fileName)
    {
        return @"D:\_Test\sunamo\desktop\Helpers\Content\Resource\BitmapImageHelper\Bitmap2BitmapImage\" + fileName + ".png";
    }

    [StaFact]
    public void Bitmap2BitmapImageTest()
    {
        var bitmap = Image.FromFile(GetFile("17"));
        bitmap = BitmapHelper.ChangeColor2(bitmap, Color.Black, Color.Orange);

        BitmapImage biVsLogo = BitmapImageHelper.Bitmap2BitmapImage(bitmap);

        var outFile = GetFile("out");
        BitmapImageHelper.Save(biVsLogo, outFile);
    }
}
