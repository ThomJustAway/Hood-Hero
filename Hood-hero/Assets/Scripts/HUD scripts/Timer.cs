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
                int amountOfTimePass = Duration - remainingDuration;
                EventManager.instance.AlertTimingListener(amountOfTimePass);
                uiText.text = $"{remainingDuration / 60:00} : {remainingDuration % 60:00}";
                remainingDuration--;
                yield return new WaitForSeconds(1f);
            }
            OnEnd();
        }    

        private void OnEnd()
        {
            //add event for end function
            EventManager.instance.RemoveAllTimingListener();
            EventManager.instance.AlertListeners(TypeOfEvent.LoseEvent);
        }
    }
}
