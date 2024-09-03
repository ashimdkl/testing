using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SChartController : ChartController
{

    public override void CreatePlotPoint(TrackedProductsSet trackedProducts)
    {
        base.CreatePlotPoint(trackedProducts);

        trackedProducts.StandardDeviationSetEvent += currentTrackedSetPlotPointController.SetValue;
    }
    void ExtendGraphBounds()
    {
        graphRectTransform.sizeDelta += new Vector2(xDistance, 0);
    }
}
