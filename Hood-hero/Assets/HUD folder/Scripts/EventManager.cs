using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour
{
    //int lives;
    //public float[] taskcounter;

    public GameObject StartingLives;
    public GameObject FirstLiveText;
    public GameObject SecondLiveText;
    public GameObject ThirdLiveText;
    public GameObject RestartText;

    public GameObject StatingCompleated;
    public GameObject CompleatFirstText;
    public GameObject CompleatSecondText;
    public GameObject CompleatThirdText;
    public GameObject WinText;

    int compleated;

    public GameObject OverFlow;
    public GameObject OldObject;

    //public int i = 1;

    void Update()
    {

        //CompleatedTask(i);
    }

    public int CompleatedTask(int compleated)
    {

        if (compleated == 1)
        {
            compleated++;
            CompleatFirstText.SetActive(true);
            StatingCompleated.SetActive(false);
            //Debug.Log("first called +" + compleated);
            return compleated;
        }
        if (compleated == 2)
        {
            compleated++;
            CompleatSecondText.SetActive(true);
            CompleatFirstText.SetActive(false);
            return compleated;
        }
        if (compleated == 3)
        {
            compleated++;
            CompleatThirdText.SetActive(true);
            CompleatSecondText.SetActive(false);
            WinText.SetActive(true);
            return compleated;
        }

        return 0;
    }
    public int CrossCount(int lives)
    {


        if (lives == 1)
        {
            lives++;
            FirstLiveText.SetActive(true);
            StartingLives.SetActive(false);
            return lives;
        }
        if (lives == 2)
        {
            lives++;
            SecondLiveText.SetActive(true);
            FirstLiveText.SetActive(false);
            return lives;
        }
        if (lives == 3)
        {
            lives++;
            ThirdLiveText.SetActive(true);
            SecondLiveText.SetActive(false);
            RestartText.SetActive(true);
            return lives = 0;
        }
        return 0;
    }
    public void TooLate()
    {
        OverFlow.SetActive(true);
        OldObject.SetActive(false);
    }
    public void SceanMover(int current)
    {
        Scene scene = SceneManager.GetActiveScene();
        Debug.Log("Active Scene is '" + scene.name + "'.");
        UnityEngine.SceneManagement.SceneManager.LoadScene(current++);
    }
}

