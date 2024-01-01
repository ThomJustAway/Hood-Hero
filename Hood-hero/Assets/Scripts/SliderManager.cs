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
    [SerializeField]private TextMeshProUGUI amountOfProblemText;

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
    private int completedTask = 0;
    [SerializeField]private int totalTask;

    [SerializeField]private Slider mSlider;

    private int cross = 0; //how many life they have

    private void Start()
    {
        CalculatingTotalTask();
        mSlider.minValue = 0;
        mSlider.maxValue = totalTask;
        mSlider.value = 0;
        SetSliderUI();

        //use the event manager like this and evoke it in any class pertaining that wants to evoke the listener
        EventManager.instance.AddListener(TypeOfEvent.MistakeEvent, ActivatedError);
        EventManager.instance.AddListener(TypeOfEvent.GameEnd, GameEnd);
        EventManager.instance.AddScoringListener(CompleteTask);
    }

    private void CalculatingTotalTask()
    {
        var problems = FindObjectsOfType<ProblemSelector>();
        totalTask = 0;
        foreach(var problem in problems)
        {
            if(problem.MainProblem != Problem.MainProblem.FakeProblem)
            {
                totalTask++;
            }
        }
    }

    // call this function once task is completed
    public void CompleteTask(ProblemSelector problem)
    {
        DisplayCompletetask();
    }

    //have to use this for testing purposes, can remove this afterwards!
    private void DisplayCompletetask()
    {
        //use the problem here
        completedTask++; //finish a completed task

        if (completedTask == totalTask)//100%
        {
            ThirdStar.color = activatedStarColor;
            SecondStar.color = activatedStarColor;
            FirstStar.color = activatedStarColor;

            FirstStarWinningScreen.color = activatedStarColor;
            ThirdStarWinningScreen.color = activatedStarColor;
            SecondStarWinningScreen.color = activatedStarColor;

            //has already won!
            EventManager.instance.RemovingScoringListener(CompleteTask);
            EventManager.instance.AlertListeners(TypeOfEvent.WinEvent);
        }
        else if (completedTask >= totalTask * 0.70)// when the completed task is 
        {
            SecondStar.color = activatedStarColor;
            FirstStar.color = activatedStarColor;

            SecondStarWinningScreen.color = activatedStarColor;
            FirstStarWinningScreen.color = activatedStarColor;
        }
        else if (completedTask == totalTask / 2)// when the complete task is at least 50%
        {
            FirstStarWinningScreen.color = activatedStarColor;
            FirstStar.color = activatedStarColor;
        }

        SetSliderUI();
    }

    //call this function if the player have error
    public void ActivatedError()
    {
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

    private void SetSliderUI()
    {
        //add coroutine to the progress to show the animation
        amountOfProblemText.text = $"Problems:\n {completedTask}/{totalTask}"; //set the text
        mSlider.value = completedTask; //show progress to the progress bar
    }

    private void GameEnd()
    {
        if(completedTask >= totalTask / 2)
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
