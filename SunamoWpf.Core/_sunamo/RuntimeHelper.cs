namespace SunamoWpf._sunamo;

internal class RuntimeHelper
{
    internal static Type type = typeof(RuntimeHelper);
    internal static List<Delegate> GetInvocationList(Delegate e)
    {
        if (e == null)
        {
            return new List<Delegate>();
        }
        return e.GetInvocationList().ToList();
    }
    /// <summary>
    /// Not working for WPF
    /// </summary>
    /// <returns></returns>
    internal static bool IsConsole()
    {
        return Environment.UserInteractive;
    }
    internal static bool HasEventHandler(Delegate e)
    {
        return GetInvocationList(e).Count() > 0;
    }
    /// <summary>
    /// Nedokázal jsem zjistit zda SuMenuItem má registrovaný Click - reflexe u něj nenašla vlastnost Events
    /// Musel jsem kvůli toho vytvořit SuMenuItem
    ///
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="control"></param>
    /// <param name="eventName"></param>
    /// <returns></returns>
    internal static bool HasEventHandler<T>(T control, string eventName)
    {
#if DEBUG
#endif
        var pi = typeof(T).GetProperty("Events", BindingFlags.NonPublic | BindingFlags.Instance);
        if (pi == null)
        {
            return false;
        }
        EventHandlerList events = (EventHandlerList)pi.GetValue(control, null);
        object key = typeof(T)
            .GetField(eventName, BindingFlags.NonPublic | BindingFlags.Static)
            .GetValue(null);
        Delegate handlers = events[key];
        return handlers != null && handlers.GetInvocationList().Any();
    }
    //internal static List<Delegate> GetEventHandlers(DataGridView obj, string eventName)
    //{
    //    EventHandlerList eventHandlerList = (EventHandlerList)obj.GetType().GetProperty("Events", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(obj, null);
    //    MethodInfo findMethod = eventHandlerList.GetType().GetMethod("Find", BindingFlags.NonPublic | BindingFlags.Instance);
    //    string fieldName = "EVENT_DATAGRIDVIEW" + eventName.ToUpper();
    //    FieldInfo field = obj.GetType().GetField(fieldName, BindingFlags.Static | BindingFlags.NonPublic);
    //    if (obj.GetType().GetEvent(eventName) != null && field != null)
    //    {
    //        object value = findMethod.Invoke(eventHandlerList, new string[] { field.GetValue(obj) });
    //        if (value != null)
    //        {
    //            FieldInfo handlerField = value.GetType().GetField("handler", BindingFlags.NonPublic | BindingFlags.Instance);
    //            return ((Delegate)handlerField.GetValue(value)).GetInvocationList().ToList();
    //        }
    //    }
    //    return new List<Delegate>();
    //}
    /// <summary>
    /// Default is true for automatically avoiding errors
    /// </summary>
    /// <param name = "controlWithResult"></param>
    /// <param name = "a"></param>
    /// <param name = "throwException"></param>
    internal static void AttachChangeDialogResult(IControlWithResultDebugWpf controlWithResult, VoidBoolNullable a, bool throwException = true)
    {
        var count = controlWithResult.CountOfHandlersChangeDialogResult();
        if (count > 0)
        {
            if (throwException)
            {
                throw new Exception(Translate.FromKey(XlfKeys.ChangeDialogResultHasAlredyRegisteredHandler));
            }
            else
            {
                // Do nothing
            }
        }
        else
        {
            controlWithResult.ChangeDialogResult += a;
        }
    }
    internal static T CastToGeneric<T>(object o)
    {
        return (T)o;
    }
    internal static void EmptyDummyMethod()
    {
    }

#pragma warning disable
    internal static void EmptyDummyMethod(string s, params string[] o)
    {
    }
    internal static void EmptyDummyMethodLogMessage(TypeOfMessageWpf t, string s, params string[] o)
    {
    }
#pragma warning restore

    internal static bool IsAdminUser()
    {
        return false;
    }
}