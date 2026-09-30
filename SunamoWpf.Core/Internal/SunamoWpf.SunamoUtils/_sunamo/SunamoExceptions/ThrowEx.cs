#define ASYNC
namespace SunamoWpf._sunamo.SunamoExceptions;

internal partial class ThrowEx
{
    public static Action<object> showExceptionWindow;
    public static bool reallyThrow2;

    public static bool IsNotTheSame<T>(string name1, T value1, string name2, T value2)
    {
        return ThrowIsNotNull(Exceptions.IsNotTheSame(FullNameOfExecutedCode(), name1, value1, name2, value2));
    }

    public static bool FolderDoesNotExists(string folder, string additionalInfo = "")
    {
        return ThrowIsNotNull(Exceptions.FolderDoesNotExists(FullNameOfExecutedCode(), folder, additionalInfo));
    }

    public static bool KeyAlreadyExists<T, U>(Dictionary<T, U> dictionary, T key, string dictionaryName)
    {
        return ThrowIsNotNull(Exceptions.KeyAlreadyExists(FullNameOfExecutedCode(), dictionary, key, dictionaryName));
    }

    public static bool HasNotIndex<T>(IEnumerable<T> list, string listName, int maxRequiredIndex)
    {
        return ThrowIsNotNull(Exceptions.HasNotIndex(FullNameOfExecutedCode(), list, listName, maxRequiredIndex));
    }

    public static bool ArgumentOutOfRangeException(string argName, string message = "")
    { return ThrowIsNotNull(Exceptions.ArgumentOutOfRangeException(FullNameOfExecutedCode(), argName, message)); }
    public static bool ArrayElementContainsUnAllowedStrings(
        string arrayName,
        int dex,
        string valueElement,
        params string[] unallowedStrings)
    {
        return ThrowIsNotNull(
            Exceptions.ArrayElementContainsUnallowedStrings(
                FullNameOfExecutedCode(),
                arrayName,
                dex,
                valueElement,
                unallowedStrings));
    }
    public static bool BadFormatOfElementInList(
        object elVal,
        string listName,
        Func<object, string> SH_NullToStringOrDefault)
    {
        return ThrowIsNotNull(
            Exceptions.BadFormatOfElementInList(FullNameOfExecutedCode(), elVal, listName, SH_NullToStringOrDefault));
    }

    public static bool BadMappedXaml(string nameControl, string additionalInfo)
    { return ThrowIsNotNull(Exceptions.BadMappedXaml(FullNameOfExecutedCode(), nameControl, additionalInfo)); }
    public static bool CannotCreateDateTime(
        int year,
        int month,
        int day,
        int hour,
        int minute,
        int seconds,
        Exception ex)
    {
        return ThrowIsNotNull(
            Exceptions.CannotCreateDateTime(FullNameOfExecutedCode(), year, month, day, hour, minute, seconds, ex));
    }
    public static bool CannotMoveFolder(string item, string nova, Exception ex)
    { return ThrowIsNotNull(Exceptions.CannotMoveFolder(FullNameOfExecutedCode(), item, nova, ex)); }
    public static bool CheckBackslashEnd(string r)
    { return ThrowIsNotNull(Exceptions.CheckBackSlashEnd(FullNameOfExecutedCode(), r)); }

    public static bool Custom(Exception ex, bool reallyThrow = true)
    { return Custom(Exceptions.TextOfExceptions(ex), reallyThrow); }

    public static bool Custom(string message, bool reallyThrow = true, string secondMessage = "")
    {
        string joined = string.Join(" ", message, secondMessage);
        string? str = Exceptions.Custom(FullNameOfExecutedCode(), joined);
        return ThrowIsNotNull(str, reallyThrow);
    }

