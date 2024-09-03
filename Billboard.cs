using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Camera cameraToLookAt;


    public void LateUpdate()
    {
        transform.LookAt(cameraToLookAt.transform.position);
    }
}
