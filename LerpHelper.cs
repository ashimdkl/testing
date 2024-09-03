using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LerpHelper  {

    public static IEnumerator LerpMyTransform(this Transform t1, Transform t2, float time)
    {
        float t = 0f;

        Vector3 startPos = t1.position;
        Quaternion startRot = t1.rotation;
        Vector3 startScale = t1.localScale;

        float rate = 1.0f / time;
        
        while(t < 1f)
        {
            t += Time.deltaTime * rate;
            t1.position = Vector3.Lerp(startPos, t2.position, t);
            t1.rotation = Quaternion.Lerp(startRot, t2.rotation, t);
            t1.localScale = Vector3.Lerp(startScale, t2.localScale, t);
            yield return null;
        }

    }

    public static IEnumerator LerpTransform(Transform t1, Transform t2, float time)
    {
        float t = 0f;

        Vector3 startPos = t1.position;
        Quaternion startRot = t1.rotation;
        Vector3 startScale = t1.localScale;

        float rate = 1.0f / time;

        while (t < 1f)
        {
            t += Time.deltaTime * rate;
            t1.position = Vector3.Lerp(startPos, t2.position, t);
            t1.rotation = Quaternion.Lerp(startRot, t2.rotation, t);
            t1.localScale = Vector3.Lerp(startScale, t2.localScale, t);
            yield return null;
        }

    }


}
