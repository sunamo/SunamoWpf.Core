namespace SunamoWpf.Interfaces;

public interface IInlineBuilder
{
    void Bold(string text);
    void Bullet(string text);
    void Error(string text);
    void H1(string text);
    void H1(string text, double maxWidth);
    void H2(string text);
    void H3(string text);
    void Hyperlink(string text, string uri);
    void Italic(string text);
    void KeyValue(string key, string value);
    void LineBreak();
    void Run(string text);
}