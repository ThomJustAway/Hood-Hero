using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Problem;

public class ProblemSelector : MonoBehaviour 
{
    [SerializeField] private MainProblem mainProblem = MainProblem.Cleanliness;
    [SerializeField] private SubProblem subProblem = SubProblem.RodentInfestation;
    public MainProblem MainProblem { get { return mainProblem; } }
    public SubProblem SubProblem { get { return subProblem; } }

    public bool IsSeriousProblem = false;
}


