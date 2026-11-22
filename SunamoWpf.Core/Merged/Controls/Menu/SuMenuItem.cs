#define ASYNC
namespace SunamoWpf.Controls.Menu;

/// <summary>
/// Represents the su menu item type.
/// </summary>
public class SuMenuItem : MenuItem
{
    /// <summary>
    /// The on click.
    /// </summary>
    public bool onClick = false;

    /// <summary>
    /// The click.
    /// </summary>
    public new event RoutedEventHandler Click
    {
        add
        {
            base.Click += value;
            onClick = true;
        }
        remove
        {
            base.Click -= value;
            onClick = false;
        }
    }

    /// <summary>
    /// The click async.
    /// </summary>
    public event RoutedEventHandlerAsync ClickAsync
    {
        add
        {
            throw new Exception("later");
            //base.Click += value;
            //onClick = true;
        }
        remove
        {
            throw new Exception("later");
            //base.Click -= value;
            //onClick = false;
        }
    }

    /// <summary>
    /// Collapse maybe not referenced.
    /// </summary>
    /// <param name="mis">The mis.</param>
    public static void CollapseMaybeNotReferenced(params SuMenuItem[] mis)
    {
        foreach (var menuItem in mis)
        {
            menuItem.Visibility = Visibility.Collapsed;
        }
    }

    /// <summary>
    /// The visibility.
    /// </summary>
    public new Visibility Visibility
    {
        get
        {
            return base.Visibility;
        }
        set
        {
#if DEBUG
            if (Name == "miOpenGitConfigFile")
            {
                if (value != Visibility.Visible)
                {

                }
            }
            if (Name == "miAddSelectedSunamoProjectsToProjects")
            {

            }
#endif
            base.Visibility = value;
        }
    }
}