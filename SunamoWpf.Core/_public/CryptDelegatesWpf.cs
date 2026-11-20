namespace SunamoWpf._public;

/// <summary>
/// Represents the crypt delegates wpf type.
/// </summary>
public class CryptDelegatesWpf
{
    /// <summary>
    /// Initializes a new instance of the crypt delegates wpf class.
    /// </summary>
    /// <param name="decryptString">The decrypt string.</param>
    /// <param name="encryptString">The encrypt string.</param>
    public CryptDelegatesWpf(Func<string, string, string?> decryptString, Func<string, string, string?> encryptString)
    {
        this.DecryptString = decryptString;
        this.EncryptString = encryptString;
    }

    /// <summary>
    /// Gets or sets the decrypt string.
    /// </summary>
    public Func<string, string, string?> DecryptString { get; set; }
    /// <summary>
    /// Gets or sets the encrypt string.
    /// </summary>
    public Func<string, string, string?> EncryptString { get; set; }


}