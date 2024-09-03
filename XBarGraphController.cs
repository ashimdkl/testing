using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XBarGraphController : BarGraphController
{
    public TrackedProductsSet capturedDataSet;
    public Vector2 valueBounds;

    public override void Start()
    {
        base.Start();
        ServiceLocator.Instance.MachineController.NewProductRunSetCreatedEvent += SetNewProductSet;
    }

    void SetValueBounds(Vector2 value)
    { valueBounds = value; }

    public override void SetNewProductSet(ProductRunSet newProductSet)
    {
        base.SetNewProductSet(newProductSet);

        //newProductSet.productSetVariables.RunValueRangeSetEvent += SetValueBounds;

        productRunSet.NewSetOfTrackedProductsCreatedEvent += SetNewDataSet;
    }
    public void SetNewDataSet(TrackedProductsSet trackedProducts)
    {
        //ResetGraph();
        capturedDataSet = trackedProducts;
        trackedProducts.ProductAddedToSetEvent += UpdateData;
    }
    public void UpdateData(OutputProduct outputProduct)
    {
        ResetData();

        int largestPoint = 0;
        foreach (TrackedProductsSet data in productRunSet.GetTrackedProductsSets())
        {
            dataPoints[Mathf.Clamp(Mathf.RoundToInt(GetY(valueBounds,data.Mean) * resolution), 0, resolution - 1)]++;

            if (dataPoints[Mathf.Clamp(Mathf.RoundToInt(GetY(valueBounds, data.Mean) * resolution), 0, resolution - 1)] > largestPoint)
                largestPoint = dataPoints[Mathf.Clamp(Mathf.RoundToInt(GetY(valueBounds, data.Mean) * resolution), 0, resolution - 1)];

        }


        for (int i = 0; i < resolution; i++)
        {
            if (bars[i] != null)
                bars[i].sizeDelta = new Vector2(parent.rect.width / resolution, parent.rect.height / largestPoint * dataPoints[i]);
        }
    }
}
