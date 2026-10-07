namespace SunamoWpf._public;

public interface IControlWithResultDebugWpf : IControlWithResultWpf
{
    int CountOfHandlersChangeDialogResult();
    void AttachChangeDialogResult(VoidBoolNullable handler, bool throwException = true);
}