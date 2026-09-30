#define ASYNC
namespace SunamoWpf.Core._sunamo;

internal interface ISelectFromMany<Data>
{
    void AddControl(Data data, bool b);
    void AddControls();
}
