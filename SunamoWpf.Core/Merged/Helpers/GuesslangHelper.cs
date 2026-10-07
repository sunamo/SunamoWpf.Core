#define ASYNC
namespace SunamoWpf;

/// <summary>
/// To use Guesslang which require Tensorflow   1.7.0rc1 must be used Python 3.6.x.
/// Is enough pip install guesslang
/// Working badly, for aspx content return SQL
/// </summary>
public class GuesslangHelper
{
    public static
#if ASYNC
    async Task<string>
#else
    string
#endif
 DetectLanguage(string code)
    {
        var command = "echo \"" + code.Replace("\"", "'") + "\" | guesslang";
        string SourceCode = Translate.FromKey(XlfKeys.TheSourceCodeIsWrittenIn);
        var result =
#if ASYNC
    await
#endif
 PowershellRunner.ci.Invoke(CA.ToListString(command));
        foreach (var item in result[0])
        {
            if (item.Contains(SourceCode))
            {
                var result2 = SH.TextAfter(item, SourceCode);
                return result2;
            }
        }
        return null;
    }
    public static void GenerateDictionaryForMapToTextBoxSyntax(Func<Dictionary<string, string>, string> CSharpHelperGetDictionaryValuesFromDictionary)
    {
        string File = @"C:\Program Files\Python36\Lib\site-packages\guesslang\data\languages.json";
        var content = TF.ReadAllText(File);
        //TextReader tr = TF.TextReader(File);
        //JsonTextReader js = new JsonTextReader(tr);
        //dynamic son = JsonConvert.DeserializeObject(s);
        dynamic son = new object(); //JsonNewtonSoft.instance.Deserialize(s);
        Dictionary<string, string> result = new Dictionary<string, string>();
        foreach (var item in son)
        {
            var name = item.Name;
            result.Add(name, string.Empty);
        }
        var output = CSharpHelperGetDictionaryValuesFromDictionary(result);
        ClipboardService.SetText(output);
    }
}