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

    public GameObject FirstLiveText;
    public GameObject SecondLiveText;
    public GameObject ThirdLiveText;
    public GameObject RestartText;


    public GameObject CompleatFirstText;
    public GameObject CompleatSecondText;
    public GameObject CompleatThirdText;
    public GameObject WinText;

    int compleated;

    public GameObject OverFlow;
    public GameObject OldObject;

    public int i = 1;

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
            Debug.Log("first called +" + compleated);
            return compleated;
        }
        if (compleated == 2)
        {
            compleated++;
            CompleatSecondText.SetActive(true);
            return compleated;
        }
        if (compleated == 3)
        {
            compleated++;
            CompleatThirdText.SetActive(true);
            WinText.SetActive(true);
            return compleated;
        }

        return compleated;
    }
    public int CrossCount(int lives)
    {


        if (lives == 1)
        {
            lives++;
            FirstLiveText.SetActive(true);
            return lives;
        }
        if (lives == 2)
        {
            lives++;
            SecondLiveText.SetActive(true);
            return lives;
        }
        if (lives == 3)
        {
            lives++;
            ThirdLiveText.SetActive(true);
            RestartText.SetActive(true);
            return lives = 0;
        }
        return 1;
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

