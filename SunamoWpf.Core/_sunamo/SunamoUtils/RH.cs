#define ASYNC
namespace SunamoWpf.Core._sunamo;

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
            IEnumerable<Assembly> result = ass.Where(assembly =>
            {
                try
                {
                    return assembly.GetName().Name == name;
                }
                catch
                {
                    return false;
                }
            });

            if (result.Count() == 0)
            {
                result = ass.Where(candidateAssembly =>
                {
                    try
                    {
                        return candidateAssembly.FullName == name;
                    }
                    catch
                    {
                        return false;
                    }
                });
            }

            if (result.Count() == 0)
            {
                result = ass.Where(assemblyToCheck =>
                {
                    try
                    {
                        return assemblyToCheck.FullName != null && assemblyToCheck.FullName.Contains(name);
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
        catch (Exception exception)
        {
            System.Diagnostics.Debug.WriteLine($"AssemblyWithName: EXCEPTION - {exception.GetType().Name}: {exception.Message}");
            System.Diagnostics.Debug.WriteLine($"AssemblyWithName: StackTrace - {exception.StackTrace}");
            throw;
        }
    }
    public static string DumpAsString(DumpAsStringArgs dumpAsStringArgs)
    {
        return ObjectDumper.Dump(dumpAsStringArgs.o);
    }
    public static string FullPathCodeEntity(Type type)
    {
        return type.Namespace + "." + type.Name;
    }
    public static object GetValueOfPropertyOrField(object instance, string name)
    {
        var type = instance.GetType();

        var value = GetValueOfProperty(name, type, instance, false);

        if (value == null) value = GetValueOfField(name, type, instance, false);

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

    public static object GetValue(string name, Type type, object instance, IList pis, bool ignoreCase, object value)
    {
        return GetOrSetValue(name, type, instance, pis, ignoreCase, GetValue, value);
    }

    private static object GetValue(object instance, MemberInfo[] property, object value)
    {
        var val = property[0];
        if (val is PropertyInfo)
        {
            var propertyInfo = (PropertyInfo)val;
            return propertyInfo.GetValue(instance);
        }
        else if (val is FieldInfo)
        {
            var fieldInfo = (FieldInfo)val;
            return fieldInfo.GetValue(instance);
        }
        return null;
    }

    public static object GetOrSetValue(string name, Type type, object instance, IList pis, bool ignoreCase,
        Func<object, MemberInfo[], object, object> getOrSet, object value)
    {
        if (ignoreCase)
        {
            name = name.ToLower();
            foreach (MemberInfo item in pis)
                if (item.Name.ToLower() == name)
                {
                    var property = type.GetMember(name);
                    if (property != null) return getOrSet(instance, property, value);
                    //return GetValue(instance, property);
                }
        }
        else
        {
            foreach (MemberInfo item in pis)
                if (item.Name == name)
                {
                    var property = type.GetMember(name);
                    if (property != null) return getOrSet(instance, property, value);
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
