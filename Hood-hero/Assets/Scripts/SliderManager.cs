using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SliderManager : MonoBehaviour
{
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
    [SerializeField]private Image SecondCross;
    [SerializeField]private Image ThirdCross;
    [SerializeField] private Color activatedCrossColor;
    [SerializeField] private Color unactivatedCrossColor;

    [Header("Task to complete")]
    private int completedTask = 0;
    [SerializeField]private int totalTask;

    [SerializeField]private Slider mSlider;

    private int cross = 0; //how many life they have

    private void Start()
    {
        mSlider.minValue = 0;
        mSlider.maxValue = totalTask;
        mSlider.value = 0;
        SetSliderUI();
    }



    // call this function once task is completed
    public void CompleteTask() 
    {
        completedTask++; //finish a completed task

        if (completedTask == totalTask)//100%
        {
            ThirdStar.color = activatedStarColor;
        }
        else if (completedTask >= totalTask * 0.70)// when the completed task is 
        {
            SecondStar.color = activatedStarColor;
        }
        else if (completedTask == totalTask / 2)// when the complete task is at least 50%
        {
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

    public void SceneMover(int current)
    {
        Scene scene = SceneManager.GetActiveScene();
        Debug.Log("Active Scene is '" + scene.name + "'.");
        UnityEngine.SceneManagement.SceneManager.LoadScene(current++);
    }
}
