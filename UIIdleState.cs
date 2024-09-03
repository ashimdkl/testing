using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIIdleState : UIBaseState
{
    public UIIdleState(UIContext uIContext, UIStateFactory uIStateFactory) : base(uIContext, uIStateFactory)
    {
    }

    public override void CheckSwitchStates()
    {
        if (uIContext.Hovering)
        {
            SwitchState(uIStateFactory.Hovered());
        }
    }

    public override void EnterState()
    {

    }

    public override void ExitState()
    {

    }

    public override void OnMouseEnter()
    {
        uIContext.Hovering = true;
    }

    public override void OnMouseExit()
    {

    }

    public override void OnMouseStay()
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState()
    {
        CheckSwitchStates();
    }
}
