using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotBarGraphController : BarGraphController
{
    public TrackedProductsSet capturedDataSet;
    public override void Start()
    {
        base.Start();
        ServiceLocator.Instance.MachineController.NewProductRunSetCreatedEvent += SetNewProductSet;
    }



    public override void SetNewProductSet(ProductRunSet newProductSet)
    {
        base.SetNewProductSet(newProductSet);
        productRunSet.NewSetOfTrackedProductsCreatedEvent += SetNewDataSet;
        productRunSet.TrackProductsSetActiveEvent += SetNewDataSet;
    }
    public void SetNewDataSet(TrackedProductsSet trackedProducts)
    {
        capturedDataSet = trackedProducts;
        trackedProducts.ProductAddedToSetEvent += UpdateData;

        //print(trackedProducts.SetNumber);
        foreach (OutputProduct outputProduct in trackedProducts.products)
        {
            UpdateData(outputProduct);
        }
    }

    public void UpdateData(OutputProduct outputProduct)
    {
        ResetData();

        int largestPoint = 0;
        foreach (OutputProduct data in capturedDataSet.products)
        {
            dataPoints[Mathf.Clamp(Mathf.RoundToInt(GetY(data) * resolution), 0, resolution - 1)]++;

            if (dataPoints[Mathf.Clamp(Mathf.RoundToInt(GetY(data) * resolution), 0, resolution - 1)] > largestPoint)
                largestPoint = dataPoints[Mathf.Clamp(Mathf.RoundToInt(GetY(data) * resolution), 0, resolution - 1)];

        }


        for (int i = 0; i < resolution; i++)
        {
            if (bars[i] != null)
                bars[i].sizeDelta = new Vector2(parent.rect.width / resolution, parent.rect.height / largestPoint * dataPoints[i]);
        }
    }
    float GetY(OutputProduct outputProduct)
    {
        float normalizedMax = capturedDataSet.valueRange.y - capturedDataSet.valueRange.x;
        float normalizedSize = outputProduct.productSize - capturedDataSet.valueRange.x;
        float percentage = normalizedSize / normalizedMax;
        return percentage;
    }
}
