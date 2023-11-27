using Problem;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Problem_script
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/AddProblem", order = 1)]
    public class OneServiceProblemSelectorScriptableObject : ScriptableObject
    {
        public MainProblem mainProbelm;
        public SubProblem[] subProblems;

        
    }
}