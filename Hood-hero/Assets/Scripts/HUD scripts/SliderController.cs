using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HoodHeroUI
{
    public class SliderController : MonoBehaviour
    {
        int progress;
        public Slider slider;
        public float fillSpeed = 1f;

        public void UpdateProgress(int completed, int total_Task)  //5/7.5/10
        {
            if (completed == total_Task / 2)
            {
                progress = 5;

                if (slider.value < progress)
                {

                    slider.value += fillSpeed * Time.deltaTime;

                }
            }
            if (completed == total_Task * 0.7)
            {
                progress = 7;

                if (slider.value < progress)
                {

                    slider.value += fillSpeed * Time.deltaTime;

                }
            }
            if (completed == total_Task)
            {
                progress = 10;

                if (slider.value < progress)
                {

                    slider.value += fillSpeed * Time.deltaTime;

                }
            }
        }
    }

}
