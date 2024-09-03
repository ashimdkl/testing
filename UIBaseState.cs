using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIBaseState
{
    protected UIContext uIContext;
    protected UIStateFactory uIStateFactory;

    public UIBaseState(UIContext uIContext, UIStateFactory uIStateFactory)
    {
        this.uIContext = uIContext;
        this.uIStateFactory = uIStateFactory;
    }

    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void OnMouseEnter();
    public abstract void OnMouseStay();
    public abstract void OnMouseExit();

    public abstract void CheckSwitchStates();
    public abstract void ExitState();

    protected void SwitchState(UIBaseState newState)
    {
        ExitState();

        newState.EnterState();

        uIContext.currentStateString = newState.ToString();

        uIContext.CurrentState = newState;
    }
}
