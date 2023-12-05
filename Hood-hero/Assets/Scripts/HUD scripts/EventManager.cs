using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

namespace HoodHeroUI
{
    public class EventManager : MonoBehaviour
    {
        //int lives;
        //public float[] taskcounter;

        public GameObject StartingLives;
        public GameObject FirstLifeText;
        public GameObject SecondLifeText;
        public GameObject ThirdLifeText;
        public GameObject RestartText;

        public GameObject StatingCompleted;
        public GameObject CompleteFirstText;
        public GameObject CompleteSecondText;
        public GameObject CompleteThirdText;
        public GameObject WinText;

        [HideInInspector] public int completed = 0;

        public GameObject OverFlow;
        public GameObject OldObject;

        //public int i = 1;

        void Update()
        {

            //CompletedTask(i);
        }

        public int CompletedTask(int completed)
        {

            if (completed == 1)
            {
                completed++;
                CompleteFirstText.SetActive(true);
                StatingCompleted.SetActive(false);
                //Debug.Log("first called +" + completed);
                return completed;
            }
            if (completed == 2)
            {
                completed++;
                CompleteSecondText.SetActive(true);
                CompleteFirstText.SetActive(false);
                return completed;
            }
            if (completed == 3)
            {
                completed++;
                CompleteThirdText.SetActive(true);
                CompleteSecondText.SetActive(false);
                WinText.SetActive(true);
                return completed;
            }

            return 0;
        }
        public int CrossCount(int lives)
        {


            if (lives == 1)
            {
                lives++;
                FirstLifeText.SetActive(true);
                StartingLives.SetActive(false);
                return lives;
            }
            if (lives == 2)
            {
                lives++;
                SecondLifeText.SetActive(true);
                FirstLifeText.SetActive(false);
                return lives;
            }
            if (lives == 3)
            {
                lives++;
                ThirdLifeText.SetActive(true);
                SecondLifeText.SetActive(false);
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
        public void SceneMover(int current)
        {
            Scene scene = SceneManager.GetActiveScene();
            Debug.Log("Active Scene is '" + scene.name + "'.");
            UnityEngine.SceneManagement.SceneManager.LoadScene(current++);
        }
    }

}

