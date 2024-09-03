using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUIElement : MonoBehaviour
{
    public RectTransform ParentRectTransform { get { return parentRectTransform; }}
    RectTransform parentRectTransform;
    public RectTransform RectTransform { get { return rectTransform; } }
    RectTransform rectTransform;

    public virtual void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        parentRectTransform = rectTransform.parent.GetComponent<RectTransform>();

    }

    public virtual void UpdateXByPercentage(float percentage)
    {
        rectTransform.anchoredPosition = new Vector2( percentage * parentRectTransform.rect.width,rectTransform.anchoredPosition.y);
    }
    public virtual void UpdateYByPercentage(float percentage)
    {
        rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, percentage * parentRectTransform.rect.height);

    }

    public virtual float GetXPosition(float percentage)
    {
        return parentRectTransform.rect.width * percentage;
    }
    public virtual float GetYPosition(float percentage)
    {
        return parentRectTransform.rect.height * percentage;
    }

    public virtual void UpdatePositionByPercentage(float xPercentage,float yPercentage)
    {
        rectTransform.anchoredPosition = new Vector2(xPercentage * parentRectTransform.rect.width, yPercentage * parentRectTransform.rect.height);

    }

}
