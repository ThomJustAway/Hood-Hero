using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//namespace extracopy
//{
//    public class PauseMenu : MonoBehaviour
//    {
//        public static bool GameIsPaused = false;

//        public GameObject pauseMenuUI;

//        void Update()
//        {
//            // Check for Escape key input to toggle between pause and resume
//            if (Input.GetKeyUp(KeyCode.Escape))
//            {
//                if (GameIsPaused)
//                {
//                    Resume();
//                }
//                else
//                {
//                    Pause();
//                }
//            }
//        }

//        public void Resume()
//        {
//            pauseMenuUI.SetActive(false);
//            // Restore the time scale to normal
//            Time.timeScale = 1f;
//            // Update the pause state
//            GameIsPaused = false;
//        }

//        public void Pause()
//        {
//            pauseMenuUI.SetActive(true);
//            // Set the time scale to pause the game
//            Time.timeScale = 0f;
//            // Update the pause state
//            GameIsPaused = true;
//        }

//        public void LoadMenu(string sceneName)
//        {
//            // Restore the time scale to normal
//            Time.timeScale = 1f;
//            SceneManager.LoadScene(sceneName);
//        }

//        public void QuitGame(string sceneName)
//        {
//            // Restore the time scale to normal
//            Time.timeScale = 1f;
//            SceneManager.LoadScene(sceneName);
//        }
//    }


//    public class SliderController : MonoBehaviour
//    {
//        int progress = 0;
//        public Slider slider;
//        public float fillSpeed = 1f;

//        public void UpdateProgress(int compelted, int total_Taask)  //5/7.5/10
//        {
//            if (compelted == total_Taask / 2)
//            {
//                progress = 5;

//                if (slider.value < progress)
//                {

//                    slider.value += fillSpeed * Time.deltaTime;

//                }
//            }
//            if (compelted == total_Taask * 0.7)
//            {
//                progress = 7;

//                if (slider.value < progress)
//                {

//                    slider.value += fillSpeed * Time.deltaTime;

//                }
//            }
//            if (compelted == total_Taask)
//            {
//                progress = 10;

//                if (slider.value < progress)
//                {

//                    slider.value += fillSpeed * Time.deltaTime;

//                }
//            }
//        }
//    }

//}

