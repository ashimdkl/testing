using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineIndicatorController : BaseUIElement
{
    public PlotPointController plotPointController;
    public TemperatureType temperatureType;
    public void Initialize(PlotPointController plotPointController,TemperatureType temperatureType)
    {
        this.plotPointController = plotPointController;

        this.temperatureType = temperatureType;
    }

    public void Update()
    {
        if(temperatureType == TemperatureType.Mold)
        {
            RectTransform.anchoredPosition = new Vector2(0, plotPointController.RectTransform.anchoredPosition.y);
            RectTransform.sizeDelta = new Vector2(plotPointController.RectTransform.anchoredPosition.x, 5);
        }
        else 
        {
            RectTransform.anchoredPosition = new Vector2(plotPointController.RectTransform.anchoredPosition.x, 0);
            RectTransform.sizeDelta = new Vector2(5, plotPointController.RectTransform.anchoredPosition.y);
        }

    }

}
