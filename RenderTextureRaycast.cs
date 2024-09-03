using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class RenderTextureRaycast : BaseUIElement, IPointerDownHandler,IPointerEnterHandler,IPointerExitHandler
{
    public Transform canvas;
   // public Vector2 mousePosition;
    public float mouseHeight;
    public float mouseWidth;
    int layerMask = 1 << 8;
    public bool raycastOn;
    public Camera renderTextureCamera;

    public RenderTexture raycastTexture;

    RaycastHit hit;
    private void Start()
    {
        renderTextureCamera = FindObjectsByType<Camera>(FindObjectsSortMode.None).ToList().First(x=> x.targetTexture == raycastTexture);
        SetCorners();
    }
    private void Update()
    {
        
         //= Input.mousePosition;
        //RectTransformUtility.ScreenPointToLocalPointInRectangle(RectTransform, Input.mousePosition,Camera.main, out mousePosition);



        //mousePosition = Input.mousePosition;


/*        if (Physics.Raycast(renderTextureCamera.ScreenToViewportPoint(mousePosition) + renderTextureCamera.transform.position, renderTextureCamera.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(renderTextureCamera.ViewportPointToRay(mousePosition).origin, renderTextureCamera.ViewportPointToRay(mousePosition).direction);
            Debug.Log("Did Hit");
        }
        else
        {
            Debug.DrawRay(renderTextureCamera.ViewportPointToRay(mousePosition).origin, renderTextureCamera.ViewportPointToRay(mousePosition).direction);
            Debug.Log("Did not Hit");
        }*/
    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //raycastOn = true;
        // Does the ray intersect any objects excluding the player layer
        print(eventData.pointerEnter);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //raycastOn = false;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(mousePosition, 100);
    }
    [SerializeField]
    public Vector3 mousePosition
    {
        get
        {
            Vector3 mousePos = Input.mousePosition;
            mouseHeight=mousePos.y -= (int)(Camera.main.rect.y * Screen.height);
            mouseWidth=mousePos.x -= (int)(Camera.main.rect.x * Screen.width);
            return mousePos;
        }
    }
    public Vector3[] corners = new Vector3[4];
    public void SetCorners()
    {
        RectTransform.GetWorldCorners(corners);
    }

}
