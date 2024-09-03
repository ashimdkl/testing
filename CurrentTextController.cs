using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentTextController : MonoBehaviour
{
    public void Activate(bool textLogEnabled)
    {
        gameObject.SetActive(!textLogEnabled);
    }
}
