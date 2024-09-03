using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FillArea : MonoBehaviour
{
    public int maxRigidbodies;
    public List<Rigidbody> rigidbodies;
    public UnityEvent FillAreaFilled;
    public UnityEvent AreaNotAtMaxEvent;
    public UnityEvent EnoughUntrackedProductsReleasedEvent;

    public void AreaHasBeenFilled()
    {
        FillAreaFilled.Invoke();
    }
    private void OnTriggerEnter(Collider other)
    {
        rigidbodies.Add(other.GetComponent<Rigidbody>());

/*        if (other.GetComponent<GearController>())
        {
            other.GetComponent<GearController>().StopRotations();
        }*/

        if (rigidbodies.Count >= maxRigidbodies)
        {
            AreaHasBeenFilled();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        rigidbodies.Remove(other.GetComponent<Rigidbody>());

/*        if(other.GetComponent<GearController>())
        {
            other.GetComponent<GearController>().DisableConstraints();
        }*/

        if (rigidbodies.Count < maxRigidbodies)
            AreaNotAtMaxEvent.Invoke();


    }

}
