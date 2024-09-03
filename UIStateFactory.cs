using System.Collections;
using UnityEngine;

public class UIStateFactory
{
    public UIContext uIContext;

    public UIStateFactory(UIContext uIContext)
    {
        this.uIContext = uIContext;
    }
    public virtual UIBaseState Idle()
    { return new UIIdleState(uIContext, this); }
    public virtual UIBaseState Hovered()
    { return new UIHoveredState(uIContext, this); }
}
