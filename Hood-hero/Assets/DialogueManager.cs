using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEditor.Experimental.GraphView;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Image actorImage;
    public Text actorName;
    public Text messageText;
    public RectTransform backgroundBox; 

    public Message[] currentMessages;
    Actor[] currentActors; 
    public int activeMessage = 0;
    public static bool isActive = false;

    public void OpenDialogue(Message[] messages, Actor[] actors)
    {
        currentMessages = messages; 
        currentActors = actors; 
        activeMessage = 0; 
        isActive = true;
        Debug.Log("Start conversation! Loaded messages: " + messages.Length); 
        DisplayMessage(); 
        backgroundBox.LeanScale(Vector3.one, 0.5f).setEaseInExpo();
    } 

    public void DisplayMessage()
    {
        Message messageToDisplay = currentMessages[activeMessage];
        messageText.text = messageToDisplay.message;

        Actor actorToDisplay = currentActors[messageToDisplay.actorId];
        actorName.text = actorToDisplay.name;
        actorImage.sprite = actorToDisplay.sprite;

        AnimateTextColor();
    }

    //public void NextMessage()
    //{ 
    //    activeMessage++; 
    //    GuideArrow guideArrow = GetComponent<GuideArrow>(); 

    //    if (activeMessage < currentMessages.Length)
    //    {
    //        DisplayMessage();
    //    }
    //    else
    //    {
    //        Debug.Log("Conversation ended!");
    //        backgroundBox.LeanScale(Vector3.zero, 0.5f).setEaseInExpo();
    //        isActive = false;  
    //    }
    //}  

    void AnimateTextColor()
    {
        LeanTween.textAlpha(messageText.rectTransform, 0, 0);
        LeanTween.textAlpha(messageText.rectTransform, 1, 0.5f);
    }

    // Start is called before the first frame update
    void Start()
    {
        backgroundBox.transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.touchCount > 0)
        //{
        //    Touch touch = Input.GetTouch(0);

        //    if (touch.phase == TouchPhase.Began)
        //    {
        //        NextMessage();
        //    }
        //}
    }
}