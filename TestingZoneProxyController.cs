using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TestingZoneProxyController : MonoBehaviour
{
    public UnityEvent TestFinished;
    public UnityEvent TestStarted;

    public Transform testGear;
    public Transform controlGear;
    public Transform position1;
    public Transform position2;
    public Transform position3;
    public float gearSpeed;

    private void Start()
    {
       // StartCoroutine(EngageGear());


    }

    private void Update()
    {
        TurnGears();
    }
    public void StartTest()
    {
        StartCoroutine(EngageGear());
    }
    void TurnGears()
    {
        testGear.eulerAngles -= new Vector3(0, gearSpeed, 0);
        controlGear.eulerAngles += new Vector3(0, gearSpeed, 0);
    }
    IEnumerator EngageGear()
    {
        TestStarted.Invoke();

        yield return StartCoroutine(MovementScript.MoveToTransform(testGear, position1.position, position2.position, .5f));
        yield return StartCoroutine(MovementScript.MoveToTransform(testGear, position2.position, position3.position, 1f));
        yield return StartCoroutine(MovementScript.TurnFloat((x) => { gearSpeed = x; }, 0, 5, 1));
        yield return new WaitForSeconds(1f);
        yield return StartCoroutine(MovementScript.TurnFloat((x) => { gearSpeed = x; }, 5, 0, 1));
        yield return StartCoroutine(MovementScript.MoveToTransform(testGear, position3.position, position2.position, 1f));
        TestFinished.Invoke();
        yield return StartCoroutine(MovementScript.MoveToTransform(testGear, position2.position, position1.position, .5f));


    }

}
