using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TestArea : MonoBehaviour
{
    public Transform gateTransform;
    public List<GearController> gearsToTest;

    public void AddGear(GearController gearController)
    {
            gearsToTest.Add(gearController);
    }
    public void RemoveGear(GearController gearController)
    {
        gearsToTest.Remove(gearController);
    }

    public void LockGear()
    {
        if (gearsToTest.Count >= 0)
        {
            foreach(GearController gearController in gearsToTest)
                gearController.SetTransformToFollow(gateTransform);
        }
    }
    public void UnlockGear()
    {
        if (gearsToTest.Count >= 0)
        {
            foreach (GearController gearController in gearsToTest)
                gearController.SetTransformToFollow(null);
        }
    }
}
