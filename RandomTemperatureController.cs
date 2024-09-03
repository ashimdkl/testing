using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class RandomTemperatureController : BaseUIElement
{
    public UnityEvent<float> randomMoldTemperatureSetEvent;
    public UnityEvent<float> randomBarrelTemperatureSetEvent;

    public ProductRunSet productRunSet;
    public TemperatureData moldTemperatureData;
    public TemperatureData barrelTemperatureData;

    int outputCount;
    public int deltaOutput;
    public override void Awake()
    {
        base.Awake();

        SetRandomStartPosition();

        print(ServiceLocator.Instance);

    }
    private void Start()
    {
        ServiceLocator.Instance.MachineController.NewProductRunSetCreatedEvent += SetProductRunSet;

    }

    void SetRandomStartPosition()
    {
        GetComponent<Image>().color = Color.green;

        float randomMoldTemp = Random.Range(moldTemperatureData.lowerControlLimit, moldTemperatureData.upperControlLimit);
        float randomBarrelTemp = Random.Range(barrelTemperatureData.lowerControlLimit, barrelTemperatureData.upperControlLimit);

        if (randomMoldTemp <= (randomBarrelTemp) - moldTemperatureData.delta - moldTemperatureData.delta / 2)
        {
            SetRandomStartPosition();
        }
        if (randomMoldTemp >= (randomBarrelTemp) - moldTemperatureData.delta + moldTemperatureData.delta / 2)
        {
            SetRandomStartPosition();
        }

        randomMoldTemperatureSetEvent.Invoke(randomMoldTemp);
        randomBarrelTemperatureSetEvent.Invoke(randomBarrelTemp);

        UpdatePositionByPercentage(moldTemperatureData.GetPercentageInBounds(randomMoldTemp), barrelTemperatureData.GetPercentageInBounds(randomBarrelTemp));
    }
    void SetProductRunSet(ProductRunSet productRunSet)
    {
        this.productRunSet = productRunSet;

        productRunSet.ProductAddedEvent += OutputAdded;
    }
    private void OutputAdded()
    {
        outputCount++;

        if (outputCount >= deltaOutput) 
        {
            SetRandomStartPosition();
            outputCount = 0;
        }
    }
}
