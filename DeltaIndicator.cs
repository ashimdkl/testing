using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI.Extensions;

public class DeltaIndicator : MonoBehaviour
{
    public RectTransform rect1, rect2;
    Vector2[] points = new Vector2[2];
    public UILineRenderer lineRenderer;

    public void Initialize(RectTransform rect2)
    {
        this.rect2 = rect2;
    }
    private void Update()
    {
        SetPositions();
    }

    void SetPositions()
    {
        if (rect1 != null && rect2 != null)
        {
            points[0] = rect1.anchoredPosition;
            points[1] = rect2.anchoredPosition;

            lineRenderer.Points = points.ToArray();
        }

        lineRenderer.GraphicUpdateComplete();
    }
}
