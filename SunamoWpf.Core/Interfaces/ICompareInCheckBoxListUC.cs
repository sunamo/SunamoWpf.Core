namespace SunamoWpf.Interfaces;

public interface ICompareInCheckBoxListUC
{
#if ASYNC
    Task
#else
    void  
#endif
Init(string autoYes, string manuallyYes, string manuallyNo, string autoNo);
}