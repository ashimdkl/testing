using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ProductSetVariables", menuName = "ScriptableObjects/ProductSetVariables", order = 1)]
public class ProductSetVariables : ScriptableObject
{

    public delegate void RunValueRangeSetDelegate(Vector2 valueRange);
    public event RunValueRangeSetDelegate RunValueRangeSetEvent;

    [Range(0, 1)]
    public float productionTimeDeviation = 1.0f;
    [Range(0, 1)]
    public float productionTime = 1.0f;
    [Range(0, 1)]
    public float sizeDeviation = 1.0f;
    [Range(0, 2)]
    public float size = 1.0f;

    public Vector2 fullRange;
    public Vector2 controlLimits;

    private void OnEnable()
    {
        if(RunValueRangeSetEvent != null)
        RunValueRangeSetEvent.Invoke(fullRange);
    }
}
