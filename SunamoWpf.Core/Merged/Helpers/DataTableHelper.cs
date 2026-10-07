#define ASYNC
namespace SunamoWpf;

public class DataTableHelper
{
    public static void NewColumn(DataTable dataTable, string name, object type)
    {
        if (!(type is Type))
        {
            type = type.GetType();
        }
        
        DataColumn dataColumn = new DataColumn(name, (Type)type);
        
        dataTable.Columns.Add(dataColumn);
    }

    public static void NewColumn(DataTable dataTable, int columnIndex, IList<string> columns, IList types)
    {
        NewColumn(dataTable, columns[columnIndex], types[columnIndex]);
    }

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