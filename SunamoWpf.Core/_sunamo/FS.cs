namespace SunamoWpf.Core._sunamo;

using PathMs = System.IO.Path;

/// <summary>
/// Represents the FS type.
/// </summary>
public class FS
{
    /// <summary>
    /// The invalid file name chars.
    /// </summary>
    protected static readonly List<char> invalidFileNameChars = Path.GetInvalidFileNameChars().ToList();

    /// <summary>
    /// Replace incorrect characters file.
    /// </summary>
    /// <param name="fileName">The file name.</param>
    /// <returns>The replace incorrect characters file result.</returns>
    public static string ReplaceIncorrectCharactersFile(string fileName)
    {
        var result = fileName;
        foreach (var item in invalidFileNameChars)
        {
            var stringBuilder = new StringBuilder();
            foreach (var item2 in result)
                if (item != item2)
                    stringBuilder.Append(item2);
                else
                    stringBuilder.Append("");
            result = stringBuilder.ToString();
        }
        return result;
    }

    /// <summary>
    /// Create upfolders psysically unless there.
    /// </summary>
    /// <param name="nad">The nad.</param>
    public static void CreateUpfoldersPsysicallyUnlessThere(string nad)
    {
        CreateFoldersPsysicallyUnlessThere(Path.GetDirectoryName(nad));
    }
    /// <summary>
    /// Create folders psysically unless there.
    /// </summary>
    /// <param name="nad">The nad.</param>
    public static void CreateFoldersPsysicallyUnlessThere(string nad)
    {
        ThrowEx.IsNullOrEmpty("nad", nad);
        //ThrowEx.IsNotWindowsPathFormat("nad", nad);
        if (Directory.Exists(nad))
        {
            return;
        }
        List<string> slozkyKVytvoreni = new List<string>
{
nad
};
        while (true)
        {
            nad = Path.GetDirectoryName(nad);

            if (Directory.Exists(nad))
            {
                break;
            }
            string kopia = nad;
            slozkyKVytvoreni.Add(kopia);
        }
        slozkyKVytvoreni.Reverse();
        foreach (string item in slozkyKVytvoreni)
        {
            string folder = item;
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
        }
    }


    /// <summary>
    /// Exists directory.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>The exists directory result.</returns>
    public static bool ExistsDirectory(string value)
    {
        return Directory.Exists(value);
    }
    /// <summary>
    /// Exists file.
    /// </summary>
    /// <param name="selectedFile">The selected file.</param>
    /// <returns>The exists file result.</returns>
    public static bool ExistsFile(string selectedFile)
    {
        return File.Exists(selectedFile);
    }
    /// <summary>
    /// Get file name.
    /// </summary>
    /// <param name="path">The path.</param>
    /// <returns>The get file name result.</returns>
    public static string GetFileName(string path)
    {
        return PathMs.GetFileName(path.TrimEnd(Path.DirectorySeparatorChar));
    }

    /// <summary>
    /// Get size in auto string.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="fromUnit">The from unit.</param>
    /// <returns>The get size in auto string result.</returns>
    public static string GetSizeInAutoString(long value, ComputerSizeUnitsWpf fromUnit)
    {
        return GetSizeInAutoString((double)value, fromUnit);
    }
    private static double ConvertToSmallerComputerUnitSize(double value, ComputerSizeUnitsWpf fromUnit, ComputerSizeUnitsWpf toUnit)
    {
        if (toUnit == ComputerSizeUnitsWpf.Auto)
            throw new Exception(
                "Byl specifikov\u00E1n v\u00FDstupn\u00ED ComputerSizeUnit, nem\u016F\u017Eu toto nastaven\u00ED zm\u011Bnit");
        if (toUnit == ComputerSizeUnitsWpf.KB && fromUnit != ComputerSizeUnitsWpf.KB)
            value *= 1024;
        else if (toUnit == ComputerSizeUnitsWpf.MB && fromUnit != ComputerSizeUnitsWpf.MB)
            value *= 1024 * 1024;
        else if (toUnit == ComputerSizeUnitsWpf.GB && fromUnit != ComputerSizeUnitsWpf.GB)
            value *= 1024 * 1024 * 1024;
        else if (toUnit == ComputerSizeUnitsWpf.TB && fromUnit != ComputerSizeUnitsWpf.TB) value *= 1024L * 1024L * 1024L * 1024L;
        return value;
    }
    /// <summary>
    /// Get size in auto string.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="fromUnit">The from unit.</param>
    /// <returns>The get size in auto string result.</returns>
    public static string GetSizeInAutoString(double value, ComputerSizeUnitsWpf fromUnit)
    {
        if (fromUnit != ComputerSizeUnitsWpf.B)
            // Z�sk�m hodnotu v bytech
            value = ConvertToSmallerComputerUnitSize(value, fromUnit, ComputerSizeUnitsWpf.B);
        if (value < 1024) return value + " B";
        var previous = value;
        value /= 1024;
        if (value < 1) return previous + " B";
        previous = value;
        value /= 1024;
        if (value < 1) return previous + " KB";
        previous = value;
        value /= 1024;
        if (value < 1) return previous + " MB";
        previous = value;
        value /= 1024;
        if (value < 1) return previous + " GB";
        return value + " TB";
    }

