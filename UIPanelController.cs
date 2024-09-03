using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanelController : MonoBehaviour
{
    public List<PanelContextReference> panels = new List<PanelContextReference>();
    public UIPanelContext CurrentContext
    {
        get 
        {
            return currentContext; 
        }
        set 
        { 
            currentContext = value;
            ActivateCurrentContextPanel();
        }
    }
    public UIPanelContext currentContext;

    private void Awake()
    {
        ActivateCurrentContextPanel();
    }

    public void ActivateCurrentContextPanel()
    {
        foreach (PanelContextReference panel in panels)
        {
            panel.gameObject.SetActive(panel.UIPanelContext == currentContext);
        }
    }
}
