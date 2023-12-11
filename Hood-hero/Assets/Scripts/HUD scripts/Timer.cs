using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using pattern;

namespace HoodHeroUI{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI uiText;

        public int Duration;

        private int remainingDuration;
        private ProblemSelector[] seriousProblems;


        private void Start()
        {
            //does checking for time also in charge of the UI
            seriousProblems = FindObjectsOfType<ProblemSelector>()
                .Where(problem => problem.IsSeriousProblem).ToArray();
            Begin();
        }

        private void Begin()
        {
            remainingDuration = Duration;
            StartCoroutine(UpdateTimer());
        }

        private IEnumerator UpdateTimer()
        {
            while (remainingDuration >= 0)
            {
                uiText.text = $"{remainingDuration / 60:00} : {remainingDuration % 60:00}";
                remainingDuration--;
                CheckProblem();
                yield return new WaitForSeconds(1f);
            }
            OnEnd();
        }

        //look here
        private void CheckProblem()
        {
            List<ProblemSelector> newArray = new List<ProblemSelector>();
            foreach(ProblemSelector problem in seriousProblems)
            {
                int timeStamp = Duration - problem.CountDown;
                if (timeStamp > remainingDuration)
                { //that mean the problem has become a serious problem
                    Debug.Log("serious problem activated");
                    //activate error event here!!
                }
                else
                {
                    newArray.Add(problem);
                }
            }
            seriousProblems = newArray.ToArray();   
        }

        private void OnEnd()
        {
            //add event for end function
            EventManager.instance.AlertListeners(TypeOfEvent.LoseEvent);
        }
    }
}
