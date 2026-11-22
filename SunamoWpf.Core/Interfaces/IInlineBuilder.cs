namespace SunamoWpf.Interfaces;

/// <summary>
/// Represents the i inline builder type.
/// </summary>
public interface IInlineBuilder
{
    /// <summary>
    /// Bold.
    /// </summary>
    /// <param name="text">The text.</param>
    void Bold(string text);
    /// <summary>
    /// Bullet.
    /// </summary>
    /// <param name="text">The text.</param>
    void Bullet(string text);
    /// <summary>
    /// Error.
    /// </summary>
    /// <param name="text">The text.</param>
    void Error(string text);
    /// <summary>
    /// H 1.
    /// </summary>
    /// <param name="text">The text.</param>
    void H1(string text);
    /// <summary>
    /// H 1.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <param name="maxWidth">The max width.</param>
    void H1(string text, double maxWidth);
    /// <summary>
    /// H 2.
    /// </summary>
    /// <param name="text">The text.</param>
    void H2(string text);
    /// <summary>
    /// H 3.
    /// </summary>
    /// <param name="text">The text.</param>
    void H3(string text);
    /// <summary>
    /// Hyperlink.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <param name="uri">The uri.</param>
    void Hyperlink(string text, string uri);
    /// <summary>
    /// Italic.
    /// </summary>
    /// <param name="text">The text.</param>
    void Italic(string text);
    /// <summary>
    /// Key value.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <param name="value">The value.</param>
    void KeyValue(string key, string value);
    /// <summary>
    /// Line break.
    /// </summary>
    void LineBreak();
    /// <summary>
    /// Run.
    /// </summary>
    /// <param name="text">The text.</param>
    void Run(string text);
}