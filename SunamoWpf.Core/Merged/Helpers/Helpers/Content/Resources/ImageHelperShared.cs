#define ASYNC
namespace SunamoWpf.Helpers.Content.Resources;

public partial class ImageHelper
    {
    static ImageHelperDesktop imageHelperDesktop = new ImageHelperDesktop();

    /// <summary>
    /// Toto je jediné místo kde je tato proměnná a to proto že je na něho navázaná metoda SetAssemblyNameForWpfApps, která se musí volat ve WPF(ale ne Windows Store apps) aplikacích
    /// </summary>
    public static string protocol = "pack://application:,,,";
        /// <summary>
        /// The protocol root.
        /// </summary>
        public static string protocolRoot = "pack://application:,,,/";

        /// <summary>
        /// Nevolá se ve Windows Store Apps aplikacích
        /// </summary>
        /// <param name="assemblyName"></param>
        public static void SetAssemblyNameForWpfApps(string assemblyName)
        {
            protocol += "/" + assemblyName + ";component/";
            //protocol = "pack://" + assemblyName + ";component/";
        }

        /// <summary>
        /// Register pack protocol.
        /// </summary>
        public static void RegisterPackProtocol()
        {
            if (!UriParser.IsKnownScheme("pack"))
                new System.Windows.Application();
        }
    
/// <summary>
/// Return image.
/// </summary>
/// <param name="imageSource">The image source.</param>
/// <returns>The return image result.</returns>
public static Image ReturnImage(ImageSource imageSource)
	{
        return imageHelperDesktop.ReturnImage(imageSource);
	}
/// <summary>
/// Return image.
/// </summary>
/// <param name="imageSource">The image source.</param>
/// <param name="width">The width.</param>
/// <param name="height">The height.</param>
/// <returns>The return image result.</returns>
public static Image ReturnImage(ImageSource imageSource, double width, double height)
	{
        return imageHelperDesktop.ReturnImage(imageSource, width, height);
	}
}