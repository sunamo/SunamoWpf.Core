#define ASYNC
namespace SunamoWpf.Helpers.Controls;

/// <summary>
/// Represents the data grid helper type.
/// </summary>
public static class DataGridHelper
{
    /// <summary>
    /// New text column.
    /// </summary>
    /// <param name="header">The header.</param>
    /// <param name="bindingPath">The binding path.</param>
    /// <returns>The new text column result.</returns>
    public static DataGridColumn NewTextColumn(string header, string bindingPath)
    {
        DataGridTextColumn column = new DataGridTextColumn();
        column.Header = header;
        column.Binding = new Binding(bindingPath);
        return column;
    }

    /// <summary>
    /// New check box column.
    /// </summary>
    /// <param name="header">The header.</param>
    /// <param name="bindingPath">The binding path.</param>
    /// <returns>The new check box column result.</returns>
    public static DataGridColumn NewCheckBoxColumn(string header, string bindingPath)
    {
        DataGridCheckBoxColumn column = new DataGridCheckBoxColumn();
        column.Header = header;
        column.Binding = new Binding(bindingPath);

        return column;
    }

    /// <summary>
    /// Get cell.
    /// </summary>
    /// <param name="dataGrid1">The data grid 1.</param>
    /// <param name="row">The row.</param>
    /// <param name="column">The column.</param>
    /// <returns>The get cell result.</returns>
    public static DataGridCell GetCell(DataGrid dataGrid1, int row, int column)
    {
        DataGridRow rowContainer = GetRow(dataGrid1, row);

        if (rowContainer != null)
        {
            DataGridCellsPresenter presenter = GetVisualChild<DataGridCellsPresenter>(rowContainer);

            DataGridCell cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(column);
            if (cell == null)
            {
                dataGrid1.ScrollIntoView(rowContainer, dataGrid1.Columns[column]);
                cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(column);
            }
            return cell;
        }
        return null;
    }

    /// <summary>
    /// Get row.
    /// </summary>
    /// <param name="dataGrid1">The data grid 1.</param>
    /// <param name="index">The index.</param>
    /// <returns>The get row result.</returns>
    public static DataGridRow GetRow(DataGrid dataGrid1, int index)
    {
        if (dataGrid1.ItemContainerGenerator.Status == GeneratorStatus.NotStarted)
        {
            dataGrid1.UpdateLayout();
        }

        DataGridRow row = (DataGridRow)dataGrid1.ItemContainerGenerator.ContainerFromIndex(index);
        if (row == null)
        {
            ;
            dataGrid1.ScrollIntoView(dataGrid1.Items[index]);
            row = (DataGridRow)dataGrid1.ItemContainerGenerator.ContainerFromIndex(index);
        }
        return row;
    }

    /// <summary>
    /// Get visual child t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="parent">The parent.</param>
    /// <returns>The get visual child t result.</returns>
    public static T GetVisualChild<T>(Visual parent) where T : Visual
    {
        T child = default;
        int numVisuals = VisualTreeHelper.GetChildrenCount(parent);
        for (int index = 0; index < numVisuals; index++)
        {
            Visual visual = (Visual)VisualTreeHelper.GetChild(parent, index);
            child = visual as T;
            if (child == null)
            {
                child = GetVisualChild<T>(visual);
            }
            if (child != null)
            {
                break;
            }
        }
        return child;
    }

    /// <summary>
    /// To A1 is transmit eg. DataGridRow.CurrentCell
    /// </summary>
    /// <param name="cell"></param>
    public static object GetCellValue(DataGridCellInfo cell)
    {
        var boundItem = cell.Item;
        var binding = new Binding();
        if (cell.Column is DataGridTextColumn)
        {
            binding
              = ((DataGridTextColumn)cell.Column).Binding
                    as Binding;
        }
        else if (cell.Column is DataGridCheckBoxColumn)
        {
            binding
              = ((DataGridCheckBoxColumn)cell.Column).Binding
                    as Binding;
        }
        else if (cell.Column is DataGridComboBoxColumn)
        {
            binding
                = ((DataGridComboBoxColumn)cell.Column).SelectedValueBinding
                     as Binding;

            if (binding == null)
            {
                binding
                  = ((DataGridComboBoxColumn)cell.Column).SelectedItemBinding
                       as Binding;
            }
        }