    public static bool CustomWithStackTrace(Exception ex) { return Custom(Exceptions.TextOfExceptions(ex)); }
    public static bool DifferentCountInLists<T>(string namefc, IList<T> countfc, string namesc, IList<T> countsc)
    {
        return ThrowIsNotNull(
            Exceptions.DifferentCountInLists(FullNameOfExecutedCode(), namefc, countfc.Count, namesc, countsc.Count));
    }
    public static bool DifferentCountInLists(string namefc, int countfc, string namesc, int countsc)
    {
        return ThrowIsNotNull(
            Exceptions.DifferentCountInLists(FullNameOfExecutedCode(), namefc, countfc, namesc, countsc));
    }

    public static bool DifferentCountInListsTU<T, U>(string namefc, IList<T> countfc, string namesc, IList<U> countsc)
    {
        return ThrowIsNotNull(
            Exceptions.DifferentCountInLists(FullNameOfExecutedCode(), namefc, countfc.Count, namesc, countsc.Count));
    }


    public static bool DirectoryExists(string path)
    { return ThrowIsNotNull(Exceptions.DirectoryExists(FullNameOfExecutedCode(), path)); }

    public static bool DirectoryWasntFound(string directory)
    { return ThrowIsNotNull(Exceptions.DirectoryWasntFound(FullNameOfExecutedCode(), directory)); }
    public static bool DivideByZero() { return ThrowIsNotNull(Exceptions.DivideByZero(FullNameOfExecutedCode())); }
    public static bool DoesntHaveRequiredType(string variableName)
    { return ThrowIsNotNull(Exceptions.DoesntHaveRequiredType(FullNameOfExecutedCode(), variableName)); }
    public static bool DuplicatedElements(string nameOfVariable, List<string> duplicatedElements, string message = "")
    {
        return ThrowIsNotNull(
            Exceptions.DuplicatedElements(FullNameOfExecutedCode(), nameOfVariable, duplicatedElements, message));
    }
    public static bool ElementCantBeFound(string nameCollection, string element)
    { return ThrowIsNotNull(Exceptions.ElementCantBeFound(FullNameOfExecutedCode(), nameCollection, element)); }


    public static bool ElementWasntRemoved(string detailLocation, int before, int after)
    { return ThrowIsNotNull(Exceptions.ElementWasntRemoved(FullNameOfExecutedCode(), detailLocation, before, after)); }

    public static bool ExcAsArg(Exception ex, string message = "")
    { return ThrowIsNotNull(Exceptions.ExcAsArg, ex, message); }


    public static bool FileAlreadyExists(string path) { return ThrowIsNotNull(Exceptions.FileAlreadyExists, path); }


    public static bool FileDoesntExists(string fulLPath)
    { return ThrowIsNotNull(Exceptions.FileExists(FullNameOfExecutedCode(), fulLPath)); }
    public static bool FileHasExtensionNotParseAbleToImageFormat(string fnOri)
    { return ThrowIsNotNull(Exceptions.FileHasExtensionNotParseAbleToImageFormat(FullNameOfExecutedCode(), fnOri)); }
    public static bool FileSystemException(Exception ex)
    { return ThrowIsNotNull(Exceptions.FileSystemException(FullNameOfExecutedCode(), ex)); }
    public static bool FirstLetterIsNotUpper(string selectedFile)
    { return ThrowIsNotNull(Exceptions.FirstLetterIsNotUpper, selectedFile); }
    public static bool FolderCannotBeDeleted(string folder, Exception ex)
    { return ThrowIsNotNull(Exceptions.FolderCannotBeDeleted(FullNameOfExecutedCode(), folder, ex)); }
    public static bool FolderCantBeRemoved(string folder)
    { return ThrowIsNotNull(Exceptions.FolderCantBeRemoved(FullNameOfExecutedCode(), folder)); }

    public static bool FolderIsNotEmpty(string variableName, string path)
    { return ThrowIsNotNull(Exceptions.FolderIsNotEmpty, variableName, path); }
    public static bool FunctionalityDenied(string functionalityName)
    { return ThrowIsNotNull(Exceptions.FunctionalityDenied(FullNameOfExecutedCode(), functionalityName)); }
    public static bool HasNotKeyDictionary<Key, Value>(string nameDict, IDictionary<Key, Value> qsDict, Key remains)
    { return ThrowIsNotNull(Exceptions.HasNotKeyDictionary(FullNameOfExecutedCode(), nameDict, qsDict, remains)); }

