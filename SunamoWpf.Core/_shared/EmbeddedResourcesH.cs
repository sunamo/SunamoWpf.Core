namespace SunamoWpf._shared;

/// <summary>
///     Require assembly and default namespace.
///     Content is referred like with ResourcesH - with fs path
/// </summary>
public class EmbeddedResourcesH //: IResourceHelper
{
    /*usage:
uri = new Uri("Wpf.Tests.Resources.EmbeddedResource.txt", UriKind.Relative);
GetString(uri.ToString()) - the same string as passed in ctor Uri
     */

    /// <summary>
    ///     For entry assembly
    /// </summary>
    internal static EmbeddedResourcesH ci = null;

    /// <summary>
    /// The default namespace.
    /// </summary>
    protected string _defaultNamespace;

    /// <summary>
    /// The entry assembly.
    /// </summary>
    protected Assembly _entryAssembly;

    /// <summary>
    /// Initializes a new instance of the embedded resources h class.
    /// </summary>
    protected EmbeddedResourcesH()
    {
    }

    /// <summary>
    ///     internal to use in assembly like SunamoNTextCat
    ///     A2 is name of project, therefore don't insert typeResourcesSunamo.Namespace
    /// </summary>
    /// <param name="_entryAssembly"></param>
    internal EmbeddedResourcesH(Assembly _entryAssembly, string defaultNamespace)
    {
        this._entryAssembly = _entryAssembly;
        _defaultNamespace = defaultNamespace;
    }

    /// <summary>
    /// The entry assembly.
    /// </summary>
    protected Assembly entryAssembly
    {
        get
        {
            if (_entryAssembly == null) _entryAssembly = Assembly.GetEntryAssembly();
            return _entryAssembly;
        }
    }

    internal string GetResourceName(string name)
    {
        name = string.Join(".", _defaultNamespace,
            name.TrimStart('/').Replace("/", "."));
        return name;
    }

    /// <summary>
    ///     If it's file, return its content
    ///     Its for getting string from file, never from resx or another in code variable
    /// </summary>
    /// <param name="name"></param>
    internal string GetString(string name)
    {
        var stream = GetStream(name);

        return Encoding.UTF8.GetString(FS.StreamToArrayBytes(stream));
    }

    /// <summary>
    ///     Resources/tidy_config.txt (no assembly)
    /// </summary>
    /// <param name="name"></param>
    internal Stream GetStream(string name)
    {
        var resourceName = GetResourceName(name);
        var resourceStream = entryAssembly.GetManifestResourceStream(resourceName);
        return resourceStream;
    }
}