        if (binding != null)
        {
            var propertyName = binding.Path.Path;
            var propInfo = boundItem.GetType().GetProperty(propertyName);
            return propInfo.GetValue(boundItem, new object[] { });
        }

        return null;
    }

    /// <summary>
    /// Get cell value as string.
    /// </summary>
    /// <param name="dataGridCellInfo">The data grid cell info.</param>
    /// <returns>The get cell value as string result.</returns>
    public static string GetCellValueAsString(DataGridCellInfo dataGridCellInfo)
    {
        object value = GetCellValue(dataGridCellInfo);
        if (value == null)
        {
            return "";
        }
        return value.ToString();
    }

    /// <summary>
    /// Get data grid rows.
    /// </summary>
    /// <param name="dataGrid">The data grid.</param>
    /// <returns>The get data grid rows result.</returns>
    public static List<DataGridRow> GetDataGridRows(DataGrid dataGrid)
    {
        if (dataGrid.ItemContainerGenerator.Status == GeneratorStatus.NotStarted)
        {
            dataGrid.UpdateLayout();
        }
        List<DataGridRow> result = new List<DataGridRow>();
        for (int index = 0; index < dataGrid.Items.Count; index++)
        {
            var container = dataGrid.ItemContainerGenerator.ContainerFromIndex(index);



            if (container == null)
            {
                // These 2 lines help get all DataGridRow but wont work if is working with templates (like checkbox)
                //dataGrid.UpdateLayout();
                //dataGrid.ScrollIntoView(dataGrid.Items[i]);
                container = dataGrid.ItemContainerGenerator.ContainerFromIndex(index);
            }


            DataGridRow row = (DataGridRow)container;
            result.Add(row);
        }
        return result;
    }

    /// <summary>
    /// Add rows.
    /// </summary>
    /// <param name="dtGrid">The dt grid.</param>
    /// <param name="list">The list.</param>
    /// <param name="rows">The rows.</param>
    /// <param name="columns">The columns.</param>
    public static void AddRows(DataGrid dtGrid, /*List<object> list,*/ List<IList> rows, params string[] columns)
    {
        foreach (var item in columns)
        {
            dtGrid.Columns.Add(NewTextColumn(item, null));
        }

        dtGrid.ItemsSource = rows;
    }

    /// <summary>
    /// Enable sorting.
    /// </summary>
    /// <param name="dtGrid">The dt grid.</param>
    /// <param name="enabled">The enabled.</param>
    public static void EnableSorting(DataGrid dtGrid, bool enabled)
    {
        dtGrid.CanUserSortColumns = enabled;
        foreach (var item in dtGrid.Columns)
        {
            item.CanUserSort = enabled;
        }
    }

    /// <summary>
    /// Sort data grid.
    /// </summary>
    /// <param name="dataGrid">The data grid.</param>
    /// <param name="column">The column.</param>
    /// <param name="sortDirection">The sort direction.</param>
    public static void SortDataGrid(DataGrid dataGrid, DataGridColumn column, ListSortDirection? sortDirection)
    {
        // Clear current sort descriptions
        dataGrid.Items.SortDescriptions.Clear();

        var sortDirection2 = ListSortDirection.Ascending;

        if (sortDirection.HasValue)
        {
            sortDirection2 = sortDirection.Value;
        }

        // Add the new sort description
        dataGrid.Items.SortDescriptions.Add(new SortDescription(column.SortMemberPath, sortDirection2));

        // Apply sort
        foreach (var col in dataGrid.Columns)
        {
            col.SortDirection = null;
        }
        column.SortDirection = sortDirection;

        // Refresh items to display sort
        dataGrid.Items.Refresh();
    }
}