    public static bool HasOddNumberOfElements(string listName, ICollection list)
    {
        var f = Exceptions.HasOddNumberOfElements;
        return ThrowIsNotNull(f, listName, list);
    }

    public static bool HaveAllInnerSameCount(List<List<string>> elements)
    { return ThrowIsNotNull(Exceptions.HaveAllInnerSameCount(FullNameOfExecutedCode(), elements)); }

    public static bool InvalidExactlyLength(string variableName, int length, int requiredLenght)
    {
        return ThrowIsNotNull(
            Exceptions.InvalidExactlyLength(FullNameOfExecutedCode(), variableName, length, requiredLenght));
    }

    public static bool InvalidParameter(string valueVar, string nameVar)
    { return ThrowIsNotNull(Exceptions.InvalidParameter(FullNameOfExecutedCode(), valueVar, nameVar)); }
    public static bool IsEmpty(IEnumerable folders, string colName, string additionalMessage = "")
    { return ThrowIsNotNull(Exceptions.IsEmpty(FullNameOfExecutedCode(), folders, colName, additionalMessage)); }

    public static bool IsNotAllowed(string what)
    { return ThrowIsNotNull(Exceptions.IsNotAllowed(FullNameOfExecutedCode(), what)); }

    public static bool IsNotNull(string variableName, object variable)
    { return ThrowIsNotNull(Exceptions.IsNotNull(FullNameOfExecutedCode(), variableName, variable)); }
    public static bool IsNotPositiveNumber(string nameOfVariable, int? n)
    { return ThrowIsNotNull(Exceptions.IsNotPositiveNumber(FullNameOfExecutedCode(), nameOfVariable, n)); }

    public static bool IsNotWindowsPathFormat(
        string argName,
        string argValue,
        bool raiseIsNotWindowsPathFormat,
        Func<string, bool> SunamoFileSystem_IsWindowsPathFormat)
    {
        return ThrowIsNotNull(
            Exceptions.IsNotWindowsPathFormat(
                FullNameOfExecutedCode(),
                argName,
                argValue,
                raiseIsNotWindowsPathFormat,
                SunamoFileSystem_IsWindowsPathFormat));
    }
    public static bool IsNull(string variableName, object? variable = null)
    { return ThrowIsNotNull(Exceptions.IsNull(FullNameOfExecutedCode(), variableName, variable)); }

    public static bool IsNullOrEmpty(string argName, string argValue)
    { return ThrowIsNotNull(Exceptions.IsNullOrWhitespace(FullNameOfExecutedCode(), argName, argValue, true)); }
    public static bool IsNullOrWhitespace(string argName, string argValue)
    { return ThrowIsNotNull(Exceptions.IsNullOrWhitespace(FullNameOfExecutedCode(), argName, argValue, false)); }

    public static bool IsTheSame(string fst, string sec)
    { return ThrowIsNotNull(Exceptions.IsTheSame(FullNameOfExecutedCode(), fst, sec)); }
    public static bool IsWhitespaceOrNull(string variable, object data)
    { return ThrowIsNotNull(Exceptions.IsWhitespaceOrNull(FullNameOfExecutedCode(), variable, data)); }

    public static bool IsWindowsPathFormat(string input, Func<string, bool> isWindowsPathFormat)
    { return ThrowIsNotNull(Exceptions.IsWindowsPathFormat(FullNameOfExecutedCode(), input, isWindowsPathFormat)); }


    public static bool KeyNotFound<T, U>(IDictionary<T, U> en, string dictName, T key)
    { return ThrowIsNotNull(Exceptions.KeyNotFound(FullNameOfExecutedCode(), en, dictName, key)); }

    public static bool ListNullOrEmpty<T>(string variableName, IEnumerable<T>? list)
    { return ThrowIsNotNull(Exceptions.ListNullOrEmpty(FullNameOfExecutedCode(), variableName, list)); }

