#define ASYNC
namespace SunamoWpf;

using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

public class CreateImageForSizeShared
{

    public static void PlaceToCenter(string text, int width, int height, float fontSize, string saveToFolder)
    {
        Font font = new Font("Segoe UI", fontSize);
        Rectangle rect = new Rectangle(0, 0, width, height);

        var bmp = new Bitmap(width, height);

        var brush = System.Drawing.Brushes.Black;

        var gra = Graphics.FromImage(bmp);
        gra.SmoothingMode = SmoothingMode.AntiAlias;
        gra.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

        using (var stringFormat = new StringFormat()
        {
            Alignment = StringAlignment.Center,
            LineAlignment = StringAlignment.Center,
        })
        {
            gra.FillRectangle(ColorH.RandomLightBrush(RandomHelper.RandomEnum<ColorComponent>()).ToSystemDrawing(), rect);
            gra.DrawString(text, font, brush, new Rectangle(0, 0, bmp.Width, bmp.Height), stringFormat);
        }

        var fileName = FS.ReplaceIncorrectCharactersFile(SH.ShortForLettersCount(text, 100));
        var path = Path.Combine(saveToFolder, fileName + ".jpg");
        FS.CreateUpfoldersPsysicallyUnlessThere(path);


        bmp.Save(path, ImageFormat.Jpeg);
    }

    public static void CreateSingleColorImageWithColor(int width, int height, string fileName, SunamoColor color, string saveToFolder)
    {
        if (color != null && width != int.MinValue && height != int.MinValue)
        {
            Bitmap Bmp = new Bitmap(width, height);
            using (Graphics gfx = Graphics.FromImage(Bmp))
            using (SolidBrush brush = new SolidBrush(color.ToSystemDrawing()))
            {
                gfx.FillRectangle(brush, 0, 0, width, height);
            }
            Bmp.Save(Path.Combine(saveToFolder, fileName + ".png"), ImageFormat.Png);
        }
    }
}