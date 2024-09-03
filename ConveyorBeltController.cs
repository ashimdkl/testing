using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Splines;

public class ConveyorBeltController : MonoBehaviour
{
    public Vector3 Direction;
    public float speed;


    public List<Rigidbody> rigidbodies;


    private void Start()
    {
        //BuildCoveyorLine();
    }
    
    private void FixedUpdate()
    {
        foreach(Rigidbody rigidbody in rigidbodies)
        {
                rigidbody.AddForce(Direction * speed * Time.deltaTime);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        rigidbodies.Add(collision.gameObject.GetComponent<Rigidbody>());
    }
    private void OnCollisionExit(Collision collision)
    {
        rigidbodies.Remove(collision.gameObject.GetComponent<Rigidbody>());
    }
}