    public static bool LockedByBitLocker(string path, Func<char, bool> IsLockedByBitLocker)
    { return ThrowIsNotNull(Exceptions.LockedByBitLocker(FullNameOfExecutedCode(), path, IsLockedByBitLocker)); }

    public static bool MoreThanOneElement(string listName, int count, string moreInfo = "")
    {
        string fn = FullNameOfExecutedCode();
        string? exc = Exceptions.MoreThanOneElement(fn, listName, count, moreInfo);
        return ThrowIsNotNull(exc);
    }

    public static bool NameIsNotSetted(string nameControl, string nameFromProperty)
    { return ThrowIsNotNull(Exceptions.NameIsNotSetted(FullNameOfExecutedCode(), nameControl, nameFromProperty)); }
    public static bool NoPassedFolders(ICollection folders)
    { return ThrowIsNotNull(Exceptions.NoPassedFolders(FullNameOfExecutedCode(), folders)); }
    public static bool NotContains(string text, params string[] shouldContains)
    { return ThrowIsNotNull(Exceptions.NotContains(FullNameOfExecutedCode(), text, shouldContains)); }


    public static bool NotExists(string what)
    { return ThrowIsNotNull(Exceptions.NotExists(FullNameOfExecutedCode(), what)); }

    public static bool NotImplementedCase(object notImplementedName)
    { return ThrowIsNotNull(Exceptions.NotImplementedCase, notImplementedName); }
    public static bool NotImplementedMethod() { return ThrowIsNotNull(Exceptions.NotImplementedMethod); }
    public static bool NotInRange(string variableName, IEnumerable<string> list, int isLt, int isGt)
    { return ThrowIsNotNull(Exceptions.NotInRange(FullNameOfExecutedCode(), variableName, list, isLt, isGt)); }
    public static bool NotInt(string what, int? value)
    { return ThrowIsNotNull(Exceptions.NotInt(FullNameOfExecutedCode(), what, value)); }

    public static bool NotSupported() { return ThrowIsNotNull(Exceptions.NotSupported(FullNameOfExecutedCode())); }
    public static bool NotSupportedExtension(string extension)
    { return ThrowIsNotNull(Exceptions.NotSupportedExtension, extension); }
    public static bool OnlyOneElement(string colName, ICollection list)
    { return ThrowIsNotNull(Exceptions.OnlyOneElement(FullNameOfExecutedCode(), colName, list)); }
    public static bool OutOfRange(string colName, ICollection col, string indexName, int index)
    { return ThrowIsNotNull(Exceptions.OutOfRange(FullNameOfExecutedCode(), colName, col, indexName, index)); }
    public static bool PassedListInsteadOfArray<T>(
        string variableName,
        T[] v,
        Func<IEnumerable<T>, bool> CA_IsListStringWrappedInArray)
    {
        return ThrowIsNotNull(
            Exceptions.PassedListInsteadOfArray<T>(
                FullNameOfExecutedCode(),
                variableName,
                v.ToList(),
                CA_IsListStringWrappedInArray));
    }
    public static bool RepeatAfterTimeXTimesFailed(
        int times,
        int timeoutInMs,
        string address,
        int sharedAlgorithmSlastError)
    {
        return ThrowIsNotNull(
            Exceptions.RepeatAfterTimeXTimesFailed(
                FullNameOfExecutedCode(),
                times,
                timeoutInMs,
                address,
                sharedAlgorithmSlastError));
    }

    public static bool StartIsHigherThanEnd(int start, int end)
    { return ThrowIsNotNull(Exceptions.StartIsHigherThanEnd(FullNameOfExecutedCode(), start, end)); }
    public static bool StringContainsUnAllowedSubstrings(string input, params string[] unallowedStrings)
    {
        return ThrowIsNotNull(
            Exceptions.StringContainsUnallowedSubstrings(FullNameOfExecutedCode(), input, unallowedStrings));
    }

    public static bool UncommentAfterNugetsFinished() { return Custom("Uncomment after nugets finished"); }

