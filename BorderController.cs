using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderController : BaseUIElement
{
    public float temperature;
    public RectTransform topBorder, bottomBorder,leftBorder,rightBorder;

    private void Start()
    {
        topBorder.sizeDelta = new Vector2(10*temperature, 3);
        bottomBorder.sizeDelta = new Vector2(10 * temperature, 3);
        leftBorder.sizeDelta = new Vector2(3, 10 * temperature);
        rightBorder.sizeDelta = new Vector2(3, 10 * temperature);

        topBorder.anchoredPosition = new Vector2(0, 5f * temperature);
        bottomBorder.anchoredPosition = new Vector2(0, -5f * temperature);
        leftBorder.anchoredPosition = new Vector2(5f * temperature,0);
        rightBorder.anchoredPosition = new Vector2(-5f * temperature, 0);
    }
}
