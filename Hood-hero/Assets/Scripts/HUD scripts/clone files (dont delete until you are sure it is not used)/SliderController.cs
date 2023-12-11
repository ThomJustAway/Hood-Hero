using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    int progress = 0;
    public Slider slider;
    public float fillSpeed = 1f;

    public void UpdateProgress(int compelted, int total_Taask)  //5/7.5/10
    {
        if (compelted == total_Taask / 2)
        {
            progress = 5;

            if (slider.value < progress)
            {

                slider.value += fillSpeed * Time.deltaTime;

            }
        }
        if (compelted == total_Taask * 0.7)
        {
            progress = 7;

            if (slider.value < progress)
            {

                slider.value += fillSpeed * Time.deltaTime;

            }
        }
        if (compelted == total_Taask)
        {
            progress = 10;

            if (slider.value < progress)
            {

                slider.value += fillSpeed * Time.deltaTime;

            }
        }
    }
}
