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
    SerializedProperty timer;
    private void OnEnable()
    {
        mainProblem = serializedObject.FindProperty("mainProblem");
        subProblem = serializedObject.FindProperty("subProblem");
        isSeriousProblem = serializedObject.FindProperty("isSeriousProblem");
        timer = serializedObject.FindProperty("timer");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        ProblemSelector problem = (ProblemSelector)target;

        EditorGUILayout.PropertyField(mainProblem);
        EditorGUILayout.PropertyField(subProblem);
        EditorGUILayout.PropertyField(isSeriousProblem);
        if (problem.IsSeriousProblem)
        {
            EditorGUILayout.PropertyField(timer);
        }

        serializedObject.ApplyModifiedProperties();
    }
}
