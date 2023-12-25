using pattern;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudController : MonoBehaviour
{
    [SerializeField] private GameObject winningScreen;
    [SerializeField] private GameObject losingScreen;

    private void Start()
    {
        EventManager.instance.AddListener(TypeOfEvent.WinEvent, OnWin);
        EventManager.instance.AddListener(TypeOfEvent.LoseEvent, OnLose);
    }

    private void OnWin()
    {
        winningScreen.SetActive(true);
        Time.timeScale = 0f; //stop the game 
    }

    private void OnLose()
    {
        losingScreen.SetActive(true);
        Time.timeScale = 0f;
    }

}
