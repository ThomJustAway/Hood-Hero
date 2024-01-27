using UnityEngine;
using UnityEngine.UI;

public class GuidePopUp : MonoBehaviour
{
    public GameObject modalWindow;
    public Text headerText;
    public Image image;
    public Text bodyText;
    public TutorialContinue tutorialCont;

    public static GuidePopUp instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            
            Time.timeScale = 0f;
        }
        else
            Destroy(gameObject); // Destroy the game object this script is attached to
    }

    public void ShowModal(string header, Sprite imageSprite, string body)
    {
        headerText.text = header;
        image.sprite = imageSprite;
        bodyText.text = body;  

        modalWindow.SetActive(true);
    }

    public void HideModal()
    {
        Time.timeScale = 1f;
        modalWindow.SetActive(false);
    } 
     
    public void OnBtnClickShowModal()
    {
        tutorialCont.ResetCurrentIndex();
        modalWindow.SetActive(true);
    }
}
