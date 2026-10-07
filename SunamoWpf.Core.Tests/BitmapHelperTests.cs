using System.Drawing;
using SunamoWf.Helpers;

namespace SunamoWpf.Core.Tests;

public class BitmapHelperTests
{
    string GetFile(string fileName)
    {
        return @"D:\_Test\sunamo\desktop\Helpers\Controls\BitmapHelperTests\" + fileName + ".png";
    }

    [Fact]
    public void ChangeColor2Test()
    {
        Bitmap bmp = new Bitmap(GetFile("In"));
        var changedBitmap = BitmapHelper.ChangeColor2(bmp, Color.Black, Color.Orange);
        changedBitmap.Save(GetFile("Out"));
    }
}
