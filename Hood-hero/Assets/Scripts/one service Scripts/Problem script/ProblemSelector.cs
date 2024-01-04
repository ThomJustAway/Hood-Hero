using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Problem;
using UnityEngine.UI;
using System;
using HoodHeroUI;
using pattern;
using UnityEditor.Experimental.GraphView;
using Assets.Scripts.one_service_Scripts.pattern;
using Unity.Mathematics;
//[RequireComponent(typeof(ProblemPopup))]
public class ProblemSelector : MonoBehaviour 
{
    [SerializeField] private MainProblem mainProblem = MainProblem.Cleanliness;
    [SerializeField] private SubProblem subProblem = SubProblem.DirtyPublicAreas;
    public MainProblem MainProblem { get { return mainProblem; } }
    public SubProblem SubProblem { get { return subProblem; } }

    [SerializeField] private bool isSeriousProblem = false;
    public bool IsSeriousProblem { get { return isSeriousProblem; } }
    [SerializeField] private int scoreToGive;
    public int ScoreToGive { get { return scoreToGive; } }

    [SerializeField]  private int timer = 0; //how many second before the trigger occur
    #region clock
    private Slider slider;
    private Image sliderColor;
    [SerializeField] private float TimeToDecrease = 0.2f;
    [SerializeField] private Color startingColor = Color.yellow;
    [SerializeField] private Color endingColor = Color.red;

    #endregion
    #region images
    [SerializeField] private Sprite closeUpImage;
    [SerializeField] private Sprite farAwayImage;
    [SerializeField] private DetailOfTheProblem[] details;
    public Sprite CloseupImage { get { return closeUpImage; } }
    public Sprite FarAwayImage { get { return farAwayImage; } }
    public DetailOfTheProblem[] Details { get {  return details; } }
    #endregion

    public void IsSolve()
    {
        EventManager.instance.AlertScoringListener(this);
        EventManager.instance.RemoveTimingListener(OnceTimePass);
        gameObject.SetActive(false);
    }

    private void Start()
    {
        if (IsSeriousProblem)
        {
            var sliderGameobject = Instantiate(PrefabManager.instance.clockPrefab,transform); 
            //just create the clock to show the progress of the serious problem
            Vector3 newPosition = sliderGameobject.transform.position;
            newPosition.y += 1f;
            newPosition.z = 0f;
            sliderGameobject.transform.position = newPosition;
            
            //setting up camera
            Canvas sliderCanvas = sliderGameobject.GetComponent<Canvas>();
            sliderCanvas.worldCamera = Camera.main;
            sliderCanvas.sortingOrder = 1;

            slider = sliderGameobject.GetComponentInChildren<Slider>();
            sliderColor = slider.fillRect.GetComponent<Image>();
            slider.value = 1;
            EventManager.instance.AddTimingListener(OnceTimePass);
        }
    }

    private void OnceTimePass(int remainingTime)
    {
        float difference = (float)remainingTime/(float)timer;
        float progress = 1 - difference;

        sliderColor.color = Color.Lerp(startingColor,endingColor, difference);

        StopAllCoroutines();
        StartCoroutine(EaseProgress(progress));

        //else just spawn the clock timer
        if (remainingTime == timer)
        {//so if the time pass is the same as the time need to trigger the serious problem
            EventManager.instance.AlertListeners(TypeOfEvent.MistakeEvent); //deduct life from the player
            EventManager.instance.RemoveTimingListener(OnceTimePass);
            slider.gameObject.SetActive(false); //dont show it anymore!
        }
    }

    private IEnumerator EaseProgress(float targetProgress)
    {
        float currentProgress = slider.value;
        float elapseTime = 0f;

        while (elapseTime < TimeToDecrease)
        {
            slider.value = Mathf.Lerp(currentProgress, targetProgress,
                elapseTime / TimeToDecrease);
            elapseTime += Time.deltaTime;
            yield return null;
        }

        slider.value = targetProgress;
    }
}

[System.Serializable]
public struct DetailOfTheProblem
{
    [TextArea(4, 10)]
    public string detail;
    public bool isCorrect;

    public DetailOfTheProblem(string detail, bool isCorrect)
    {
        this.detail = detail;
        this.isCorrect = isCorrect;
    }
}