namespace SunamoWpf._sunamo;

internal interface IValidateControl
{
    bool Validated { get; set; }
    bool Validate(object tb, object control, ref ValidateDataWpf d);
    bool Validate(object tbFolder, ref ValidateDataWpf d);

    /// <returns></returns>
    object GetContent();
}