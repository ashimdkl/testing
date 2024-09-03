using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI.Extensions;
using static LineRenderedControlLimit;

public class LineRenderedControlLimit : BaseUIElement
{
    public enum Slope {Upper,Lower }
    public Slope slope;
    public float m;
    public UILineRenderer lineRenderer;
    public TemperatureData moldTemperatureData;
    public TemperatureData barrelTemperatureData;
    public override void Awake()
    {
        base.Awake();
        SetPoints();
    }

    void SetPoints()
    {
        Vector2[] points = new Vector2[2];



        if (slope == Slope.Lower)
        {  
            m = (GetYPosition(moldTemperatureData.GetUpperControlPercentage()) - GetYPosition(.5f)  )/
                (GetXPosition(.5f) - GetXPosition(barrelTemperatureData.GetLowerControlPercentage()));
                
            
            points[0].x = GetXPosition(barrelTemperatureData.GetLowerControlPercentage());
            points[0].y =  m*points[0].x  + GetYPosition(1f/6f);
            
            points[1].y = GetYPosition(moldTemperatureData.GetUpperControlPercentage());
            points[1].x = (points[1].y- GetYPosition(1f / 6f)) /m ;

        }
        if(slope == Slope.Upper)
        {
            m = (GetYPosition(.5f) - GetYPosition(moldTemperatureData.GetLowerControlPercentage())) /
                (GetXPosition(barrelTemperatureData.GetUpperControlPercentage()) - GetXPosition(.5f));
           

            
            points[0].y = GetYPosition(moldTemperatureData.GetLowerControlPercentage());
            points[0].x = (points[0].y +GetYPosition(1f / 6f)) / m;

            points[1].x = GetXPosition(barrelTemperatureData.GetUpperControlPercentage());
            points[1].y = (points[1].x * m) - GetYPosition(1f / 6f);
        }

        
        lineRenderer.Points = points;
    }
}
