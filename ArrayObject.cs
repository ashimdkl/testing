using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ArrayObject : MonoBehaviour
{
    //Transform prefab;
    public Vector3 posOffset = Vector3.zero;
    public Vector3 counts = Vector3.one;

    [HideInInspector]
    public List<Transform> totalList = new List<Transform>();
    [HideInInspector]
    public Transform parentTrans;


    public void EmptyArrayList()
    {
        if (parentTrans) DestroyImmediate(parentTrans.gameObject);

        if(totalList.Count > 0)
        {
            foreach (Transform t in totalList)
            {
                if(t) DestroyImmediate(t.gameObject);
            }
            totalList.Clear();
        }

    }

    public void ClearCache()
    {
        totalList.Clear();
    }
}
