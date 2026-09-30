#define ASYNC
namespace SunamoWpf._sunamo;

internal class RH
{
    public static Assembly AssemblyWithName(string name)
    {
        try
        {
            System.Diagnostics.Debug.WriteLine($"AssemblyWithName: Searching for assembly '{name}'");

            if (string.IsNullOrWhiteSpace(name))
            {
                System.Diagnostics.Debug.WriteLine("AssemblyWithName: name is null or empty");
                return null;
            }

            var currentDomain = AppDomain.CurrentDomain;
            System.Diagnostics.Debug.WriteLine($"AssemblyWithName: CurrentDomain is {(currentDomain == null ? "NULL" : "OK")}");

            var ass = currentDomain?.GetAssemblies();
            System.Diagnostics.Debug.WriteLine($"AssemblyWithName: GetAssemblies returned {(ass == null ? "NULL" : $"{ass.Length} assemblies")}");

            // CZ: Defensive check - GetAssemblies() by nikdy nemělo vrátit null, ale pro jistotu
            // EN: Defensive check - GetAssemblies() should never return null, but just in case
            if (ass == null || ass.Length == 0)
            {
                System.Diagnostics.Debug.WriteLine("AssemblyWithName: No assemblies found");
                return null;
            }

            // CZ: GetName() může hodit výjimku pro některé assemblies, proto safe wrapper
            // EN: GetName() can throw exception for some assemblies, so use safe wrapper
            IEnumerable<Assembly> result = ass.Where(d =>
            {
                try
                {
                    return d.GetName().Name == name;
                }
                catch
                {
                    return false;
                }
            });

            if (result.Count() == 0)
            {
                result = ass.Where(d =>
                {
                    try
                    {
                        return d.FullName == name;
                    }
                    catch
                    {
                        return false;
                    }
                });
            }

            if (result.Count() == 0)
            {
                result = ass.Where(d =>
                {
                    try
                    {
                        return d.FullName != null && d.FullName.Contains(name);
                    }
                    catch
                    {
                        return false;
                    }
                });
            }

            var foundAssembly = result.FirstOrDefault();
            System.Diagnostics.Debug.WriteLine($"AssemblyWithName: Result = {(foundAssembly == null ? "NULL" : foundAssembly.FullName)}");

            return foundAssembly;
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"AssemblyWithName: EXCEPTION - {ex.GetType().Name}: {ex.Message}");
            System.Diagnostics.Debug.WriteLine($"AssemblyWithName: StackTrace - {ex.StackTrace}");
            throw;
        }
    }
    public static string DumpAsString(DumpAsStringArgs dumpAsStringArgs)
    {
        return ObjectDumper.Dump(dumpAsStringArgs.o);
    }
    public static string FullPathCodeEntity(Type t)
    {
        return t.Namespace + "." + t.Name;
    }
    public static object GetValueOfPropertyOrField(object o, string name)
    {
        var type = o.GetType();

        var value = GetValueOfProperty(name, type, o, false);

        if (value == null) value = GetValueOfField(name, type, o, false);

        return value;
    }
    public static object GetValueOfField(string name, Type type, object instance, bool ignoreCase)
    {
        var pis = type.GetFields();

        return GetValue(name, type, instance, pis, ignoreCase, null);
    }

    public static object GetValueOfProperty(string name, Type type, object instance, bool ignoreCase)
    {
        var pis = type.GetProperties();
        return GetValue(name, type, instance, pis, ignoreCase, null);
    }

    public static object GetValue(string name, Type type, object instance, IList pis, bool ignoreCase, object v)
    {
        return GetOrSetValue(name, type, instance, pis, ignoreCase, GetValue, v);
    }

    private static object GetValue(object instance, MemberInfo[] property, object v)
    {
        var val = property[0];
        if (val is PropertyInfo)
        {
            var pi = (PropertyInfo)val;
            return pi.GetValue(instance);
        }
        else if (val is FieldInfo)
        {
            var pi = (FieldInfo)val;
            return pi.GetValue(instance);
        }
        return null;
    }

    public static object GetOrSetValue(string name, Type type, object instance, IList pis, bool ignoreCase,
        Func<object, MemberInfo[], object, object> getOrSet, object v)
    {
        if (ignoreCase)
        {
            name = name.ToLower();
            foreach (MemberInfo item in pis)
                if (item.Name.ToLower() == name)
                {
                    var property = type.GetMember(name);
                    if (property != null) return getOrSet(instance, property, v);
                    //return GetValue(instance, property);
                }
        }
        else
        {
            foreach (MemberInfo item in pis)
                if (item.Name == name)
                {
                    var property = type.GetMember(name);
                    if (property != null) return getOrSet(instance, property, v);
                    //return GetValue(instance, property);
                }
        }

        return null;
    }

    public static bool IsOrIsDeriveFromBaseClass(Type children, Type parent, bool a1CanBeString = true)
    {
        if (children == typeof(string) && !a1CanBeString) return false;
        if (children == null) ThrowEx.IsNull("children", children);
        while (true)
        {
            if (children == null) return false;
            if (children == parent) return true;
            foreach (var inter in children.GetInterfaces())
                if (inter == parent)
                    return true;
            children = children.BaseType;
        }
    }
}