    public static bool UriFormat(string url, Func<string, bool> uhIsUri)
    { return ThrowIsNotNull(Exceptions.UriFormat, url, uhIsUri); }
    public static bool UseRlc() { return ThrowIsNotNull(Exceptions.UseRlc(FullNameOfExecutedCode())); }

    public static bool WasAlreadyInitialized()
    { return ThrowIsNotNull(Exceptions.WasAlreadyInitialized(FullNameOfExecutedCode())); }
    public static bool WasNotKeysHandler(string name, object keysHandler)
    { return ThrowIsNotNull(Exceptions.WasNotKeysHandler(FullNameOfExecutedCode(), name, keysHandler)); }
    public static bool WrongExtension(string path, string requiredExt)
    { return ThrowIsNotNull(Exceptions.WrongExtension(FullNameOfExecutedCode(), path, requiredExt)); }
    public static bool WrongNumberOfElements<T>(int requireElements, string nameCollection, IEnumerable<T> collection)
    {
        return ThrowIsNotNull(
            Exceptions.WrongNumberOfElements(FullNameOfExecutedCode(), requireElements, nameCollection, collection));
    }
    public static bool ZeroOrMoreThanOne(string nameOfVariable, List<string> list)
    { return ThrowIsNotNull(Exceptions.ZeroOrMoreThanOne(FullNameOfExecutedCode(), nameOfVariable, list)); }

    #region Other
    public static string FullNameOfExecutedCode()
    {
        Tuple<string, string, string> placeOfExc = Exceptions.PlaceOfException();
        string f = FullNameOfExecutedCode(placeOfExc.Item1, placeOfExc.Item2, true);
        return f;
    }

    static string FullNameOfExecutedCode(object type, string methodName, bool fromThrowEx = false)
    {
        if (methodName == null)
        {
            int depth = 2;
            if (fromThrowEx)
            {
                depth++;
            }

            methodName = Exceptions.CallingMethod(depth);
        }
        string typeFullName;
        if (type is Type type2)
        {
            typeFullName = type2.FullName ?? "Type cannot be get via type is Type type2";
        }
        else if (type is MethodBase method)
        {
            typeFullName = method.ReflectedType?.FullName ?? "Type cannot be get via type is MethodBase method";
            methodName = method.Name;
        }
        else if (type is string)
        {
            typeFullName = type.ToString() ?? "Type cannot be get via type is string";
        }
        else
        {
            Type t = type.GetType();
            typeFullName = t.FullName ?? "Type cannot be get via type.GetType()";
        }
        return string.Concat(typeFullName, ".", methodName);
    }

    public static bool ThrowIsNotNull(string? exception, bool reallyThrow = true)
    {
        if (exception != null)
        {
            Debugger.Break();
            if (reallyThrow)
            {
                throw new Exception(exception);
            }
            return true;
        }
        return false;
    }

    #region For avoid FullNameOfExecutedCode
    public static bool ThrowIsNotNull(Exception exception, bool reallyThrow = true)
    {
        if (exception != null)
        {
            ThrowIsNotNull(exception.Message, reallyThrow);
            return false;
        }
        return true;
    }

    public static bool ThrowIsNotNull<A, B>(Func<string, A, B, string?> f, A ex, B message)
    {
        string? exc = f(FullNameOfExecutedCode(), ex, message);
        return ThrowIsNotNull(exc);
    }

    public static bool ThrowIsNotNull<A>(Func<string, A, string?> f, A ex)
    {
        string? exc = f(FullNameOfExecutedCode(), ex);
        return ThrowIsNotNull(exc);
    }

    public static bool ThrowIsNotNull(Func<string, string?> f)
    {
        string? exc = f(FullNameOfExecutedCode());
        return ThrowIsNotNull(exc);
    }

    public static void StringContainsUnallowedSubstrings(string v1, string v2)
    {
        throw new NotImplementedException();
    }

    public static void FileHasExtensionNotParseableToImageFormat(string fnOri)
    {
        throw new NotImplementedException();
    }
    #endregion
    #endregion
}