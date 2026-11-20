#define ASYNC
namespace SunamoWpf;

using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

/// <summary>
/// Represents the create image for size shared type.
/// </summary>
public class CreateImageForSizeShared
{

    /// <summary>
    /// Place to center.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <param name="width">The width.</param>
    /// <param name="height">The height.</param>
    /// <param name="fontSize">The font size.</param>
    /// <param name="saveToFolder">The save to folder.</param>
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

    /// <summary>
    /// Create single color image with color.
    /// </summary>
    /// <param name="width">The width.</param>
    /// <param name="height">The height.</param>
    /// <param name="fileName">The file name.</param>
    /// <param name="color">The color.</param>
    /// <param name="saveToFolder">The save to folder.</param>
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