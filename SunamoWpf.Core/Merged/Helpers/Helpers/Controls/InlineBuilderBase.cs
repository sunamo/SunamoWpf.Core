#define ASYNC
namespace SunamoWpf.Helpers.Controls;

/// <summary>
/// Věrná kopie z apps, všechny věci jež nejsou ve WPF josu nahrazené WPF ekvivalentem
/// Bohužel nefunguje jako odkazy, zobrazí se pouze neklikatelný text
/// </summary>
public class InlineBuilderBase : ITextBlockHelperBase<FontWeight, Italic, Inline, Bold, Run, Hyperlink, FontArgs>
{
    /// <summary>
    /// The texts.
    /// </summary>
    protected List<MeasureStringArgs> texts = new List<MeasureStringArgs>();

    /// <summary>
    /// Get font weight.
    /// </summary>
    /// <param name="fontWeight">The font weight.</param>
    /// <returns>The get font weight result.</returns>
    public FontWeight GetFontWeight(Enums.FontWeights fontWeight)
    {
        FontWeight weight = FontWeight.FromOpenTypeWeight((int)fontWeight);
        return weight;
    }

    /// <summary>
    /// Get italic.
    /// </summary>
    /// <param name="run">The run.</param>
    /// <param name="fontArgs">The font args.</param>
    /// <returns>The get italic result.</returns>
    public Italic GetItalic(string run, FontArgs fontArgs)
    {
        Italic italic = new Italic();
        FontArgs fa2 = new FontArgs(fontArgs);
        fontArgs.fontStyle = FontStyles.Italic;
        italic.Inlines.Add(GetRun(run, fontArgs));

        return italic;
    }

    /// <summary>
    /// Get bullet.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <param name="fontArgs">The font args.</param>
    /// <returns>The get bullet result.</returns>
    public Inline GetBullet(string text, FontArgs fontArgs)
    {
        return GetRun("• " + text, fontArgs);
    }

    /// <summary>
    /// Get error.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <param name="fontArgs">The font args.</param>
    /// <returns>The get error result.</returns>
    public Bold GetError(string text, FontArgs fontArgs)
    {
        Bold bold = GetBold(text, fontArgs);
        bold.Foreground = new SolidColorBrush(Colors.Red);
        bold.FontSize += 5;
        return bold;
    }

    /// <summary>
    /// Get bold.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <param name="fontArgs">The font args.</param>
    /// <returns>The get bold result.</returns>
    public Bold GetBold(string text, FontArgs fontArgs)
    {
        Bold bold = new Bold();
        FontArgs fa2 = new FontArgs(fontArgs);
        FontWeight weight = FontWeight.FromOpenTypeWeight(700);
        fa2.fontWeight = weight;
        bold.Inlines.Add(GetRun(text, fa2));
        return bold;
    }

    /// <summary>
    /// Get run.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <param name="fontArgs">The font args.</param>
    /// <returns>The get run result.</returns>
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

    /// <summary>
    /// Get hyperlink.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <param name="uri">The uri.</param>
    /// <param name="fontArgs">The font args.</param>
    /// <returns>The get hyperlink result.</returns>
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