    /// <summary>
    /// Get size in auto string.
    /// </summary>
    /// <param name="size">The size.</param>
    /// <returns>The get size in auto string result.</returns>
    public static string GetSizeInAutoString(double size)
    {
        var unit = ComputerSizeUnitsWpf.B;
        if (size > NumConsts.kB)
        {
            unit = ComputerSizeUnitsWpf.KB;
            size /= NumConsts.kB;
        }
        if (size > NumConsts.kB)
        {
            unit = ComputerSizeUnitsWpf.MB;
            size /= NumConsts.kB;
        }
        if (size > NumConsts.kB)
        {
            unit = ComputerSizeUnitsWpf.GB;
            size /= NumConsts.kB;
        }
        if (size > NumConsts.kB)
        {
            unit = ComputerSizeUnitsWpf.TB;
            size /= NumConsts.kB;
        }
        return size + " " + unit;
    }

    /// <summary>
    /// Stream to array bytes.
    /// </summary>
    /// <param name="stream">The stream.</param>
    /// <returns>The stream to array bytes result.</returns>
    public static byte[] StreamToArrayBytes(System.IO.Stream stream)
    {
        if (stream == null)
        {
            return new byte[0];
        }

        long originalPosition = 0;

        if (stream.CanSeek)
        {
            originalPosition = stream.Position;
            stream.Position = 0;
        }

        try
        {
            byte[] readBuffer = new byte[4096];

            int totalBytesRead = 0;
            int bytesRead;

            while ((bytesRead = stream.Read(readBuffer, totalBytesRead, readBuffer.Length - totalBytesRead)) > 0)
            {
                totalBytesRead += bytesRead;

                if (totalBytesRead == readBuffer.Length)
                {
                    int nextByte = stream.ReadByte();
                    if (nextByte != -1)
                    {
                        byte[] temp = new byte[readBuffer.Length * 2];
                        Buffer.BlockCopy(readBuffer, 0, temp, 0, readBuffer.Length);
                        Buffer.SetByte(temp, totalBytesRead, (byte)nextByte);
                        readBuffer = temp;
                        totalBytesRead++;
                    }
                }
            }

            byte[] buffer = readBuffer;
            if (readBuffer.Length != totalBytesRead)
            {
                buffer = new byte[totalBytesRead];
                Buffer.BlockCopy(readBuffer, 0, buffer, 0, totalBytesRead);
            }
            return buffer;
        }
        finally
        {
            if (stream.CanSeek)
            {
                stream.Position = originalPosition;
            }
        }
    }

    /// <summary>
    /// Try delete file.
    /// </summary>
    /// <param name="item">The item.</param>
    /// <returns>The try delete file result.</returns>
    public static bool TryDeleteFile(string item)
    {
        // TODO: To all code message logging as here
        try
        {
            // If file won't exists, wont throw any exception
            File.Delete(item);
            return true;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// With end slash.
    /// </summary>
    /// <param name="csprojFolderInput">The csproj folder input.</param>
    /// <returns>The with end slash result.</returns>
    public static string WithEndSlash(string csprojFolderInput)
    {
        return csprojFolderInput.TrimEnd('\\') + "\\";
    }

    /// <summary>
    /// With end slash.
    /// </summary>
    /// <param name="path">The path.</param>
    /// <returns>The with end slash result.</returns>
    public static string WithEndSlash(ref string path)
    {
        if (path != string.Empty)
        {
            path = path.TrimEnd('\\') + '\\';
        }

        FirstCharUpper(ref path);
        return path;
    }

    /// <summary>
    /// First char upper.
    /// </summary>
    /// <param name="nazevPP">The nazev PP.</param>
    /// <returns>The first char upper result.</returns>
    public static string FirstCharUpper(ref string nazevPP)
    {
        nazevPP = FirstCharUpper(nazevPP);
        return nazevPP;
    }

    /// <summary>
    /// First char upper.
    /// </summary>
    /// <param name="nazevPP">The nazev PP.</param>
    /// <returns>The first char upper result.</returns>
    public static string FirstCharUpper(string nazevPP)
    {
        if (nazevPP.Length == 1)
        {
            return nazevPP.ToUpper();
        }

        string withoutFirstCharacter = nazevPP.Substring(1);
        return nazevPP[0].ToString().ToUpper() + withoutFirstCharacter;
    }
}