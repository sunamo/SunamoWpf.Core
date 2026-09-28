namespace SunamoWpf._public;

public class CryptDelegatesWpf
{
    public CryptDelegatesWpf(Func<string, string, string?> decryptString, Func<string, string, string?> encryptString)
    {
        this.DecryptString = decryptString;
        this.EncryptString = encryptString;
    }

    public Func<string, string, string?> DecryptString { get; set; }
    public Func<string, string, string?> EncryptString { get; set; }


}