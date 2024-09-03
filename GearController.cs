using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearController : MonoBehaviour
{
    Vector3 offset;
    Rigidbody rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (transform.parent != null)
        {
            transform.position = transform.parent.position+offset;
        }
    }
    public void SetTransformToFollow(Transform parent)
    {
        transform.parent = parent;

        if (transform.parent != null) 
        offset = transform.position - parent.position;

        if (transform.parent != null)
        {
            SwitchPhysicsOn(false);
        }
        else
        {
            transform.parent = null;
            SwitchPhysicsOn(true);
        }
    }

    void SwitchPhysicsOn(bool on)
    {
        if (!on)
        {
            //rigidbody.constraints = RigidbodyConstraints.FreezeAll;

        }
        else
        {
            rigidbody.constraints = RigidbodyConstraints.None;
        }
        //rigidbody.isKinematic = !on;
        rigidbody.useGravity = on;
    }
    public void FreezePositionY()
    {
        rigidbody.constraints = RigidbodyConstraints.FreezePositionY;
    }
    public void StopRotations()
    {
        rigidbody.constraints = RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezePositionY;
    }
    public void DisableConstraints()
    {
        rigidbody.constraints = RigidbodyConstraints.None;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<ConveyorBeltController>())
        {
            StopRotations();
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.GetComponent<ConveyorBeltController>())
            DisableConstraints();
    }
}
