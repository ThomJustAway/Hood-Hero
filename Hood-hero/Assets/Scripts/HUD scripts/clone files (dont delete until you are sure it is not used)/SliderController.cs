using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    int progress = 0;
    public Slider slider;
    public float fillSpeed = 1f;

     //5/7.5/10
    
        public void UpdateProgress(int taskDone)  //5/7.5/10
        {

            progress = taskDone;


            if (slider.value < progress)
            {

                slider.value += fillSpeed * Time.deltaTime;

            }
            if (slider.value > progress)
            {
                slider.value += fillSpeed * Time.deltaTime;
            }

        }
    
}

