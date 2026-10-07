#define ASYNC
namespace SunamoWpf.Helpers.Controls;

/// <summary>
/// Věrná kopie z apps, všechny věci jež nejsou ve WPF josu nahrazené WPF ekvivalentem
/// Bohužel nefunguje jako odkazy, zobrazí se pouze neklikatelný text
/// </summary>
public class InlineBuilderBase : ITextBlockHelperBase<FontWeight, Italic, Inline, Bold, Run, Hyperlink, FontArgs>
{
    protected List<MeasureStringArgs> texts = new List<MeasureStringArgs>();

    public FontWeight GetFontWeight(Enums.FontWeights fontWeight)
    {
        FontWeight weight = FontWeight.FromOpenTypeWeight((int)fontWeight);
        return weight;
    }

    public Italic GetItalic(string run, FontArgs fontArgs)
    {
        Italic italic = new Italic();
        FontArgs fa2 = new FontArgs(fontArgs);
        fontArgs.fontStyle = FontStyles.Italic;
        italic.Inlines.Add(GetRun(run, fontArgs));

        return italic;
    }

    public Inline GetBullet(string text, FontArgs fontArgs)
    {
        return GetRun("• " + text, fontArgs);
    }

    public Bold GetError(string text, FontArgs fontArgs)
    {
        Bold bold = GetBold(text, fontArgs);
        bold.Foreground = new SolidColorBrush(Colors.Red);
        bold.FontSize += 5;
        return bold;
    }

    public Bold GetBold(string text, FontArgs fontArgs)
    {
        Bold bold = new Bold();
        FontArgs fa2 = new FontArgs(fontArgs);
        FontWeight weight = FontWeight.FromOpenTypeWeight(700);
        fa2.fontWeight = weight;
        bold.Inlines.Add(GetRun(text, fa2));
        return bold;
    }

    public Run GetRun(string text, FontArgs fontArgs)
    {
        Run run = new Run();
        run.FontFamily = fontArgs.fontFamily;
        run.FontSize = fontArgs.fontSize;
        run.FontStretch = fontArgs.fontStretch;
        run.FontStyle = fontArgs.fontStyle;
        run.FontWeight = fontArgs.fontWeight;
        run.Text = text;

        texts.Add(new MeasureStringArgs(run.FontFamily, run.FontSize, run.FontStyle, run.FontStretch, run.FontWeight, run.Text));
        return run;
    }

    public Hyperlink GetHyperlink(string text, string uri, FontArgs fontArgs)
    {
        // In WPF is not needed put it in subs. control like Label

        Hyperlink link = new Hyperlink(GetRun(text, fontArgs));
        link.NavigateUri = new Uri(uri);
        link.RequestNavigate += Link_RequestNavigate;

        return link;
    }

    private void Link_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs eventArgs)
    {
        Process.Start(new ProcessStartInfo(eventArgs.Uri.AbsoluteUri));
        eventArgs.Handled = true;
    }


}