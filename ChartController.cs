using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChartController : MonoBehaviour
{
    public ProductRunSet productRunSet;
    public float maxValue = 0;

    public int xDistance;

    public RectTransform plotPointDataSet;

    [NonSerialized]
    public RectTransform graphRectTransform;

    public TrackedSetPlotPointController currentTrackedSetPlotPointController;

    public virtual void Start()
    {
        graphRectTransform = GetComponent<RectTransform>();
        ServiceLocator.Instance.MachineController.NewProductRunSetCreatedEvent += ProductSetInitialized;
    }

    public virtual void CreatePlotPoint(TrackedProductsSet trackedProducts)
    {
        RectTransform plotPoint = Instantiate(plotPointDataSet, transform);

        UpdateGraphBounds();

        plotPoint.anchoredPosition += new Vector2(trackedProducts.SetNumber * xDistance, 0);

        currentTrackedSetPlotPointController = plotPoint.GetComponent<TrackedSetPlotPointController>();

        currentTrackedSetPlotPointController.Initialize(trackedProducts, maxValue);


    }
    void ProductSetInitialized(ProductRunSet productRunSet)
    {
        this.productRunSet = productRunSet;
        ServiceLocator.Instance.MachineController.productRunSet.NewSetOfTrackedProductsCreatedEvent += CreatePlotPoint;
    }

    void UpdateGraphBounds()
    {
        graphRectTransform.sizeDelta = new Vector2(productRunSet.setCounter * xDistance, graphRectTransform.rect.height);
    }
}
