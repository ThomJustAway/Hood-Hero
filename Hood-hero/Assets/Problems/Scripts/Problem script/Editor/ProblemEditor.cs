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
    SerializedProperty closeUpImage;
    SerializedProperty farAwayImage;
    SerializedProperty details;

    bool imageDetail = false;
    private void OnEnable()
    {
        mainProblem = serializedObject.FindProperty("mainProblem");
        subProblem = serializedObject.FindProperty("subProblem");
        isSeriousProblem = serializedObject.FindProperty("isSeriousProblem");
        timer = serializedObject.FindProperty("timer");
        closeUpImage = serializedObject.FindProperty("closeUpImage");
        farAwayImage = serializedObject.FindProperty("farAwayImage");
        details = serializedObject.FindProperty("details");
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

        imageDetail= EditorGUILayout.BeginFoldoutHeaderGroup(imageDetail, "Image detail");
        if (imageDetail)
        {
            EditorGUILayout.PropertyField(closeUpImage);
            EditorGUILayout.PropertyField(farAwayImage);
        }
        EditorGUILayout.EndFoldoutHeaderGroup();
        EditorGUILayout.PropertyField(details);

        serializedObject.ApplyModifiedProperties();
    }
}
