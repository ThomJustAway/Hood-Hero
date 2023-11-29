using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChangeBackground : MonoBehaviour
{
    [SerializeField] private Image background;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private Color backgroundColor = Color.blue;
    [SerializeField] private Color startingColor;
    [SerializeField] private Color buttonStartingColor;
    [SerializeField] private float colorFadeSpeed = 1.0f;

    private bool isActivated = false;
    [SerializeField] private bool isSubCategory;
    // Start is called before the first frame update
    void Start()
    {
        //startingColor = background.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleBackgroundColor()
    {
        float t = 0;
        isActivated = !isActivated;
        if (isActivated == true)
        {
            if (isSubCategory == true)
            {
                background.color = Color.Lerp(buttonStartingColor, backgroundColor, t += Time.deltaTime);
                text.color = Color.Lerp(Color.black, Color.white, t += Time.deltaTime);
            }
            else
            {
                background.color = Color.Lerp(startingColor, backgroundColor, t += Time.deltaTime);
                text.color = Color.Lerp(Color.black, Color.white, t += Time.deltaTime);
            }
        }
        else if (isActivated == false)
        {
            if (isSubCategory == true)
            {
                background.color = Color.Lerp(backgroundColor, buttonStartingColor, t += Time.deltaTime);
                text.color = Color.Lerp(Color.white, Color.black, t += Time.deltaTime);
            }
            else
            {
                background.color = Color.Lerp(backgroundColor, startingColor, t += Time.deltaTime);
                text.color = Color.Lerp(Color.white, Color.black, t += Time.deltaTime);
            }
        }
    }
}