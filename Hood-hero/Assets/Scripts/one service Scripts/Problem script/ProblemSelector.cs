using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Problem;
using UnityEngine.UI;
using System;
using HoodHeroUI;

public class ProblemSelector : MonoBehaviour 
{
    [SerializeField] private MainProblem mainProblem = MainProblem.Cleanliness;
    [SerializeField] private SubProblem subProblem = SubProblem.DirtyPublicAreas;
    public MainProblem MainProblem { get { return mainProblem; } }
    public SubProblem SubProblem { get { return subProblem; } }

    [SerializeField] private bool isSeriousProblem = false;
    public bool IsSeriousProblem { get { return isSeriousProblem; } }

    [SerializeField]  private int timer = 0; //how many second before the trigger occur
    public int CountDown { get { return timer; } }
    #region images
    [SerializeField] private Sprite closeUpImage;
    [SerializeField] private Sprite farAwayImage;
    [SerializeField] private DetailOfTheProblem[] details;
    public Sprite CloseupImage { get { return closeUpImage; } }
    public Sprite FarAwayImage { get { return farAwayImage; } }
    public DetailOfTheProblem[] Details { get {  return details; } }
    #endregion

    public void IsSolve()
    {
        //send event
        enabled = false; //make it disappear
        gameObject.SetActive(false);
    }
}

[System.Serializable]
public struct DetailOfTheProblem
{
    [TextArea(4, 10)]
    public string detail;
    public bool isCorrect;

    public DetailOfTheProblem(string detail, bool isCorrect)
    {
        this.detail = detail;
        this.isCorrect = isCorrect;
    }
}