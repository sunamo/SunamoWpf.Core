namespace SunamoWpf._public;

/// <summary>
///     Error/Warning are in tbLastErrorOrWarning, other in tbLastOtherMessage
///     Musí být zde kvůli cl které je withoutDep
/// </summary>
public enum TypeOfMessageWpf
{
    /// <summary>
    ///     tbLastErrorOrWarning
    /// </summary>
    Error,

    /// <summary>
    ///     tbLastErrorOrWarning
    /// </summary>
    Warning,
    /// <summary>
    /// The information value.
    /// </summary>
    Information,

    /// <summary>
    ///     Returned if from text cant determine value
    /// </summary>
    Ordinal,
    /// <summary>
    /// The appeal value.
    /// </summary>
    Appeal,
    /// <summary>
    /// The success value.
    /// </summary>
    Success
}