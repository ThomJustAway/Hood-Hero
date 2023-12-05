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
    [SerializeField] private Problem.MainProblem mainProblem = Problem.MainProblem.Cleanliness;
    [SerializeField] private Problem.SubProblem subProblem = Problem.SubProblem.DirtyPublicAreas;
    public MainProblem MainProblem { get { return mainProblem; } }
    public SubProblem SubProblem { get { return subProblem; } }

    [SerializeField] private bool isSeriousProblem = false;
    public bool IsSeriousProblem { get { return isSeriousProblem; } }

    [SerializeField] private float timer = 0.0f;
    #region images
    [Header("Image detail")]
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