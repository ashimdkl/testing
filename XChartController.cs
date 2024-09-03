using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XChartController : ChartController
{

    public override void Start()
    {   
        maxValue = ServiceLocator.Instance.MachineController.productSetVariables.fullRange.y;
        base.Start();
    }
    public override void CreatePlotPoint(TrackedProductsSet trackedProducts)
    {


        base.CreatePlotPoint(trackedProducts);

        trackedProducts.MeanSetEvent += currentTrackedSetPlotPointController.SetValue;

    }

    void ExtendGraphBounds()
    {
        graphRectTransform.sizeDelta += new Vector2(xDistance, 0);
    }
}
