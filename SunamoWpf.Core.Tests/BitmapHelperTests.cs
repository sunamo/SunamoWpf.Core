using System.Drawing;
using SunamoWf.Helpers;

namespace SunamoWpf.Core.Tests;

public class BitmapHelperTests
{
    string GetFile(string n)
    {
        return @"D:\_Test\sunamo\desktop\Helpers\Controls\BitmapHelperTests\" + n + ".png";
    }

    [Fact]
    public void ChangeColor2Test()
    {
        Bitmap bmp = new Bitmap(GetFile("In"));
        var nB = BitmapHelper.ChangeColor2(bmp, Color.Black, Color.Orange);
        nB.Save(GetFile("Out"));
    }
}
