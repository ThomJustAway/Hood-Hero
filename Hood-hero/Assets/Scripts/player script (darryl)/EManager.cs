using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//public class EManager : MonoBehaviour
//{
//    public TextMeshPro problem1;
//    //public TextMeshPro problem2;
//    //public TextMeshPro problem3;

//    public Image FirstStar;
//    public Image SecondStar;
//    public Image ThirdStar;
//    public Color StarColor;

//    public Image FirstCross;
//    public Image SecondCross;
//    public Image ThirdCross;
//    public Color CrosColor;

//    public TextMeshPro WinText;

//    int compleated;
//    int total_task;

//    public GameObject OverFlow;
//    public GameObject OldObject;

//    public SliderController mSlider;

//    public int i = 1;
//    // Start is called before the first frame update
//    private void Start()
//    {
//        problem1 = gameObject.GetComponent<TextMeshPro>();
//        mSlider = GetComponent<SliderController>();
//        FirstStar = GetComponent<Image>();
//        StarColor = Color.yellow;
//        CrosColor = Color.red;
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        //CompleatedTask(i);
//    }
//    public int CompleatedTask(int compleated , int total_task)
//    {

//        if (compleated == total_task/2)//50%
//        {
            
//            //CompleatFirstText.enabled = true;
//            mSlider.UpdateProgress(compleated,total_task);
//            problem1.text = "test";
//            FirstStar.color = StarColor;
//            compleated++;
//            Debug.Log("first called +" + compleated);
//            return compleated;
//        }
//        if (compleated == total_task * 0.7)//75% 0.7
//        {
//            mSlider.UpdateProgress(compleated, total_task);
//            SecondStar.color = StarColor;
//            compleated++;
//            //CompleatSecondText.enabled = true;
//            return compleated;
//        }
//        if (compleated == total_task)//100%
//        {
//            mSlider.UpdateProgress(compleated, total_task);
//            ThirdStar.color = StarColor;
//            compleated++;
//            //CompleatThirdText.enabled = true;
//            //WinText.enabled = true;
//            return compleated;
//        }

//        return compleated;
//    }
//    public int CrossCount(int lives)
//    {


//        if (lives == 1)
//        {
//            lives++;
//            FirstCross.color = CrosColor;
//            return lives;
//        }
//        if (lives == 2)
//        {
//            lives++;
//            SecondCross.color = CrosColor;
//            return lives;
//        }
//        if (lives == 3)
//        {
//            lives++;
//            ThirdCross.color = CrosColor;
//            //RestartText.enabled = true;
//            return lives = 0;
//        }
//        return 1;
//    }
//    public void TooLate()
//    {
//        OverFlow.SetActive(true);
//        OldObject.SetActive(false);
//    }
//    public void SceanMover(int current)
//    {
//        Scene scene = SceneManager.GetActiveScene();
//        Debug.Log("Active Scene is '" + scene.name + "'.");
//        UnityEngine.SceneManagement.SceneManager.LoadScene(current++);
//    }
//}
