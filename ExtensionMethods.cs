using UnityEngine;
using System.Collections;

public static class ExtensionMethods  {

    public static void ResetWorldTransform(this Transform trans)
    {
        trans.position = Vector3.zero;
        trans.rotation = Quaternion.identity;
        trans.localScale = Vector3.one;
    }


    public static void ResetLocalTransform(this Transform trans)
    {
        ResetLocal(trans);
    }


    public static void ApplyRotation(this Transform trans)
    {
        Quaternion rot = trans.rotation;
        if (trans.parent != null)
        {
            trans.parent.rotation = Quaternion.identity;
        }
        trans.rotation = rot;
    }


    public static void ApplyScale(this Transform trans)
    {
        Vector3 scale = trans.localScale;
        if (trans.parent != null)
        {
            trans.parent.localScale = Vector3.zero;
        }
        trans.localScale = scale;
    }


    public static void CreateEmptyParent(this Transform trans)
    {
        GameObject newParent = new GameObject(trans.name);
        if (trans.parent != null) newParent.transform.parent = trans.parent;
        newParent.transform.position = trans.position;
        newParent.transform.rotation = Quaternion.identity;
        newParent.transform.localScale = trans.localScale;
        trans.parent = newParent.transform;

        //GameObject collider = new GameObject(trans.name + "Colliders");
        //collider.transform.rotation = Quaternion.Euler(new Vector3(270, 0, 0));
        //collider.transform.position = newParent.transform.position;
        //collider.transform.parent = newParent.transform;
    }


    public static void ResetLocal(Transform trans)
    {
        trans.localPosition = Vector3.zero;
        trans.localRotation = Quaternion.identity;
        trans.localScale = Vector3.one;
    }


    public static void ClearParent(this Transform trans)
    {
        trans.parent = null;
    }


    public static void SetWorldPosX(this Transform transform, float val)
    {
        Vector3 newVal = new Vector3(val, transform.position.y, transform.position.z);
        transform.position = newVal;
    }


    public static void SetWorldPosY(this Transform transform, float val)
    {
        Vector3 newVal = new Vector3(transform.position.x, val, transform.position.z);
        transform.position = newVal;
    }


    public static void SetWorldPosZ(this Transform transform, float val)
    {
        Vector3 newVal = new Vector3(transform.position.x, transform.position.y, val);
        transform.position = newVal;
    }


    public static void SetLocalPosX(this Transform transform, float val)
    {
        Vector3 newVal = new Vector3(val, transform.localPosition.y, transform.localPosition.z);
        transform.localPosition = newVal;
    }


    public static void SetLocalPosY(this Transform transform, float val)
    {
        Vector3 newVal = new Vector3(transform.localPosition.x, val, transform.localPosition.z);
        transform.localPosition = newVal;
    }


    public static void SetLocalPosZ(this Transform transform, float val)
    {
        Vector3 newVal = new Vector3(transform.localPosition.x, transform.localPosition.y, val);
        transform.localPosition = newVal;
    }


    public static void SetWorldEulerAngleX(this Transform transform, float val)
    {
        Vector3 newVal = new Vector3(val, transform.eulerAngles.y, transform.eulerAngles.z);
        transform.eulerAngles = newVal;
    }


    public static void SetWorldEulerAngleY(this Transform transform, float val)
    {
        Vector3 newVal = new Vector3(transform.eulerAngles.x, val, transform.eulerAngles.z);
        transform.eulerAngles = newVal;
    }

    public static void SetWorldEulerAngleZ(this Transform transform, float val)
    {
        Vector3 newVal = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, val);
        transform.eulerAngles = newVal;
    }


    public static void SetLocalEulerAngleX(this Transform transform, float val)
    {
        Vector3 newVal = new Vector3(val, transform.localEulerAngles.y, transform.localEulerAngles.z);
        transform.eulerAngles = newVal;
    }


    public static void SetLocalEulerAngleY(this Transform transform, float val)
    {
        Vector3 newVal = new Vector3(transform.localEulerAngles.x, val, transform.localEulerAngles.z);
        transform.eulerAngles = newVal;
    }


    public static void SetLocalEulerAngleZ(this Transform transform, float val)
    {
        Vector3 newVal = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, val);
        transform.eulerAngles = newVal;
    }


    public static void SetScaleX(this Transform transform, float val)
    {
        Vector3 newVal = new Vector3(val, transform.localScale.y, transform.localScale.z);
        transform.eulerAngles = newVal;
    }


    public static void SetScaleY(this Transform transform, float val)
    {
        Vector3 newVal = new Vector3(transform.localScale.x, val, transform.localScale.z);
        transform.eulerAngles = newVal;
    }


    public static void SetScaleZ(this Transform transform, float val)
    {
        Vector3 newVal = new Vector3(transform.localScale.x, transform.localScale.y, val);
        transform.eulerAngles = newVal;
    }




}
