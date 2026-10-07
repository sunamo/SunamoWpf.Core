namespace SunamoWpf.Core._sunamo;

using PathMs = System.IO.Path;

public class FS
{
    protected static readonly List<char> invalidFileNameChars = Path.GetInvalidFileNameChars().ToList();

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

    public static void CreateUpfoldersPsysicallyUnlessThere(string nad)
    {
        CreateFoldersPsysicallyUnlessThere(Path.GetDirectoryName(nad));
    }
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


    public static bool ExistsDirectory(string value)
    {
        return Directory.Exists(value);
    }
    public static bool ExistsFile(string selectedFile)
    {
        return File.Exists(selectedFile);
    }
    public static string GetFileName(string path)
    {
        return PathMs.GetFileName(path.TrimEnd(Path.DirectorySeparatorChar));
    }

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
            //WpfLogger.Error(Translate.FromKey(XlfKeys.FileCanTBeDeleted) + ": " + item);
            return false;
        }
    }

    public static string WithEndSlash(string csprojFolderInput)
    {
        return csprojFolderInput.TrimEnd('\\') + "\\";
    }

    public static string WithEndSlash(ref string path)
    {
        if (path != string.Empty)
        {
            path = path.TrimEnd('\\') + '\\';
        }

        FirstCharUpper(ref path);
        return path;
    }

    public static string FirstCharUpper(ref string nazevPP)
    {
        nazevPP = FirstCharUpper(nazevPP);
        return nazevPP;
    }

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