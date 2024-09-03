using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public RunGraph runGraph;
    public BarGraphController barGraphController;
    private void Start()
    {
        //StartCoroutine(Setup());


    }
    IEnumerator Setup()
    {
        //yield return StartCoroutine(barGraphController.Initialize());
        print("start");
        yield return StartCoroutine(runGraph.RunPlottingByTime());
    }
}
