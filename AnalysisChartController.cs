using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class AnalysisChartController : MonoBehaviour
{
    RectTransform rectTransform;

    public TemperatureData moldTemperatureData;
    public TemperatureData barrelTemperatureData;

    public float medianCorrect;
    public float stdCorrect;

    [Range(370,430)]
    public float moldTemperature;
    [Range(390, 450)]
    public float barrelTemperature;

    float randomMoldTemperature,randomBarrelTemp;

    public PlotPointController plotPointController;
    public LineIndicatorController moldTempLineIndicatorController;
    public LineIndicatorController barrelTempLineIndicatorController;

    public DeltaIndicator deltaIndicator;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();

        plotPointController=Instantiate(plotPointController,rectTransform.transform).GetComponent<PlotPointController>();

        moldTempLineIndicatorController.Initialize(plotPointController,TemperatureType.Mold);
        barrelTempLineIndicatorController.Initialize(plotPointController, TemperatureType.Barrel);

        deltaIndicator.Initialize(plotPointController.RectTransform);
    }

    void UpdatePointPosition(float xPercentage, float yPercentage)
    {
        plotPointController.UpdatePosition(xPercentage, yPercentage);
    }

    private void Update()
    {
        UpdatePointPosition(barrelTemperatureData.GetPercentageInBounds(barrelTemperature), moldTemperatureData.GetPercentageInBounds(moldTemperature));
    }

    void CalculateMean(float barrelTemperature, float randomBarrelTemperature)
    {

    }
    void CalculateDeviation(float moldTemperature, float randomMoldTemperature)
    {

    }
}
