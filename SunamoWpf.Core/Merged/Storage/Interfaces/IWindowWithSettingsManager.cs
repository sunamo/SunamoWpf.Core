#define ASYNC
namespace SunamoWpf.Interfaces;

/// <summary>
/// Cant have namespace because in normal and *.web is different file but its use in TwoWayTable in both branches
/// </summary>
    public interface IWindowWithSettingsManager
    {
        /// <summary>
        /// TUList due to FrameworkElement will be as many as have dependency property
        /// </summary>
        //TUList<FrameworkElement, DependencyProperty> SavedElements { get; set; }
        //SettingsManager SettingsManager { get; }
        //void AddSavedElement(FrameworkElement fw, DependencyProperty dp);
        ApplicationDataContainer Data
        {
            get;
        }
    }