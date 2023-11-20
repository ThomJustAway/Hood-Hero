using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Problem;

[CustomEditor(typeof(ProblemSelector))]
public class ProblemEditor : Editor
{
    SerializedProperty mainProblem;
    SerializedProperty subProblem;
    SerializedProperty isSeriousProblem;
    private void OnEnable()
    {
        mainProblem = serializedObject.FindProperty("mainProblem");
        subProblem = serializedObject.FindProperty("subProblem");
        isSeriousProblem = serializedObject.FindProperty("IsSeriousProblem");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(mainProblem);

        serializedObject.ApplyModifiedProperties();
    }
}
