#define ASYNC
namespace SunamoWpf._sunamo;

/// <summary>
/// </summary>
[System.Runtime.Versioning.SupportedOSPlatform("windows")]
internal class RA
{
    protected static List<string> valuesInKey;
    protected static RegistryKey m;
    private static bool _initialized = false;
    private static readonly object _lock = new object();

    /// <summary>
    /// EN: Initialize registry access with application name
    /// CZ: Inicializuje přístup do registru s názvem aplikace
    /// </summary>
    public static void Initialize(string applicationName)
    {
        lock (_lock)
        {
            if (_initialized) return;

            //HKEY_LOCAL_MACHINE\SOFTWARE
            var hklm = Registry.CurrentUser;
            var sw = hklm.OpenSubKey("SOFTWARE", true);
            m = sw.OpenSubKey(applicationName, true);
            if (m == null)
            {
                m = sw.CreateSubKey(applicationName);
                valuesInKey = new List<string>();
            }
            else
            {
                valuesInKey = new List<string>(m.GetValueNames());
            }

            _initialized = true;
        }
    }
    /// <summary>
    ///     Abstraktni uz nikdy nedelej, proste musi tu metodu prekryt a oznacit za static a zavolat v statickem konstruktoru,
    ///     pokud chces ji volat ihned pri vytvoreni staticke instance nebo ji chces treba volat v F1.
    ///     Trida vraci string aby jsi ji mohl inicializovat treba A1.
    /// </summary>
    public virtual string CreateDefaultValues()
    {
        return "";
    }
    public static void WriteToKeyInt(string klic, int hodnota)
    {
        m.SetValue(klic, hodnota, RegistryValueKind.DWord);
    }
    public static int ReturnValueInt(string klic)
    {
        int c;
        var o = m.GetValue(klic);
        if (o != null)
            if (int.TryParse(o.ToString(), out c))
                return c;
        return -1;
    }
    /// <summary>
    ///     Pokud klk A1 nebude nalezen, G "".
    /// </summary>
    /// <param name="Login"></param>
    public static string ReturnValueString(string Login)
    {
        return m.GetValue(Login, "", RegistryValueOptions.None).ToString();
    }
    public static void WriteToKeyString(string klic, string hodnota)
    {
        m.SetValue(klic, hodnota, RegistryValueKind.String);
    }
    public static byte[] ReturnValueByteArray(string Login)
    {
        return (byte[])m.GetValue(Login, null, RegistryValueOptions.None);
    }
    public static void WriteToKeyByteArray(string klic, byte[] hodnota)
    {
        m.SetValue(klic, hodnota, RegistryValueKind.Binary);
    }
    public static void SaveToKeyBool(string klic, object hodnota)
    {
        m.SetValue(klic, hodnota.ToString(), RegistryValueKind.String);
    }
    public static bool ReturnValueBool(string klic)
    {
        var s = m.GetValue(klic, "").ToString();
        if (s == "True") return true;
        return false;
    }
}