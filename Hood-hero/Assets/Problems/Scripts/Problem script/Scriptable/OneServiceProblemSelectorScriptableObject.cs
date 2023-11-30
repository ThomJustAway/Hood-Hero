using Problem;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Problem_script
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/AddProblem", order = 1)]
    public class OneServiceProblemSelectorScriptableObject : ScriptableObject
    {
        public Problem.MainProblem mainCategory;
        public Problem.SubProblem[] subProblems;
        public Sprite picture;

        [SerializeField] private string mainProblemText;

        public string MainproblemText { get { return mainProblemText; } }
    }
}