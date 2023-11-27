using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Problem;

public class ProblemSelector : MonoBehaviour 
{
    [SerializeField] private MainProblem mainProblem = MainProblem.Cleanliness;
    [SerializeField] private SubProblem subProblem = SubProblem.DirtyPublicAreas;
    public MainProblem MainProblem { get { return mainProblem; } }
    public SubProblem SubProblem { get { return subProblem; } }

    [SerializeField] private bool isSeriousProblem = false;
    public bool IsSeriousProblem { get { return isSeriousProblem; } }
    [SerializeField] private float timer = 0.0f;

    public void IsSolve()
    {
        //send event
        enabled = false; //make it disapper
    }
}


