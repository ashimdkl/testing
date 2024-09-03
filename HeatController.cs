using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatController : MonoBehaviour
{
    public Vector2 HeatRange = Vector2.one;

    public TutorialConditional tutorialConditional;

    public void ChangeValue(float value)
    {
        if (tutorialConditional != null && tutorialConditional.active)
        {
            tutorialConditional.Complete = (value>HeatRange.x) && (value<HeatRange.y);
        }
    }
}
