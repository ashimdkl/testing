using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlLimitController : BaseUIElement
{
    public TemperatureData temperatureData;

    public float percentage;
    public enum Axis { X,Y }
    public Axis axis;
    public enum ControlLimit { Lower,Upper }
    public ControlLimit controlLimit;



    public override void Awake()
    {
        base.Awake();

        if(controlLimit == ControlLimit.Lower)
            percentage = temperatureData.GetLowerControlPercentage();
        if(controlLimit == ControlLimit.Upper)
            percentage = temperatureData.GetUpperControlPercentage();

        if(axis == Axis.X)
            UpdateXByPercentage(percentage);
        if(axis == Axis.Y)
            UpdateYByPercentage(percentage);
    }
    

}
