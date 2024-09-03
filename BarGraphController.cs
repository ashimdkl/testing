using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarGraphController : MonoBehaviour
{
    public RectTransform parent;
    public RectTransform barPrefab;
    public List<RectTransform> bars;
    public int resolution = 20;
    public int[] dataPoints;

    public ProductRunSet productRunSet;


    public virtual void Start()
    {
        ServiceLocator.Instance.MachineController.NewProductRunSetCreatedEvent += Initialize;

    }
    public virtual void Initialize(ProductRunSet productRunSet)
    {
        StartCoroutine(InitializeGraph());
    }
    public virtual IEnumerator InitializeGraph()
    {
        //this.productRunSet = productRunSet;
        //capturedDataSet.TargetedDataChangedEvent -= UpdateData;

        bars = new List<RectTransform>();
        for (int i = 0; i < resolution; i++)
        {
            RectTransform bar = Instantiate(barPrefab, transform);
            bar.SetAsFirstSibling();

            bar.anchorMin = Vector2.zero;
            bar.anchorMax = Vector2.zero;

            bar.sizeDelta = new Vector2(parent.rect.width / resolution, 0);
            bar.anchoredPosition = new Vector2(parent.rect.width / resolution * i, 0);

            bars.Add(bar);
        }

        dataPoints = new int[resolution];
        //capturedDataSet.currentProductSet.ProductAddedToSetEvent += UpdateData;



        yield return new WaitForEndOfFrame();
    }

    public virtual void SetNewProductSet(ProductRunSet newProductSet)
    {
        productRunSet = newProductSet;

    }
    public virtual void ResetGraph()
    {
        foreach (var bar in bars)
        {
            bar.sizeDelta = new Vector2(bar.sizeDelta.x, 0);
        }
    }
    public void ResetData()
    {
        for (int i = 0; i < resolution; i++)
        {
            dataPoints[i] = 0;
        }
    }

    public float GetY(Vector2 valueBounds, float value)
    {
        float normalizedMax = valueBounds.y - valueBounds.x;
        float normalizedSize = value - valueBounds.x;
        float percentage = normalizedSize / normalizedMax;
        return percentage;
    }
}
