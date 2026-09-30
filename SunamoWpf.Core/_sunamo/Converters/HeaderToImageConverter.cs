namespace SunamoWpf.Core._sunamo;

//[ValueConversion(typeof(string), typeof(bool))]
/// <summary>
/// Zkoušel jsem ho dát do win.pi kvůli IconExtractor
/// Bohužel pak se mi nepovedlo ani udělat import v xaml pro FolderContentsTreeView
/// Proto jednoduše vše co se používá v SunamoWpf xamlu, musí být v SunamoWpf
/// </summary>
internal class HeaderToImageConverter : IValueConverter
{
    public static HeaderToImageConverter Instance = new HeaderToImageConverter();

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        //FileSystemEntry path = (value as FileSystemEntry);

        // using (Icon i = IconExtractor.GetSmallIcon(path.path, path.file))
        // {
        //    if (i != null)
        //    {
        //        ImageSource img = Imaging.CreateBitmapSourceFromHIcon(
        //                                i.Handle,
        //                                new Int32Rect(0, 0, i.Width, i.Height),
        //                                BitmapSizeOptions.FromEmptyOptions());
        //        return img;
        //    }
        // }
        return null;
    }

    static Type type = typeof(HeaderToImageConverter);

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        ThrowEx.Custom(Translate.FromKey(XlfKeys.CannotConvertBack));
        return null;
    }
}
