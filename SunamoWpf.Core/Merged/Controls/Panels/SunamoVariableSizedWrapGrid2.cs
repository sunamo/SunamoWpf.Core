#define ASYNC
namespace SunamoWpf.Controls.Panels;

public class SunamoVariableSizedWrapGrid2 : Panel
{
    private Dictionary<int, Dictionary<int, UIElement>> controls = new Dictionary<int, Dictionary<int, UIElement>>();
    public SunamoVariableSizedWrapGrid2()
    {

    }

    protected override int VisualChildrenCount
    {
        get
        {
            int result = 0;

            foreach (KeyValuePair<int, Dictionary<int, UIElement>> item in controls)
            {
                result += item.Value.Count;

            }
            return result;
        }
    }

    static Type type = typeof(SunamoVariableSizedWrapGrid2);

    protected override Visual GetVisualChild(int index)
    {
        if (index >= VisualChildrenCount)
        {
            ThrowEx.Custom("bla");
        }

        int childIndex = 0;
        foreach (KeyValuePair<int, Dictionary<int, UIElement>> item in controls)
        {
            foreach (var item2 in item.Value)
            {
                if (childIndex == index)
                {
                    return item2.Value;
                }
                childIndex++;
            }
        }
        ThrowEx.NotImplementedMethod();
        return null;
    }

    protected override Size MeasureOverride(Size availableSize)
    {
        double width = 0;
        double height = 0;
        double secondWidth = 0;
        double secondHeight = 0;
        for (int index = 0; index < InternalChildren.Count; index++)
        {

            UIElement item = InternalChildren[index];
            if (IsFirst(item))
            {
                secondWidth = 0;
                secondHeight = 0;
            }
            item.Measure(availableSize);
            secondWidth = item.DesiredSize.Width;
            if (secondHeight < item.DesiredSize.Height)
            {
                secondHeight = item.DesiredSize.Height;
            }
            //}
            if (IsLast(item))
            {
                if (width < secondWidth)
                {
                    width = secondWidth;
                }
                height += secondHeight;
            }
        }
        //return availableSize;
        return new Size(width, height);
        //return base.MeasureOverride(availableSize);
    }

    private bool IsLast(UIElement item3)
    {
        foreach (var item in controls)
        {
            UIElement element = null;
            foreach (var item2 in item.Value)
            {
                element = item2.Value;
            }
            if (element == item3)
            {
                return true;

            }
            break;
        }
        return false;
    }

    private bool IsFirst(UIElement item3)
    {
        foreach (var item in controls)
        {
            foreach (var item2 in item.Value)
            {
                if (item2.Value == item3)
                {
                    return true;

                }
                break;
            }
        }
        return false;
    }

    protected override Size ArrangeOverride(Size finalSize)
    {
        double overallHeight = 0;
        double overallWidth = 0;
        //Size vr = new Size();
        double startHeight = 0;
        double startWidth = 0;
        for (int index = 0; index < InternalChildren.Count; index++)
        {
            var item = InternalChildren[index];
            if (IsFirst(item))
            {
                startHeight = 0;
                startWidth = 0;
            }
            item.Arrange(new Rect(new Point(startWidth, overallHeight), item.DesiredSize));
            item.InvalidateVisual();
            if (item.RenderSize.Height > startHeight)
            {
                startHeight = item.RenderSize.Height;
            }
            startHeight += item.RenderSize.Height;
            startWidth += item.RenderSize.Width;
            //}
            if (IsLast(item))
            {
                if (startWidth > overallWidth)
                {
                    overallWidth = startWidth;
                }
                overallHeight += startHeight;
            }
        }

        return new Size(overallWidth, overallHeight);
        //return base.ArrangeOverride(finalSize);
    }

    void SunamoVariableSizedWrapGrid_SizeChanged(object sender, SizeChangedEventArgs sizeInfo)
    {
        //base.OnRenderSizeChanged(sizeInfo);
        bool start = false;
        if (controls.Count == 0)
        {
            Dictionary<int, UIElement> result = new Dictionary<int, UIElement>();
            controls.Add(0, result);
            StackPanel stackPanel = new StackPanel();
            stackPanel.SizeChanged += sp_SizeChanged;
            //sps.Add(0, sp);
            Children.Insert(0, stackPanel);
            int index = 0;
            foreach (UIElement item in ((StackPanel)Children[0]).Children)
            {
                result.Add(index, item);
                RemoveLogicalChild(item);
                RemoveVisualChild(item);

                index++;
            }
            start = true;
        }

        if (start)
        {
            AfterGrowth(sizeInfo.NewSize.Width);
            AfterShrink(sizeInfo.NewSize.Width);
        }
    }

