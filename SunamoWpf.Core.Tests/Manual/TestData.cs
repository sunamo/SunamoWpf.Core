/// <summary>
/// Minimal test data for manual UI tests (replacement of the former TestValues project).
/// </summary>
public static class TestData
{
    /// <summary>List of 10 sample items.</summary>
    public static readonly List<string> list10Items = Enumerable.Range(0, 10).Select(i => "Item " + i).ToList();

    /// <summary>List of 12 sample items.</summary>
    public static readonly List<string> list12 = Enumerable.Range(0, 12).Select(i => "Item " + i).ToList();

    /// <summary>List of 59 sample items.</summary>
    public static readonly List<string> list59 = Enumerable.Range(0, 59).Select(i => "Item " + i).ToList();

    /// <summary>List of sample items for the second combo box.</summary>
    public static readonly List<string> listAB1 = new List<string> { "A", "B" };

    /// <summary>List of 100 sample items.</summary>
    public static readonly List<string> list100Items = Enumerable.Range(0, 100).Select(i => "Item " + i).ToList();
}
