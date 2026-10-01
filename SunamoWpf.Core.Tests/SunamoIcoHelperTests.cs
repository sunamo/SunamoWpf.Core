using Xunit;
using System.Drawing;
using System.IO;

namespace SunamoWpf.Core.Tests;

public class SunamoIcoHelperTests
{
    [Fact]
    public void SunamoIcoAll()
    {
        // The original test loaded a png from a path that no longer exists; an in-memory bitmap is used instead.
        string folder = Path.Combine(Path.GetTempPath(), "SunamoIcoTests_" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(folder);
        try
        {
            using Bitmap bmp = new Bitmap(32, 32);
            Save(folder, bmp, SunamoIcoHelper.IconFromImage, "IconFromImage");
        }
        finally
        {
            Directory.Delete(folder, true);
        }
    }

    private void Save(string folder, Bitmap bmp, Func<Image, Icon> convertToIco, string name)
    {
        var f = Path.Combine(folder, name + ".ico");

        var icon = convertToIco.Invoke(bmp);
        using (FileStream fs = new FileStream(f, FileMode.OpenOrCreate))
        {
            icon.Save(fs);
        }
        Assert.True(new FileInfo(f).Length > 0);
    }
}
