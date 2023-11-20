using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class Problem
{
    public MainProblem mainProblem = MainProblem.Cleanliness;
    public SubProblem subProblem = SubProblem.RodentInfestation;
    
}
public enum SubProblem
{
    IanInfestation,
    RodentInfestation
}

public enum MainProblem
{
    Cleanliness,
    HDB
}



//how would I do this?
//Will have a class called Problem which will contain the sub and main problem
