using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TemperatureType { Barrel, Mold }

[CreateAssetMenu(fileName = "Temperature", menuName = "ScriptableObjects/Data/TemperatureData", order = 1)]
public class TemperatureData : ScriptableObject
{
    public TemperatureType temperatureType;
    public Vector2 TemperatureRange;
    public float lowerControlLimit;
    public float upperControlLimit;
    public float delta;
    public float middle;

        private void OnEnable()
    {
        delta = upperControlLimit-lowerControlLimit;
        middle = lowerControlLimit+delta/2;
    }
    public float GetLowerControlPercentage()
    {
        return GetPercentageInBounds(lowerControlLimit);
    }
    public float GetUpperControlPercentage()
    {
        return GetPercentageInBounds(upperControlLimit);
    }

    public float GetPercentageInBounds(float value)
    {
        return (value - TemperatureRange.x) / (TemperatureRange.y - TemperatureRange.x);
    }
}
