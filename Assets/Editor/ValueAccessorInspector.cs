using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ValueAccessor))]
public class ValueAccessorInspector : Editor
{
    [SerializeField] private int _sourceIndex;
    [SerializeField] private string[] _sourceMemberNames;
    [SerializeField] private List<MemberInfo> _sourceMembers = new List<MemberInfo>();
    [SerializeField] private string _formatString = "{0}";

    private ValueAccessor accessor;
    private bool _initialized;

    private void OnEnable()
    {
        _initialized = false;
        accessor = target as ValueAccessor;

        Refresh();

        if (_sourceMembers.Count > 0)
        {
            if (_sourceIndex >= _sourceMembers.Count)
                _sourceIndex = 0;

            _sourceIndex = Array.IndexOf(_sourceMemberNames, accessor.SourceMemberName);
            _formatString = accessor.FormatString;
            _initialized = true;
        }
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if (!_initialized && accessor.Source != null)
        {
            _initialized = true;
            Refresh();
        }
        
        if (_sourceMembers.Count > 0)
        {
            _sourceIndex = EditorGUILayout.Popup("Source: ", _sourceIndex, _sourceMemberNames);
        }
        else
        {
            GUILayout.Label("No source members");
        }

        if (GUI.changed)
        {
            if (_sourceIndex < _sourceMembers.Count)
            {
                accessor.SourceMember = _sourceMembers[_sourceIndex];
                accessor.SourceMemberName = _sourceMemberNames[_sourceIndex];
            }

            accessor.FormatString = _formatString;
            
            Refresh();
        }
        
        EditorUtility.SetDirty(target);
    }

    private void Refresh()
    {
        if (accessor.Source == null)
            return;

        var flags = BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance;

        _sourceMembers = new List<MemberInfo>();
        if (accessor.bindingType.HasFlag(ValueAccessor.ValueBindingType.Field))
        {
            _sourceMembers.AddRange(accessor.Source.GetType().GetFields(flags));
        }

        if (accessor.bindingType.HasFlag(ValueAccessor.ValueBindingType.Property))
        {
            _sourceMembers.AddRange(accessor.Source.GetType().GetProperties(flags));
        }
        
        _sourceMemberNames = _sourceMembers.Select(x => x.Name).ToArray();
    }
}
