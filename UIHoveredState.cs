using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHoveredState : UIBaseState
{
    public UIHoveredState(UIContext uIContext, UIStateFactory uIStateFactory) : base(uIContext, uIStateFactory)
    {
    }

    public override void CheckSwitchStates()
    {
        if (!uIContext.Hovering)
        {
            SwitchState(uIStateFactory.Idle());
        }
    }

    public override void EnterState()
    {
        uIContext.transform.localScale = Vector3.one * 1.5f;
    }

    public override void ExitState()
    {
        uIContext.transform.localScale = Vector3.one;
    }

    public override void OnMouseEnter()
    {
    }

    public override void OnMouseExit()
    {
        uIContext.Hovering = false;
    }

    public override void OnMouseStay()
    {
    }

    public override void UpdateState()
    {
        CheckSwitchStates();
    }
}
