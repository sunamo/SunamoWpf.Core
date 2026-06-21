namespace SunamoWpf._shared.Helpers.Resources;

public class EmbeddedResourcesHShared : EmbeddedResourcesH
{
    private static EmbeddedResourcesHShared _ciShared = null;
    private static readonly object _lock = new object();
    private static string _applicationName = null;

    /// <summary>
    /// EN: Initialize shared instance with application name. Must be called before using ciShared.
    /// CZ: Inicializuje sdílenou instanci s názvem aplikace. Musí být zavoláno před použitím ciShared.
    /// </summary>
    public static void Initialize(string applicationName)
    {
        System.Console.WriteLine($"EmbeddedResourcesHShared.Initialize called with: '{applicationName}'");
        lock (_lock)
        {
            _applicationName = applicationName;
            _ciShared = null; // Reset instance to force recreation with new name
        }
        System.Console.WriteLine("EmbeddedResourcesHShared.Initialize completed");
    }

    /// <summary>
    /// EN: Lazy-initialized shared instance. Requires EmbeddedResourcesHShared.Initialize() to be called first.
    /// CZ: Lazy inicializovaná sdílená instance. Vyžaduje aby bylo nejdřív zavoláno EmbeddedResourcesHShared.Initialize().
    /// </summary>
    public static EmbeddedResourcesHShared ciShared
    {
        get
        {
            System.Console.WriteLine($"EmbeddedResourcesHShared.ciShared getter called, _ciShared is null: {_ciShared == null}");
            if (_ciShared == null)
            {
                lock (_lock)
                {
                    if (_ciShared == null)
                    {
                        System.Console.WriteLine($"Creating new instance, _applicationName = '{_applicationName}'");
                        if (string.IsNullOrWhiteSpace(_applicationName))
                        {
                            System.Console.WriteLine("ERROR: _applicationName is null or empty!");
                            throw new InvalidOperationException(
                                "EmbeddedResourcesHShared has not been initialized. Call EmbeddedResourcesHShared.Initialize(\"YourAppName\") before using ciShared.\r\n" +
                                "CZ: EmbeddedResourcesHShared nebyl inicializován. Zavolejte EmbeddedResourcesHShared.Initialize(\"VaseAplikace\") před použitím ciShared.");
                        }
                        _ciShared = new EmbeddedResourcesHShared(_applicationName);
                        ci = _ciShared;
                        System.Console.WriteLine("EmbeddedResourcesHShared instance created successfully");
                    }
                }
            }
            return _ciShared;
        }
    }

    private EmbeddedResourcesHShared(string applicationName)
    {
        System.Diagnostics.Debug.WriteLine($"EmbeddedResourcesHShared: applicationName = '{applicationName}'");

        _entryAssembly = RH.AssemblyWithName(applicationName);
        System.Diagnostics.Debug.WriteLine($"EmbeddedResourcesHShared: _entryAssembly = {(_entryAssembly == null ? "NULL" : _entryAssembly.FullName)}");

        if (_entryAssembly == null)
        {
            throw new InvalidOperationException(
                $"Could not find assembly with name '{applicationName}'. Make sure the application name passed to EmbeddedResourcesHShared.Initialize() matches the actual entry assembly name.\r\n" +
                $"CZ: Nepodařilo se najít assembly s názvem '{applicationName}'. Ujistěte se, že název aplikace předaný do EmbeddedResourcesHShared.Initialize() odpovídá skutečnému názvu entry assembly.");
        }

        _defaultNamespace = applicationName;
    }

    /// <summary>
    /// EN: Force reload of entry assembly. Just calls Initialize() again.
    /// CZ: Vynutí znovunačtení entry assembly. Pouze volá Initialize() znovu.
    /// </summary>
    public static void LoadEntryAssembly()
    {
        // CZ: Tato metoda je deprecated, použij radši Initialize() přímo
        // EN: This method is deprecated, use Initialize() directly instead
        if (!string.IsNullOrWhiteSpace(_applicationName))
        {
            Initialize(_applicationName);
        }
    }

    public EmbeddedResourcesHShared(Assembly _entryAssembly, string defaultNamespace) : base(_entryAssembly, defaultNamespace)
    {

    }

    public BitmapImage GetBitmapImageSource(string name)
    {
        var imageSource = new BitmapImage();

        var resName = GetResourceName(name);
        using (var stream = entryAssembly.GetManifestResourceStream(resName))
        {
            imageSource.BeginInit();
            imageSource.StreamSource = stream;
            imageSource.EndInit();
        }

        return imageSource;
    }

    /// <summary>
    /// When is ns different (Dummy Selling app) than name of uc (Dummy UC) must use this
    /// Normally used application name as ns
    /// </summary>
    /// <param name="_entryAssembly"></param>
    /// <param name="defaultNamespace"></param>
    /// <param name="v"></param>
    /// <returns></returns>
    public ImageSource GetAppIcon(Assembly _entryAssembly, string defaultNamespace, string v, ref EmbeddedResourcesHShared er)
    {
        er = new EmbeddedResourcesHShared(_entryAssembly, defaultNamespace);
        return er.GetBitmapImageSource(v);
    }

    /// <summary>
    /// ALways take from ciShared ()
    /// 
    /// </summary>
    /// <param name="v"></param>
    /// <returns></returns>
    public ImageSource GetAppIcon(string v)
    {
        var ims = ciShared.GetBitmapImageSource(v);
        return ims;
    }
}