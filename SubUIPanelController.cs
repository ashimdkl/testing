using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubUIPanelController : UIPanelController
{
    public UIPanelController focusPanel;

    public void SetAsFocus()
    {
        UIPanelContext tempContext = focusPanel.CurrentContext;

        focusPanel.CurrentContext = CurrentContext;
        CurrentContext = tempContext;
    }
}
