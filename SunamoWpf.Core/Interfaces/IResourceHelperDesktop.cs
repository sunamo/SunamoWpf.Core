namespace SunamoWpf.Interfaces;

public interface IResourceHelperDesktop : IResourceHelperWpf
{

    BitmapImage GetBitmapImageSource(string name);

}