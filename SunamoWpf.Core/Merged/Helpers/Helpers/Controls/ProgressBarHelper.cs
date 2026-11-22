#define ASYNC
namespace SunamoWpf.Helpers.Controls;

/// <summary>
/// Represents the progress bar helper type.
/// </summary>
public class ProgressBarHelper
{
    ProgressBar pb = null;
    PercentCalculator percentCalculator;
    UIElement ui = null;
    /// <summary>
    /// Create instance.
    /// </summary>
    /// <param name="progressBar">The progress bar.</param>
    /// <param name="overall">The overall.</param>
    /// <returns>The create instance result.</returns>
    public ProgressBarHelper CreateInstance(object progressBar, double overall)
    {
        return new ProgressBarHelper(progressBar, overall, ui);
    }
    /// <summary>
    /// Initializes a new instance of the progress bar helper class.
    /// </summary>
    /// <param name="progressBar">The progress bar.</param>
    /// <param name="overall">The overall.</param>
    /// <param name="element">The element.</param>
    public ProgressBarHelper(object progressBar, double overall, object element)
    {
        var pb2 = (ProgressBar)progressBar;
        var ui2 = (DispatcherObject)element;
        this.pb = pb2;
        this.ui = pb2;
        ui2.Dispatcher.Invoke(IH.delegateUpdateProgressBarWpf, progressBar, 0d);
        ui2.Dispatcher.Invoke(IH.delegateChangeVisibilityUIElementWpf, progressBar, Visibility.Visible);
        percentCalculator = new PercentCalculator(overall);
    }
    /// <summary>
    /// Done.
    /// </summary>
    public void Done()
    {
        ui.Dispatcher.Invoke(IH.delegateUpdateProgressBarWpf, pb, 100d);
        ui.Dispatcher.Invoke(IH.delegateChangeVisibilityUIElementWpf, pb, Visibility.Collapsed);
    }
    /// <summary>
    /// Done partially.
    /// </summary>
    public void DonePartially()
    {
        percentCalculator.last += percentCalculator.onePercent;
        ui.Dispatcher.Invoke(IH.delegateUpdateProgressBarWpf, pb, percentCalculator.last);
    }
}