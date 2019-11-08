using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.UIElements;

/*
[Serializable]
public class MyKey
{
    #region f/p

    public KeyCode Key;

    public string Label = "";

    #endregion
   
} */

[CustomPropertyDrawer(typeof(MyKey))]
public class MyKeyUI: PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        // Don't make child fields be indented
        var indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        // Calculate rects
        Rect rectTextBox = new Rect(position.x, position.y, 50, position.height);
        Rect rectKeys = new Rect(position.x+60, position.y, 100, position.height);

        // Draw fields - passs GUIContent.none to each so they are drawn without labels
        EditorGUI.PropertyField(rectKeys, property.FindPropertyRelative("Key"), GUIContent.none);

        EditorGUI.BeginChangeCheck();
        EditorGUI.PropertyField(rectTextBox, property.FindPropertyRelative("Label"), GUIContent.none);

        if (EditorGUI.EndChangeCheck())
            property.FindPropertyRelative("Key").enumValueIndex = FindPositionByLabel(property.FindPropertyRelative("Label").stringValue);
        
        // Set indent back to what it was
        EditorGUI.indentLevel = indent;

        EditorGUI.EndProperty();
    }

    
    
    #region custom methods

    private int FindPositionByLabel(string _label)
    {
        string[] _keys = System.Enum.GetNames(typeof(KeyCode));

        for(int i =0; i< _keys.Length; i++)
        {
            if (_label.Length == 1 && _keys[i].ToUpper().Equals(_label.ToUpper()))
                return i;
            else if (_label.Length > 1 && _keys[i].ToUpper().StartsWith(_label.ToUpper()))
            {
                Debug.Log($"{i} {_keys[i]} {_label}");
                return i;
            }
        }
        return 0;
    }

    #endregion

}
