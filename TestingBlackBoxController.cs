using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TestingBlackBoxController : MonoBehaviour
{
    public UnityEvent GearEnteredEvent;

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<GearController>()!= null)
        {
            GearEnteredEvent.Invoke();
        }
    }
}
