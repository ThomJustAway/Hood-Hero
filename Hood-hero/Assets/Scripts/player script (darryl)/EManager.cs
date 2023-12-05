using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EManager : MonoBehaviour
{
    public TextMeshPro problem1;
    //public TextMeshPro problem2;
    //public TextMeshPro problem3;

    public Image FirstStar;
    public Image SecondStar;
    public Image ThirdStar;
    public Color StarColor;

    public Image FirstCross;
    public Image SecondCross;
    public Image ThirdCross;
    public Color CrossColor;

    public TextMeshPro WinText;

    int completed;
    int total_task;

    public GameObject OverFlow;
    public GameObject OldObject;

    public SliderController mSlider;

    public int i = 1;
    // Start is called before the first frame update
    private void Start()
    {
        problem1 = gameObject.GetComponent<TextMeshPro>();
        mSlider = GetComponent<SliderController>();
        FirstStar = GetComponent<Image>();
        StarColor = Color.yellow;
        CrossColor = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        //CompletedTask(i);
    }
    public int CompletedTask(int completed , int total_task)
    {

        if (completed == total_task/2)//50%
        {
            
            //CompleteFirstText.enabled = true;
            mSlider.UpdateProgress(completed,total_task);
            problem1.text = "test";
            FirstStar.color = StarColor;
            completed++;
            Debug.Log("first called +" + completed);
            return completed;
        }
        if (completed == total_task * 0.7)//75% 0.7
        {
            mSlider.UpdateProgress(completed, total_task);
            SecondStar.color = StarColor;
            completed++;
            //CompleteSecondText.enabled = true;
            return completed;
        }
        if (completed == total_task)//100%
        {
            mSlider.UpdateProgress(completed, total_task);
            ThirdStar.color = StarColor;
            completed++;
            //CompleteThirdText.enabled = true;
            //WinText.enabled = true;
            return completed;
        }

        return completed;
    }
    public int CrossCount(int lifes)
    {
        if (lifes == 1)
        {
            lifes++;
            FirstCross.color = CrossColor;
            return lifes;
        }
        if (lifes == 2)
        {
            lifes++;
            SecondCross.color = CrossColor;
            return lifes;
        }
        if (lifes == 3)
        {
            lifes++;
            ThirdCross.color = CrossColor;
            //RestartText.enabled = true;
            return lifes = 0;
        }
        return 1;
    }
    public void TooLate()
    {
        OverFlow.SetActive(true);
        OldObject.SetActive(false);
    }
    public void SceneMover(int current)
    {
        Scene scene = SceneManager.GetActiveScene();
        Debug.Log("Active Scene is '" + scene.name + "'.");
        UnityEngine.SceneManagement.SceneManager.LoadScene(current++);
    }
}
