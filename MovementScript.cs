using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MovementScript
{
    public static IEnumerator MoveToTransform(Transform objectToMove,Vector3 p1,Vector3 p2, float length)
    {
        float progress = 0f;

        while (progress <= length)
        {
            objectToMove.position = Vector3.Lerp(p1, p2, progress / length);
            progress += Time.deltaTime;

            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForEndOfFrame();
    }

    public static IEnumerator RotateTransform(Transform objectToRotate, Vector3 r1, Vector3 r2, float length)
    {
        float progress = 0f;

        while (progress <= length)
        {
            Vector3.Lerp(r1, r2, progress / length);
            progress += Time.deltaTime;

            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForEndOfFrame();
    }
    public static IEnumerator TurnFloat(System.Action<float> floatToChange, float f1, float f2, float length)
    {
        float progress = 0f;

        while (progress <= length)
        {
            floatToChange(Mathf.Lerp(f1, f2, progress / length));
            progress += Time.deltaTime;

            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForEndOfFrame();
    }

    static IEnumerator WaitForFrame()
    {
        yield return new WaitForEndOfFrame();
    }
}
