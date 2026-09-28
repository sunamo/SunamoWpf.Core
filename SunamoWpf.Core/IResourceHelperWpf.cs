namespace SunamoWpf;

public interface IResourceHelperWpf
{
    string GetString(string name);
    Stream GetStream(string name);
}