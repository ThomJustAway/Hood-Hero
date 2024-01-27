using System;
using UnityEngine;

public class TutorialContinue : MonoBehaviour
{
    //private string[] messages =
    //{
    //    "To interact with NPC's, walk up to them!",
    //    "You can report problems by clicking this pop-up!",
    //    "Solving problems gives you points!",
    //    "Stop problems from escalating. Failing to gives you a cross!",
    //    "Inaccurate reports give you a cross!",
    //    "If you get 3 crosses, you lose!", 
    //};

    //public Sprite[] sprites; // Array of sprites to correspond with messages

    [SerializeField] private TutorialMessage[] tutorialMessages;
    [SerializeField] private GameObject backButton;

    private int currentIndex = 0;

    private void Start()
    {
        ShowMessage();
        backButton.SetActive(false);
    }

    private void ShowMessage()
    {
        var message = tutorialMessages[currentIndex];
        GuidePopUp.instance.ShowModal("Tutorial", message.image, message.text);
    }

    public void GetNewMessage()
    {
        currentIndex++;
        if (currentIndex < tutorialMessages.Length)
        {
            backButton.SetActive(true); 
            ShowMessage();
        }
        else
        {
            GuidePopUp.instance.HideModal();
        }
    }

    public void ReturnMessage()
    {
        currentIndex--;
        if(currentIndex == 0)
        {
            backButton.SetActive(false);
        }
        ShowMessage();

    } 
     
    public void ResetCurrentIndex()
    {
        backButton.SetActive(false);
        currentIndex = 0; 
        ShowMessage();  
    }
}

[Serializable]
public struct TutorialMessage
{
    public Sprite image;
    [TextArea(4,4)]
    public string text;
}
