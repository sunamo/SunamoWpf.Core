namespace SunamoWpf.Data;

public class TWithSizeInString<T>
{
    public string sizeS = "";
    public T t = default;

    public override string ToString()
    {
        return t + " (" + sizeS + ")";
    }
}