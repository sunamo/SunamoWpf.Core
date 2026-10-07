namespace SunamoWpf.Core._sunamo;

internal interface IValidateControl
{
    bool Validated { get; set; }
    bool Validate(object textBox, object control, ref ValidateDataWpf validateData);
    bool Validate(object tbFolder, ref ValidateDataWpf validateData);

    /// <returns></returns>
    object GetContent();
}