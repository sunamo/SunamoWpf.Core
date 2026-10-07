#define ASYNC
namespace SunamoWpf.Helpers.Controls;

public class ProgressBarHelper
{
    ProgressBar pb = null;
    PercentCalculator percentCalculator;
    UIElement ui = null;
    public ProgressBarHelper CreateInstance(object progressBar, double overall)
    {
        return new ProgressBarHelper(progressBar, overall, ui);
    }
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
    public void Done()
    {
        ui.Dispatcher.Invoke(IH.delegateUpdateProgressBarWpf, pb, 100d);
        ui.Dispatcher.Invoke(IH.delegateChangeVisibilityUIElementWpf, pb, Visibility.Collapsed);
    }
    public void DonePartially()
    {
        percentCalculator.last += percentCalculator.onePercent;
        ui.Dispatcher.Invoke(IH.delegateUpdateProgressBarWpf, pb, percentCalculator.last);
    }
}