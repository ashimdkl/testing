using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIContext : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string currentStateString;
    public string stateFactoryString;
    UIBaseState currentState;
    UIStateFactory stateFactory;

    bool hovering;

    public UIBaseState CurrentState { get { return currentState; } set { currentState = value; } }
    public UIStateFactory StateFactory { get { return stateFactory; } set { stateFactory = value; } }

    public bool Hovering { get { return hovering; } set { hovering = value; } }


    public virtual void Start()
    {
        if(stateFactory == null)
            stateFactory = new UIStateFactory(this);

        stateFactoryString =stateFactory.ToString();

        currentState = stateFactory.Idle();

        currentState.EnterState();

        currentStateString = currentState.ToString();
    }

    public virtual void Update() 
    {
        if(currentState != null)
            currentState.UpdateState();
    }
    public virtual void OnPointerEnter()
    {

    }

    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        currentState.OnMouseEnter();
    }

    public virtual void OnPointerExit(PointerEventData eventData)
    {
        currentState.OnMouseExit();
    }
}
