using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorController : MonoBehaviour
{
    [Header("Background Colors")]
    [SerializeField]
    Color activeColor;
    [SerializeField]
    Color inactiveColor;

    Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void SetColor(bool active)
    {
        if (active)
            image.color = activeColor;
        else 
            image.color = inactiveColor;
    }
}
