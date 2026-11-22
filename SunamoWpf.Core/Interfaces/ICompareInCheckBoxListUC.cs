namespace SunamoWpf.Interfaces;

/// <summary>
/// Represents the i compare in check box list UC type.
/// </summary>
public interface ICompareInCheckBoxListUC
{
    /// <summary>
    /// Initializes the control from four files with lines for the auto yes, manually yes, manually no and auto no lists.
    /// </summary>
    Task Init(string autoYes, string manuallyYes, string manuallyNo, string autoNo);
}