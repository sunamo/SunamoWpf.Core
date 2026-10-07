namespace SunamoWpf.Core._sunamo;

public interface ITextBlockHelperBase<FontWeight, Italic, Inline, Bold, Run, InlineUIContainer, FontArgs>
{
    FontWeight GetFontWeight(Enums.FontWeights fontWeight);
    Italic GetItalic(string run, FontArgs fontArgs);
    Inline GetBullet(string text, FontArgs fontArgs);
    Bold GetError(string text, FontArgs fontArgs);
    Bold GetBold(string text, FontArgs fontArgs);
    Run GetRun(string text, FontArgs fontArgs);
    InlineUIContainer GetHyperlink(string text, string uri, FontArgs fontArgs);
}