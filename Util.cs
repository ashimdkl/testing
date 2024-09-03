using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering;

public enum MaterialRenderMode { Opaque, Cutout, Fade, Transparent}

public class Util {

    public static Transform SearchTransform(Transform baseTransform, string find)
    {
        Transform[] allChildren = baseTransform.GetComponentsInChildren<Transform>(true);
        foreach(Transform child in allChildren)
        {
            if (child.name == find)
            {
                return child;
            }
        }

        return null;
    }

    public static Transform SearchTagTransform(Transform baseTransform, string find)
    {
        Transform[] allChildren = baseTransform.GetComponentsInChildren<Transform>(true);
        foreach (Transform child in allChildren)
        {
            if (child.tag == find)
            {
                return child;
            }

        }

        return null;
    }

    public static T SearchTransformForComponent<T>(Transform baseTransform)
    {
        Transform[] children = baseTransform.GetComponentsInChildren<Transform>(true);
        foreach(Transform child in children)
        {
            if(child.GetComponent<T>() != null)
            {
                return child.GetComponent<T>();
            }
        }
        return default(T);
    }

    public static Vector3 FixIfNaN(Vector3 v)
    {
        if (float.IsNaN(v.x))
        {
            v.x = 0.0f;
        }
        if (float.IsNaN(v.y))
        {
            v.y = 0.0f;
        }
        if (float.IsNaN(v.z))
        {
            v.z = 0.0f;
        }
        return v;
    }

    public static void SetActiveRecursivelyLegacy(GameObject go, bool active)
    {
        go.SetActive(active);
        foreach (Transform t in go.transform)
        {
            SetActiveRecursivelyLegacy(t.gameObject, active);
        }
    }


    public static T CopyComponent<T>(T original, GameObject destination) where T : Component
    {
        System.Type type = original.GetType();
        Component copy = destination.AddComponent(type);
        System.Reflection.FieldInfo[] fields = type.GetFields();
        foreach (System.Reflection.FieldInfo field in fields)
        {
            field.SetValue(copy, field.GetValue(original));
        }
        return copy as T;
    }

    public static void ChangeLayersRecursively(Transform trans, string name)
    {
        trans.gameObject.layer = LayerMask.NameToLayer(name);
        foreach (Transform child in trans)
        {
            ChangeLayersRecursively(child, name);
        }
    }

    public static void SetRenderingMode(Material material, MaterialRenderMode rm)
    {
        switch (rm)
        {
            case MaterialRenderMode.Opaque:
                material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
                material.SetInt("_ZWrite", 1);
                material.DisableKeyword("_ALPHATEST_ON");
                material.DisableKeyword("_ALPHABLEND_ON");
                material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                material.renderQueue = -1;
                break;
            case MaterialRenderMode.Cutout:
                material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
                material.SetInt("_ZWrite", 1);
                material.EnableKeyword("_ALPHATEST_ON");
                material.DisableKeyword("_ALPHABLEND_ON");
                material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                material.renderQueue = 2450;
                break;
            case MaterialRenderMode.Fade:
                material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
                material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                material.SetInt("_ZWrite", 0);
                material.DisableKeyword("_ALPHATEST_ON");
                material.EnableKeyword("_ALPHABLEND_ON");
                material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                material.renderQueue = 3000;
                break;
            case MaterialRenderMode.Transparent:
                material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                material.SetInt("_ZWrite", 0);
                material.DisableKeyword("_ALPHATEST_ON");
                material.DisableKeyword("_ALPHABLEND_ON");
                material.EnableKeyword("_ALPHAPREMULTIPLY_ON");
                material.renderQueue = 3000;
                break;
        }
    }

}
