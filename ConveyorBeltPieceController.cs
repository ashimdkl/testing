using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.Splines;

public class ConveyorBeltPieceController : MonoBehaviour
{
    BoxCollider boxCollider;
    public SplineContainer spline;
    List<GameObject> objectsCarried = new List<GameObject>();
    public float progress;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider>();
    }

    private void Update()
    {



    }
    public void SetSpline(SplineContainer spline)
    { this.spline = spline; }
    public void SetProgress(float progress)
    {
        this.progress += progress;

        if (this.progress >= 1f)
        {
            foreach (GameObject obj in objectsCarried.ToList())
            {
                obj.transform.parent = null;
                objectsCarried.Remove(obj);

            }
            this.progress = 0;
        }

        transform.position = spline.EvaluatePosition(this.progress);
    }
    public void SetColliderSize(Vector3 size)
    {
        boxCollider.size = size;
    }
    public void SetColliderCenter(Vector3 center)
    {
        boxCollider.center = center;
    }
}
