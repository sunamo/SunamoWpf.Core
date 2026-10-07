#define ASYNC
namespace SunamoWpf.Core._sunamo;

internal class ABT<Key, Value>
{
    internal Key A;
    internal Value B;
    internal ABT(Key key, Value value)
    {
        A = key;
        B = value;
    }
    internal ABT()
    {
    }
}
