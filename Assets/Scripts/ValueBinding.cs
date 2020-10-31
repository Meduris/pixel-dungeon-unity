using System;
using System.Reflection;
using UnityEngine;

public class ValueBinding : MonoBehaviour
{
    public MonoBehaviour SourceObject;
    public string SourceField;
    private FieldInfo field;

    public void Awake()
    {
        var f = SourceObject.GetType().GetField(SourceField, BindingFlags.Public | BindingFlags.Instance);
        if (f?.FieldType == typeof(bool))
        {
            field = f;
        }
    }

    private void OnValidate()
    {
        if (SourceObject == null || string.IsNullOrEmpty(SourceField))
            return;
        var f = SourceObject.GetType().GetField(SourceField, BindingFlags.Public | BindingFlags.Instance);
        if (f?.FieldType != typeof(bool))
        {
            throw new ArgumentException();
        }
    }

    public bool GetValue()
    {
        return (bool) field.GetValue(SourceObject);
    }

    public void SetValue(bool value)
    {
        field.SetValue(SourceObject, value);
    }
}