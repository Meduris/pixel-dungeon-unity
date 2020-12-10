using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public class ValueAccessor : MonoBehaviour
{
    [Flags]
    public enum ValueBindingType
    {
        Property = 1,
        Field = 2,
    }

    [HideInInspector] public MemberInfo SourceMember;
    [HideInInspector] public string SourceMemberName;

    public MonoBehaviour Source;

    public string FormatString;
    public ValueBindingType bindingType;

    private bool _initialized = false;

    private void Init()
    {
        if (_initialized)
            return;
        _initialized = true;
        
        var members = new List<MemberInfo>();
        var flags = BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance;
        if (bindingType.HasFlag(ValueBindingType.Field))
        {
            members.AddRange(Source.GetType().GetFields(flags));
        }

        if (bindingType.HasFlag(ValueBindingType.Property))
        {
            members.AddRange(Source.GetType().GetProperties(flags));
        }

        SourceMember = members.FirstOrDefault(x => x.Name == SourceMemberName);
    }

    public void Awake()
    {
        Init();
    }

    public object GetValue()
    {
        Init();
        switch (SourceMember)
        {
            case null:
                return null;
            case FieldInfo field:
                return field.GetValue(Source);
            case PropertyInfo property:
                return property.GetValue(Source);
            default:
                throw new InvalidOperationException("SourceMember must be either a field or a property");
        }
    }

    public T GetValue<T>()
    {
        Init();
        switch (SourceMember)
        {
            case null:
                return DynamicCast<T>(null);
            case FieldInfo field:
                return DynamicCast<T>(field.GetValue(Source));
            case PropertyInfo property:
                return DynamicCast<T>(property.GetValue(Source));
            default:
                throw new InvalidOperationException("SourceMember must be either a field or a property");
        }
    }

    public void SetValue(object value)
    {
        Init();
        switch (SourceMember)
        {
            case null:
                break;
            case FieldInfo field:
                if (field.FieldType.IsInstanceOfType(value))
                    field.SetValue(Source, value);
                else
                    throw new ArgumentException("type mismatch");
                break;
            case PropertyInfo property:
                if (property.PropertyType.IsInstanceOfType(value))
                    property.SetValue(Source, value);
                else
                    throw new ArgumentException("type mismatch");
                break;
        }
    }

    private T DynamicCast<T>(object obj)
    {
        Init();
        if (obj is T tmp)
            return tmp;
        try
        {
            return (T) Convert.ChangeType(obj, typeof(T));
        }
        catch (InvalidCastException)
        {
            return default;
        }
    }
}