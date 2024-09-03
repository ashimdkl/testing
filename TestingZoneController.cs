using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TestingZoneController : MonoBehaviour
{
    public TestArea area;
    public UnityEvent<bool> isTestingEnabled;
    public bool IsTesting
    {
        set
        {
            isTesting = value;
            isTestingEnabled.Invoke(isTesting);
        }
        get { return isTesting; }

    }
    bool isTesting;


    public int productsPackaged;

    public int runCount;
    public int untrackedCount;
    public int maxRigidbodies;

    public bool containerReady;
    public bool gearInArea;
    public bool handlingGear;

    public GateController gate1, testingGate, gate2;
    private void Awake()
    {
        IsTesting=true;
    }

    private void FixedUpdate()
    {
        if (containerReady && handlingGear == false) 
        {
            if(area.gearsToTest.Count > 0)
            {
                handlingGear = true;
                print("handling gear");
                HandleGear();
            }
        }
    }
    public void SetContainerReady(bool containerReady)
    {
        this.containerReady = containerReady;
    }
    public void HandleGear()
    {
        if (isTesting)
            StartTesting();
        else
        {
            StopAllCoroutines();
            OpenGate1();
            OpenGate2();
        }
    }
    public void StartTesting()
    {
        StartCoroutine(StartTestingEnumerator());
    }

    public IEnumerator StartTestingEnumerator()
    {
        yield return new WaitForSeconds(.5f);
        print("close gate 1");
        yield return StartCoroutine(gate1.CloseGate());
        area.LockGear();
        print("close testing gate 1");

        yield return StartCoroutine(testingGate.CloseGate());
    }

    public void StopTesting()
    {
        StartCoroutine(StopTestingEnumerator());
    }
    public IEnumerator StopTestingEnumerator()
    {
        yield return StartCoroutine(testingGate.OpenGate());
        area.UnlockGear();
        yield return StartCoroutine(gate2.OpenGate());
        yield return new WaitForSeconds(.5f);
        yield return StartCoroutine(gate2.CloseGate());
        yield return StartCoroutine(gate1.OpenGate());

        handlingGear = false;


    }
    public void SetIsTesting(bool isTesting)
    {
        this.isTesting = isTesting;
    }
    public void ShutGate2()
    {
        StartCoroutine(ShutGate2Enumerator());
    }
    public IEnumerator ShutGate2Enumerator()
    {
        yield return StartCoroutine(gate2.CloseGate());
        handlingGear=false;
    }
    public void OpenGate1()
    {
        StartCoroutine(OpenGate1Enumerator());
    }
    public IEnumerator OpenGate1Enumerator()
    {
        yield return StartCoroutine(gate1.OpenGate());
    }
    public void OpenGate2()
    {
        StartCoroutine(OpenGate2Enumerator());
    }
    public IEnumerator OpenGate2Enumerator()
    {
        yield return StartCoroutine(gate2.OpenGate());
    }
    private void OnTriggerEnter(Collider other)
    {
        gearInArea = true;

        area.AddGear(other.GetComponent<GearController>());
    }
    private void OnTriggerExit(Collider other)
    {
        PackageProduct();
        area.RemoveGear(other.GetComponent<GearController>());

    }


    public void PackageProduct()
    {
        productsPackaged++;

        if (productsPackaged >= runCount)
        {
            if (IsTesting)
            {
                IsTesting = false;
            }

            if (!IsTesting)
            {
                untrackedCount++;
                if (untrackedCount > 5)
                {
                    untrackedCount = 0;
                    IsTesting = true;
                }  
                ShutGate2 ();
            }
            containerReady = false;
            productsPackaged = 0;
        }
    }
}
