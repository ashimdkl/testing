using System.Collections.Generic;
using UnityEngine;
using static UIPanelContext;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "PanelContextContainer", menuName = "UI/Contexts/PanelContextContainer")]
public class PanelContextContainer : ScriptableObject
{
    public UIPanelContext currentContext;
}
