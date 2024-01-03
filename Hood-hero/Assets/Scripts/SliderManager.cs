using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using pattern;

public class SliderManager : MonoBehaviour
{

    //change this later on
    [SerializeField]private TextMeshProUGUI pointText;

    [Header("stars")]
    [SerializeField] private Image FirstStar;
    [SerializeField] private  Image SecondStar;
    [SerializeField] private  Image ThirdStar;
    [SerializeField] private  Color activatedStarColor;
    [SerializeField] private Color unactivatedStarColor; 
    //use the unactivated star and cross color if u want to customise un activated colors

    [Header("cross")]
    [SerializeField] private Image FirstCross;
    [SerializeField] private Image SecondCross;
    [SerializeField] private Image ThirdCross;
    [SerializeField] private Color activatedCrossColor;
    [SerializeField] private Color unactivatedCrossColor;

    [Header("Winning")]
    [SerializeField] private Image FirstStarWinningScreen;
    [SerializeField] private Image SecondStarWinningScreen;
    [SerializeField] private Image ThirdStarWinningScreen;
    [Header("Task to complete")]

    [SerializeField]private Slider mSlider;

    private int cross = 0; //how many life they have

    private int amountOfScoreEarned = 0;
    private int TotalAmountOfPoints;

    private int numberOfProblemSolve = 0;
    private int TotalAmountOfProblem;

    private void Start()
    {
        CalculatingTotalPoints();
        mSlider.minValue = 0;
        mSlider.maxValue = TotalAmountOfPoints;
        mSlider.value = 0;
        SetSliderUI();

        //use the event manager like this and evoke it in any class pertaining that wants to evoke the listener
        EventManager.instance.AddListener(TypeOfEvent.MistakeEvent, ActivatedError);
        EventManager.instance.AddListener(TypeOfEvent.GameEnd, GameEnd);
        EventManager.instance.AddScoringListener(CompleteTask);
    }

    private void CalculatingTotalPoints()
    {
        var problems = FindObjectsOfType<ProblemSelector>();
        TotalAmountOfProblem = 0;
        TotalAmountOfPoints = 0;
        foreach(var problem in problems)
        {
            if(problem.MainProblem != Problem.MainProblem.FakeProblem)
            {
                TotalAmountOfProblem++;
                TotalAmountOfPoints += problem.ScoreToGive;
            }
        }
    }

    // call this function once task is completed
    public void CompleteTask(ProblemSelector problem)
    {
        amountOfScoreEarned += problem.ScoreToGive;
        numberOfProblemSolve += 1;
        if(numberOfProblemSolve == TotalAmountOfProblem)
        {
            //if have solve all the problem in the city then alert winevent
            EventManager.instance.RemovingScoringListener(CompleteTask);
            EventManager.instance.AlertListeners(TypeOfEvent.WinEvent);
        }
        DisplayCompletetask(problem);
    }

    //have to use this for testing purposes, can remove this afterwards!
    private void DisplayCompletetask(ProblemSelector solveProblem)
    {
        //use the problem here
        //finish a completed task
        HandleStars();
        SetSliderUI();
    }
    private void SetSliderUI() //change this later
    {
        //add coroutine to the progress to show the animation
        pointText.text = amountOfScoreEarned.ToString(); //set the text
        mSlider.value = amountOfScoreEarned; //show progress to the progress bar
    }

    private void HandleStars()
    {
        if (amountOfScoreEarned == TotalAmountOfPoints)
        {
            ThirdStar.color = activatedStarColor;
            SecondStar.color = activatedStarColor;
            FirstStar.color = activatedStarColor;

            ThirdStarWinningScreen.color = activatedStarColor;
            SecondStarWinningScreen.color = activatedStarColor;
            FirstStarWinningScreen.color = activatedStarColor;
        }
        else if (amountOfScoreEarned >= TotalAmountOfPoints * 0.70)// when the completed task is 
        {
            ThirdStar.color = unactivatedStarColor;
            SecondStar.color = activatedStarColor;
            FirstStar.color = activatedStarColor;

            FirstStarWinningScreen.color = unactivatedStarColor;
            ThirdStarWinningScreen.color = activatedStarColor;
            SecondStarWinningScreen.color = activatedStarColor;
        }
        else if (amountOfScoreEarned >= TotalAmountOfPoints / 2)// when the complete task is at least 50%
        {
            ThirdStar.color = unactivatedStarColor;
            SecondStar.color = unactivatedStarColor;
            FirstStar.color = activatedStarColor;

            ThirdStarWinningScreen.color = unactivatedStarColor;
            SecondStarWinningScreen.color = unactivatedStarColor;
            FirstStarWinningScreen.color = activatedStarColor;
        }
        else
        {
            ThirdStar.color = unactivatedStarColor;
            SecondStar.color = unactivatedStarColor;
            FirstStar.color = unactivatedStarColor;

            FirstStarWinningScreen.color = unactivatedStarColor;
            ThirdStarWinningScreen.color = unactivatedStarColor;
            SecondStarWinningScreen.color = unactivatedStarColor;
        }
    }

    //call this function if the player have error

    private const int amountToPunish = 20;
    public void ActivatedError()
    {
        PunishPlayer();
        HandleStars();
        cross++;
        if(cross == 3)
        {
            //add game over event here
            ThirdCross.color = activatedCrossColor;
            //make sure the other listeners know what to do
            EventManager.instance.RemoveListener(TypeOfEvent.MistakeEvent, ActivatedError);
            EventManager.instance.AlertListeners(TypeOfEvent.LoseEvent);
        }
        else if(cross == 2)
        {
            SecondCross.color = activatedCrossColor;
        }
        else
        {
            FirstCross.color = activatedCrossColor;
        }
        
    }

    public void PunishPlayer()
    {
        amountOfScoreEarned -= amountToPunish;
        if(amountOfScoreEarned < 0 ) amountOfScoreEarned = 0;
        SetSliderUI();
    }

    private void GameEnd()
    {
        if(amountOfScoreEarned >= TotalAmountOfPoints / 2)
        {
            EventManager.instance.AlertListeners(TypeOfEvent.WinEvent);
        }
        else
        {
            EventManager.instance.AlertListeners(TypeOfEvent.LoseEvent);
        }
    }

    public void SceneMover(int current)
    {
        Scene scene = SceneManager.GetActiveScene();
        UnityEngine.SceneManagement.SceneManager.LoadScene(current++);
    }
}
