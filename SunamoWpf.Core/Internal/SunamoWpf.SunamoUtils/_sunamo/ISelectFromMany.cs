#define ASYNC
namespace SunamoWpf._sunamo;

internal interface ISelectFromMany<Data>
{
    void AddControl(Data data, bool b);
    void AddControls();
}