    void sp_SizeChanged(object sender, SizeChangedEventArgs sizeInfo)
    {
        if (sizeInfo.NewSize.Width > sizeInfo.PreviousSize.Width)
        {
            AfterGrowth(sizeInfo.NewSize.Width);
        }
        else
        {
            AfterShrink(sizeInfo.NewSize.Width);
        }
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="growth"></param>
    private void AfterGrowth(double growth)
    {
        for (int index = 0; index < controls.Count; index++)
        {
            int odKterehoMusimOdebrat = -1;
            double widthOfUIElements = GetWidthOfUIElements(controls[index], growth, out odKterehoMusimOdebrat);
            // Zde nevím zda to bude fungovat ta první podmínka
            if (!(odKterehoMusimOdebrat >= controls[index].Count) && odKterehoMusimOdebrat != -1)
            {
                int dexDalsihoSP = index + 1;
                if (IsStackPanelInSeries(dexDalsihoSP))
                {
                    bool zastavit = false;
                    for (int stackPanelIndex = dexDalsihoSP; stackPanelIndex < controls.Count; stackPanelIndex++)
                    {
                        if (controls[stackPanelIndex + 1].Count > 0)
                        {
                            int controlIndex = 0;
                            UIElement control = controls[dexDalsihoSP][controlIndex];
                            double width = GetWidthOfUIElement(control);
                            int odKterehoMusimOdebrat2 = -1;
                            if (width < growth - GetWidthOfUIElements(controls[index], growth, out odKterehoMusimOdebrat2))
                            {
                                controls[dexDalsihoSP].Remove(controlIndex);
                                controls[index].Add(controls[index].Count, control);
                                GetStackPanelOnIndex(dexDalsihoSP).Children.RemoveAt(controlIndex);
                                RemoveLogicalChild(control);
                                RemoveVisualChild(control);
                                GetStackPanelOnIndex(index).Children.Add(control);
                            }
                            // Na konec posuneme indexy všech zbývajících UIElementů
                            if (GetStackPanelOnIndex(dexDalsihoSP).Children.Count == 0)
                            {
                                //sps.Remove(dexDalsihoSP);
                                Children.RemoveAt(dexDalsihoSP);
                                controls.Remove(dexDalsihoSP);
                            }
                            zastavit = true;
                        }
                        if (zastavit)
                        {
                            break;
                        }
                    }
                }
            }
        }
    }

    private bool IsStackPanelInSeries(int dexDalsihoSP)
    {
        return dexDalsihoSP < Children.Count;

    }











    /// <summary>
    ///
    /// </summary>
    /// <param name="shrink"></param>
    private void AfterShrink(double shrink)
    {
        for (int index = 0; index < controls.Count; index++)
        {
            int odKterehoMusimOdebrat = -1;
            double widthOfUIElements = GetWidthOfUIElements(controls[index], shrink, out odKterehoMusimOdebrat);
            if (odKterehoMusimOdebrat != 0 && odKterehoMusimOdebrat != -1)
            {
                List<UIElement> removed = new List<UIElement>();
                for (int controlIndex = controls.Count; controlIndex >= odKterehoMusimOdebrat; controlIndex--)
                {
                    removed.Add(controls[index][controlIndex]);
                    controls[index].Remove(controlIndex);

                }
                int vkladatDo = index + 1;
                if (!IsStackPanelInSeries(vkladatDo))
                {
                    //sps.Add(vkladatDo, new StackPanel());
                    Children.Insert(vkladatDo, new StackPanel());
                    controls.Add(vkladatDo, new Dictionary<int, UIElement>());
                }
                int removedCount = 0;
                for (int removedIndex = odKterehoMusimOdebrat - 1; removedIndex >= 0; removedIndex--)
                {
                    RemoveLogicalChild(removed[removedIndex]);
                    RemoveVisualChild(removed[removedIndex]);
                    //sps.Remove(y);
                    StackPanel stackPanel = GetStackPanelOnIndex(index);
                    stackPanel.Children.Remove(removed[removedIndex]);
                    GetStackPanelOnIndex(vkladatDo).Children.Insert(removedIndex, removed[removedIndex]);
                    if (!controls.ContainsKey(vkladatDo))
                    {
                        controls.Add(vkladatDo, new Dictionary<int, UIElement>());
                    }
                    removedCount = removedIndex * -1 + 1;
                    controls[vkladatDo].Add(removedCount, removed[index]);
                }
                for (int unusedIndex = 0; unusedIndex < removed.Count; unusedIndex++)
                {

                }
                // A nyní musím všechny indexy posunout
                removedCount = Math.Abs(removedCount);
                if (removedCount != 1)
                {
                    for (int sourceIndex = controls[vkladatDo].Count - 1; sourceIndex >= removedCount; sourceIndex--)
                    {
                        controls[vkladatDo].Add(sourceIndex + removedCount, controls[vkladatDo][sourceIndex]);
                        controls[vkladatDo].Remove(sourceIndex);
                    }
                }
            }
        }
    }

    private StackPanel GetStackPanelOnIndex(int index)
    {
        return (StackPanel)Children[index];
    }

    private double GetWidthOfUIElements(Dictionary<int, UIElement> dictionary, double maxWidth, out int odKterehoMusimOdebrat)
    {
        odKterehoMusimOdebrat = -1;
        double result = 0;
        int count = 0;
        foreach (var item in dictionary)
        {
            result += GetWidthOfUIElement(item.Value);
            if (result >= maxWidth)
            {
                odKterehoMusimOdebrat = count;
            }
            count++;
        }
        return result;
    }

    private double GetWidthOfUIElement(UIElement control)
    {
        double left = 0;
        if (control is FrameworkElement)
        {
            FrameworkElement control2 = control as FrameworkElement;
            left = control2.Margin.Left;
        }
        if (control is Control)
        {
            Control control2 = control as Control;
            left += control2.Padding.Left;
        }
        double right = 0;
        if (control is FrameworkElement)
        {
            FrameworkElement control2 = control as FrameworkElement;
            right = control2.Margin.Left;
        }
        if (control is Control)
        {
            Control control2 = control as Control;
            right += control2.Padding.Right;
        }
        return left + control.RenderSize.Width + right;

    }
}