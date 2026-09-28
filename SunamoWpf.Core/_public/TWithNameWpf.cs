namespace SunamoWpf._public;

public class TWithNameWpf
{
    public static TWithNameTWpf<object> Get(string nameCb)
    {
        return new TWithNameTWpf<object> { name = nameCb };
    }
}