#define ASYNC
namespace SunamoWpf;

/// <summary>
/// Represents the data table helper type.
/// </summary>
public class DataTableHelper
{
    /// <summary>
    /// New column.
    /// </summary>
    /// <param name="dataTable">The data table.</param>
    /// <param name="name">The name.</param>
    /// <param name="type">The type.</param>
    public static void NewColumn(DataTable dataTable, string name, object type)
    {
        if (!(type is Type))
        {
            type = type.GetType();
        }
        
        DataColumn dataColumn = new DataColumn(name, (Type)type);
        
        dataTable.Columns.Add(dataColumn);
    }

    /// <summary>
    /// New column.
    /// </summary>
    /// <param name="dataTable">The data table.</param>
    /// <param name="columnIndex">The column index.</param>
    /// <param name="columns">The columns.</param>
    /// <param name="types">The types.</param>
    public static void NewColumn(DataTable dataTable, int columnIndex, IList<string> columns, IList types)
    {
        NewColumn(dataTable, columns[columnIndex], types[columnIndex]);
    }

    /// <summary>
    /// Create data table.
    /// </summary>
    /// <param name="defaultValue">The default value.</param>
    /// <param name="rows">The rows.</param>
    /// <param name="columns">The columns.</param>
    /// <returns>The create data table result.</returns>
    public static DataTable CreateDataTable(List<object> defaultValue, List<IList> rows, params string[] columns)
    {
        DataTable dataTable = new DataTable();

        for (int index = 0; index < columns.Count(); index++)
        {
            NewColumn(dataTable, index, columns, defaultValue);
        }

        foreach (var item in rows)
        {
            var row = dataTable.NewRow();
            for (int columnIndex = 0; columnIndex < columns.Length; columnIndex++)
            {
                row[columns[columnIndex]] = item[columnIndex];
            }

            dataTable.Rows.Add(row);
        }

        return dataTable;
    }
}