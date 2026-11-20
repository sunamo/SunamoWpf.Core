#define ASYNC
namespace SunamoWpf.Controls.Controls;

/// <summary>
/// Represents the drop down button type.
/// </summary>
public class DropDownButton : ToggleButton
{
    // *** Dependency Properties *** 

    // *** Constructors *** 
    /// <summary>
    /// Initializes a new instance of the drop down button class.
    /// </summary>
    public DropDownButton()
    {
        // Bind the ToogleButton.IsChecked property to the drop-down's IsOpen property 
        Binding binding = new Binding("Menu.IsOpen");
        binding.Source = this;
        this.SetBinding(IsCheckedProperty, binding);
        DataContextChanged += (sender, args) =>
        {
            if (Menu != null)
                Menu.DataContext = DataContext;
        };
    }

    // *** Properties *** 
    /// <summary>
    /// The menu.
    /// </summary>
    public ContextMenu Menu
    {
        get { return (ContextMenu)GetValue(MenuProperty); }
        set { SetValue(MenuProperty, value); }
    }
    /// <summary>
    /// The menu property.
    /// </summary>
    public static readonly DependencyProperty MenuProperty = DependencyProperty.Register("Menu", typeof(ContextMenu), typeof(DropDownButton), new UIPropertyMetadata(null, OnMenuChanged));

    private static void OnMenuChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
    {
        var dropDownButton = (DropDownButton)dependencyObject;
        var contextMenu = (ContextMenu)eventArgs.NewValue;
        contextMenu.DataContext = dropDownButton.DataContext;
    }


    // *** Overridden Methods *** 
    /// <summary>
    /// On click.
    /// </summary>
    protected override void OnClick()
    {
        if (Menu != null)
        {
            // If there is a drop-down assigned to this button, then position and display it 
            Menu.PlacementTarget = this;
            Menu.Placement = PlacementMode.Bottom;
            Menu.IsOpen = true;
        }
    }
}