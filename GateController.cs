using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GateController : MonoBehaviour
{
    public float gateTime = 1;
    public Transform openPosition;
    public Transform closePosition;
    public Transform gate;
    private void Awake()
    {

    }
    public IEnumerator OpenGate()
    {
        yield return StartCoroutine(MovementScript.MoveToTransform(gate,gate.position,openPosition.position,gateTime));
    }
    public IEnumerator CloseGate()
    {
        yield return StartCoroutine(MovementScript.MoveToTransform(gate, gate.position, closePosition.position, gateTime));
    }
}
