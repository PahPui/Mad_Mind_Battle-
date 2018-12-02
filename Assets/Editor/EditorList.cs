using UnityEngine;
using UnityEditor;
using System;

[Flags]
public enum EditorListOption
{
    None = 0,
    ListSize = 1,
    ListLabel = 2,
    ElementLabels = 4,
    Default = ListSize | ListLabel | ElementLabels,
    NoElementLabels = ListSize | ListLabel
}

public static class EditorList {

    public static void Show(SerializedProperty list, EditorListOption options = EditorListOption.Default)
    {
        bool
            showListLabel = (options & EditorListOption.ListLabel) != 0,
            showListSize = (options & EditorListOption.ListSize) != 0;

        EditorGUILayout.BeginHorizontal();
        if (showListLabel)
        {
            EditorGUILayout.PropertyField(list);
        }
        if (showListSize)
        {
            EditorGUILayout.PropertyField(list.FindPropertyRelative("Array.size"));
        }
        EditorGUILayout.EndHorizontal();
        EditorGUI.indentLevel += 1;

        if (!showListLabel || list.isExpanded)
        {
            ShowElements(list, options);
        }
        if (showListLabel)
        {
            EditorGUI.indentLevel -= 1;
        }
    }

    private static void ShowElements(SerializedProperty list, EditorListOption options)
    {
        bool showElementLabels = (options & EditorListOption.ElementLabels) != 0;

        for (int i = 0; i < list.arraySize; i++)
        {
            if (showElementLabels)
            {
                EditorGUILayout.PropertyField(list.GetArrayElementAtIndex(i));
            }
            else
            {
                EditorGUILayout.PropertyField(list.GetArrayElementAtIndex(i), GUIContent.none);
            }
        }
    }

}
