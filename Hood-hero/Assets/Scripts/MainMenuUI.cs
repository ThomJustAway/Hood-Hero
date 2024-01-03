using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField]
    Button StartGame;
    [SerializeField]
    Button Quit;
    // Start is called before the first frame update
    void Start()
    {
        StartGame.onClick.AddListener(NewGame);
        Quit.onClick.AddListener(QuitGame);
    }
    private void QuitGame()
    {
        Application.Quit();
    }


    private void NewGame()
    {
        ScenesManager.instance.LoadNew();
    }

   
}
