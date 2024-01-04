using UnityEngine;

public class TutorialContinue : MonoBehaviour
{
    private string[] messages =
    {
        "To interact with NPC's, walk up to them!",
        "You can report problems by clicking this pop-up!",
        "Solving problems gives you points!",
        "Stop problems from escalating. Failing to gives you a cross!",
        "Inaccurate reports give you a cross!",
        "If you get 3 crosses, you lose!", 
    };

    public Sprite[] sprites; // Array of sprites to correspond with messages
    private int currentIndex = 0;

    public void GetNewMessage()
    {
        if (currentIndex < messages.Length)
        {
            GuidePopUp.instance.ShowModal("Tutorial", sprites[currentIndex], messages[currentIndex]);
            currentIndex++;
        }
        else
        {
            GuidePopUp.instance.HideModal();
        }
    }
}
