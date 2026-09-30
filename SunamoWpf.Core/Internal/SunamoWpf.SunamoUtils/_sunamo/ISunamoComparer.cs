#define ASYNC
namespace SunamoWpf._sunamo;

internal interface ISunamoComparer<T>
{
    int Desc(T x, T y);
    int Asc(T x, T y);
}