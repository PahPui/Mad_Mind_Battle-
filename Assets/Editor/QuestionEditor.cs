using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Questions))]
public class QuestionEditor : Editor
{

    SerializedProperty Question;
    SerializedProperty Answer;

    private void OnEnable()
    {
        Question = serializedObject.FindProperty("Question");
        Answer = serializedObject.FindProperty("Answer");
    }

    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();

        serializedObject.Update();

        Questions q = (Questions)target;

        GUILayout.BeginHorizontal();
        GUILayout.Label("Question:", GUILayout.Width(70));
        q.Question = EditorGUILayout.TextField(q.Question,GUILayout.Width(140));
        q.name = q.Question;
        //GUILayout.EndHorizontal();

        //GUILayout.BeginHorizontal();
        GUILayout.Label("Answer:", GUILayout.Width(60));
        q.Answer = EditorGUILayout.TextField(q.Answer,GUILayout.Width(140));
        GUILayout.EndHorizontal();

        GUILayout.Space(5);


        //EditorGUILayout.PropertyField(serializedObject.FindProperty("WrongAnswers"), true);

        EditorList.Show(serializedObject.FindProperty("WrongAnswers"), EditorListOption.NoElementLabels);

        serializedObject.ApplyModifiedProperties();
    }
}
