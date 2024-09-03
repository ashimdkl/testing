using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerContext : MonoBehaviour
{
    public delegate void ObjectEnteredContainerDelegate(ContainerContext context);
    public event ObjectEnteredContainerDelegate ObjectEnteredContainerEvent;

    public delegate void ContainerFilledDelegate(ContainerContext context);
    public event ContainerFilledDelegate ContainerFilledEvent;

    public int containmentAmount;
    public List<GameObject> objectsInContainer;

    private void OnTriggerEnter(Collider other)
    {
        if (objectsInContainer.Contains(other.gameObject))
            return;

        objectsInContainer.Add(other.gameObject);

        if(ObjectEnteredContainerEvent != null )
        ObjectEnteredContainerEvent.Invoke(this);

        if (objectsInContainer.Count >= containmentAmount)
            ContainerFilledEvent.Invoke(this);
    }
    public void EmptyContainer()
    {
        foreach (var obj in objectsInContainer)
            Destroy(obj.gameObject);

        objectsInContainer.Clear();
    }
    public void TurnOffPhysics()
    {
        foreach(var obj in objectsInContainer)
        {
            obj.GetComponent<GearController>().SetTransformToFollow(transform);
            obj.GetComponent<Rigidbody>().isKinematic = true;
            obj.GetComponent<Rigidbody>().useGravity = false;
        }
    }
}