namespace SunamoWpf._public;

/// <summary>
/// Represents the string string type.
/// </summary>
public delegate string StringString(string value);
/// <summary>
/// Represents the void t t type.
/// </summary>
public delegate void VoidT<T>(T value);
/// <summary>
/// Represents the void int type.
/// </summary>
public delegate void VoidInt(int value);
/// <summary>
/// Represents the void string type.
/// </summary>
public delegate void VoidString(string value);
/// <summary>
/// Represents the void bool nullable type.
/// </summary>
public delegate void VoidBoolNullable(bool? value);
/// <summary>
/// Represents the task bool nullable type.
/// </summary>
public delegate Task TaskBoolNullable(bool? value);