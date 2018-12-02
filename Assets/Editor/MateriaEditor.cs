using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Materia))]
public class MateriaEditor : Editor {

    //SerializedProperty Name;
   // SerializedProperty Questions;



    public override void OnInspectorGUI()
    {

        base.OnInspectorGUI();

        Materia materia = (Materia)target;

        materia.name = materia.Name;

        if (GUILayout.Button("Add Question"))
        {
           materia.CreateNewQuestion();
            
        }

        

    }
}
