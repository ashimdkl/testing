using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutputProduct : ScriptableObject
{
    public int setNumber;
    public float productSize;
    public bool inControlLimits;
    public bool CheckInControlLimits(float lowerControlLimit,float upperControlLimit)
    {
        if(productSize < lowerControlLimit || productSize > upperControlLimit)
            inControlLimits = false;
        else
            inControlLimits = true;

        return inControlLimits;
    }
}
