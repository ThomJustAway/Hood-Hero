using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    int progress = 0;
    public Slider slider;

    public void UpdateProgress()
    {
        progress++;
        slider.value = progress;
    }
}
