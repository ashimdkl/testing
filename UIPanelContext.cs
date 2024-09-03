using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PanelContext",menuName ="UI/Contexts/PanelContext")]
public class UIPanelContext : ScriptableObject
{
    public enum PanelPosition { Focus,BottomLeft,BottomRight }
    public PanelPosition Position;
}
