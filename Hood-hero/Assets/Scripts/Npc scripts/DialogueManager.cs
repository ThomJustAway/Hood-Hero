using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEditor.Experimental.GraphView;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance { get; private set; }

    [SerializeField] public Image actorImage;
    [SerializeField] public Text actorName;
    [SerializeField] public Text messageText;
    [SerializeField] public RectTransform backgroundBox; 

    public Message[] currentMessages; 
    public int activeMessage = 0;
    public bool isActive = false;
    void Start()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            print("Can't have more than one instance of dialogue manager");
            Destroy(Instance);  
        }
        backgroundBox.transform.localScale = Vector3.zero;
    }

    private void Update()
    {
        //change this later
        if(messageText != null && Input.GetKeyUp(KeyCode.Space))
        {
            //will try and do next message
            NextMessage();
        }
    }
    public void OpenDialogueSession(Message[] messages)
    {
        currentMessages = messages;
        activeMessage = 0;
        DisplayMessage();
        backgroundBox.LeanScale(Vector3.one, 0.5f).setEaseInExpo();
    }

    public void DisplayMessage()
    {
        Message messageToDisplay = currentMessages[activeMessage];
        messageText.text = messageToDisplay.message;

        actorName.text = messageToDisplay.name;
        actorImage.sprite = messageToDisplay.sprite;

        AnimateTextColor();
    }

    public void NextMessage()
    {
        activeMessage++;
        if(activeMessage < currentMessages.Length)
        {
            DisplayMessage();
        }
        else
        {
            CloseDialogSession();
        }
    }

    public void ResetDialogue()
    {
        activeMessage = 0;
        currentMessages = null;
        isActive = false;
    }

    private void CloseDialogSession()
    {
        currentMessages = null; 

        // Play the background fade
        backgroundBox.LeanScale(Vector3.zero, 0.5f).setEaseInExpo();

        // Access ActivateGuide script to signal the end of dialogue
        ActivateGuide activateGuide = GameObject.FindGameObjectWithTag("Player").GetComponent<ActivateGuide>();
        if (activateGuide != null)
        {
            activateGuide.DialogueComplete(); // Signal the end of dialogue 
        }
        else
        {
            Debug.LogError("Script not found!");
        }
    }

    void AnimateTextColor()
    {
        LeanTween.textAlpha(messageText.rectTransform, 0, 0);
        LeanTween.textAlpha(messageText.rectTransform, 1, 0.5f);
    }


}