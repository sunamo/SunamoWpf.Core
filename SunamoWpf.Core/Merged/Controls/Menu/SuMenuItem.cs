#define ASYNC
namespace SunamoWpf.Controls.Menu;

public class SuMenuItem : MenuItem
{
    public bool onClick = false;

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

    public static void CollapseMaybeNotReferenced(params SuMenuItem[] mis)
    {
        foreach (var mi in mis)
        {
            mi.Visibility = Visibility.Collapsed;
        }
    }

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