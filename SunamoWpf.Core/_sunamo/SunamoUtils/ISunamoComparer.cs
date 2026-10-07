#define ASYNC
namespace SunamoWpf.Core._sunamo;

internal interface ISunamoComparer<T>
{
    int Desc(T left, T right);
    int Asc(T left, T right);
}
