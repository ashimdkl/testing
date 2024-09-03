using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RangeSliderController : MonoBehaviour
{
    public Slider meanSlider;
    public Slider deviationSlider;

    float deviation = 1;
    float mean = 0;

    public void SetDeviation(float deviation)
    {
        this.deviation = deviation;
        //Mathf.Clamp(deviation, 0, 1 - mean);
        deviationSlider.value = this.deviation;
    }
    public void SetMean(float mean)
    {
        this.mean = mean;
            //Mathf.Clamp(mean, 0, 1 - deviation);
        meanSlider.value = this.mean;


    }

    private void UpdateMeanRange()
    {

    }
}
