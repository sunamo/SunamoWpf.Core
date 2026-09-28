namespace SunamoWpf.Interfaces;

public interface IUserControlStateChanging<T>
{
     event Action<T> StateChanged;
}