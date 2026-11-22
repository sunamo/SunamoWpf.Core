namespace SunamoWpf;

/// <summary>
/// Must be in SunamoWpf because use Key
/// </summary>
public class HotKey : IDisposable
{
    private static Dictionary<int, HotKey> _dictHotKeyToCalBackProc;

    [DllImport("user32.dll")]
    private static extern bool RegisterHotKey(nint hWnd, int hotKeyId, uint fsModifiers, uint vlc);

    [DllImport("user32.dll")]
    private static extern bool UnregisterHotKey(nint hWnd, int hotKeyId);

    /// <summary>
    /// The wm hot key constant.
    /// </summary>
    public const int WmHotKey = 0x0312;

    private bool _disposed = false;

    /// <summary>
    /// Gets or sets the key.
    /// </summary>
    public Key Key { get; private set; }
    /// <summary>
    /// Gets or sets the key modifiers.
    /// </summary>
    public KeyModifier KeyModifiers { get; private set; }
    /// <summary>
    /// Gets or sets the action.
    /// </summary>
    public Action<HotKey> Action { get; private set; }
    /// <summary>
    /// Gets or sets the id.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// The tag.
    /// </summary>
    public object Tag = null;

    //public static void DummyMethod(HotKey h)
    //{

    //}

    // ******************************************************************
    /// <summary>
    /// Initializes a new instance of the hot key class.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <param name="keyModifiers">The key modifiers.</param>
    /// <param name="action">The action.</param>
    /// <param name="register">The register.</param>
    public HotKey(Key key, KeyModifier keyModifiers, Action<HotKey> action, bool register = true)
    {
        Key = key;
        KeyModifiers = keyModifiers;
        Action = action;
        if (register)
        {
            Register();
        }
    }

    // ******************************************************************
    /// <summary>
    /// Register.
    /// </summary>
    /// <returns>The register result.</returns>
    public bool Register()
    {
        int virtualKeyCode = KeyInterop.VirtualKeyFromKey(Key);
        Id = virtualKeyCode + (int)KeyModifiers * 0x10000;
        bool result = RegisterHotKey(nint.Zero, Id, (uint)KeyModifiers, (uint)virtualKeyCode);

        if (_dictHotKeyToCalBackProc == null)
        {
            _dictHotKeyToCalBackProc = new Dictionary<int, HotKey>();
            ComponentDispatcher.ThreadFilterMessage += new ThreadMessageEventHandler(ComponentDispatcherThreadFilterMessage);
        }

        _dictHotKeyToCalBackProc.Add(Id, this);

        return result;
    }

    // ******************************************************************
    /// <summary>
    /// Unregister.
    /// </summary>
    public void Unregister()
    {
        HotKey hotKey;
        if (_dictHotKeyToCalBackProc.TryGetValue(Id, out hotKey))
        {
            UnregisterHotKey(nint.Zero, Id);
        }
    }

    // ******************************************************************
    private static void ComponentDispatcherThreadFilterMessage(ref MSG msg, ref bool handled)
    {
        if (!handled)
        {
            if (msg.message == WmHotKey)
            {
                HotKey hotKey;

                if (_dictHotKeyToCalBackProc.TryGetValue((int)msg.wParam, out hotKey))
                {
                    if (hotKey.Action != null)
                    {
                        hotKey.Action.Invoke(hotKey);
                    }
                    handled = true;
                }
            }
        }
    }

    // ******************************************************************
    // Implement IDisposable.
    // Do not make this method virtual.
    // A derived public class should not be able to override this method.
    /// <summary>
    /// Dispose.
    /// </summary>
    public void Dispose()
    {
        Dispose(true);
        // This object will be cleaned up by the Dispose method.
        // Therefore, you should call GC.SupressFinalize to
        // take this object off the finalization queue
        // and prevent finalization code for this object
        // from executing a second time.
        GC.SuppressFinalize(this);
    }

    // ******************************************************************
    // Dispose(bool disposing) executes in two distinct scenarios.
    // If disposing equals true, the method has been called directly
    // or indirectly by a user's code. Managed and unmanaged resources
    // can be _disposed.
    // If disposing equals false, the method has been called by the
    // runtime from inside the finalizer and you should not reference
    // other objects. Only unmanaged resources can be _disposed.
    /// <summary>
    /// Dispose.
    /// </summary>
    /// <param name="disposing">The disposing.</param>
    protected virtual void Dispose(bool disposing)
    {
        // Check to see if Dispose has already been called.
        if (!_disposed)
        {
            // If disposing equals true, dispose all managed
            // and unmanaged resources.
            if (disposing)
            {
                // Dispose managed resources.
                Unregister();
            }

            // Note disposing has been done.
            _disposed = true;
        }
    }
}

// ******************************************************************
/// <summary>
/// Represents the key modifier type.
/// </summary>
[Flags]
public enum KeyModifier
{
    /// <summary>
    /// The none value.
    /// </summary>
    None = 0x0000,
    /// <summary>
    /// The alt value.
    /// </summary>
    Alt = 0x0001,
    /// <summary>
    /// The ctrl value.
    /// </summary>
    Ctrl = 0x0002,
    /// <summary>
    /// The no repeat value.
    /// </summary>
    NoRepeat = 0x4000,
    /// <summary>
    /// The shift value.
    /// </summary>
    Shift = 0x0004,
    /// <summary>
    /// The win value.
    /// </summary>
    Win = 0x0008
}

// ******************************************************************