namespace SunamoWpf.Core._sunamo;


public class RuntimeHelper
{
    public static Type type = typeof(RuntimeHelper);
    public static List<Delegate> GetInvocationList(Delegate handler)
    {
        if (handler == null)
        {
            return new List<Delegate>();
        }
        return handler.GetInvocationList().ToList();
    }
    /// <summary>
    /// Not working for WPF
    /// </summary>
    /// <returns></returns>
    public static bool IsConsole()
    {
        return Environment.UserInteractive;
    }
    public static bool HasEventHandler(Delegate handler)
    {
        return GetInvocationList(handler).Count() > 0;
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
    public static bool HasEventHandler<T>(T control, string eventName)
    {
#if DEBUG
#endif
        var propertyInfo = typeof(T).GetProperty("Events", BindingFlags.NonPublic | BindingFlags.Instance);
        if (propertyInfo == null)
        {
            return false;
        }
        EventHandlerList events = (EventHandlerList)propertyInfo.GetValue(control, null);
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
    /// <param name = "handler"></param>
    /// <param name = "throwException"></param>
    public static void AttachChangeDialogResult(IControlWithResultDebugWpf controlWithResult, VoidBoolNullable handler, bool throwException = true)
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
            controlWithResult.ChangeDialogResult += handler;
        }
    }
    public static T CastToGeneric<T>(object value)
    {
        return (T)value;
    }
    public static void EmptyDummyMethod()
    {
    }

#pragma warning disable
    public static void EmptyDummyMethod(string message, params string[] parameters)
    {
    }
    public static void EmptyDummyMethodLogMessage(TypeOfMessageWpf typeOfMessage, string message, params string[] parameters)
    {
    }
#pragma warning restore

    public static bool IsAdminUser()
    {
        return false;
    }
}