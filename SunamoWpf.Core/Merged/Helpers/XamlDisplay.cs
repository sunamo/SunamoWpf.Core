#define ASYNC
namespace SunamoWpf;

/// <summary>
/// Represents the i xaml display type.
/// </summary>
public interface IXamlDisplay
{

}

/// <summary>
/// Represents the xaml display type.
/// </summary>
public class XamlDisplay
{
    

    /// <summary>
    /// Get items panel template.
    /// </summary>
    /// <returns>The get items panel template result.</returns>
    public static ItemsPanelTemplate GetItemsPanelTemplate()
    {
        string xaml = @"<ItemsPanelTemplate   xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation' xmlns:x='http://schemas.microsoft.com/winfx/2006/xaml'>
                            <Grid>
                                <Grid.ColumnDefinitions>
                                    <ColumnDefinition />
                                </Grid.ColumnDefinitions>
                                <Grid.RowDefinitions>
                                    <RowDefinition />
                                </Grid.RowDefinitions>
                            </Grid>
                    </ItemsPanelTemplate>";
        return XamlReader.Parse( xaml) as ItemsPanelTemplate;
    }
}