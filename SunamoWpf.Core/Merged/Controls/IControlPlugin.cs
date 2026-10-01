#define ASYNC
namespace SunamoWpf.Interfaces;

public interface IControlPlugin
{
    List<SuMenuItem> RootUc { get; }
    SuMenuItem MiUc { get; }
}