using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragControllar : MonoBehaviour,IBeginDragHandler,IEndDragHandler
{
    public static GameObject mydraggablesprite;
    Vector3 starPosition;
    float zDistanceToCamera;
    Vector3 touchOffset;

    public void OnBeginDrag(PointerEventData eventData)
    {
        mydraggablesprite = gameObject;
        starPosition = transform.position;
        zDistanceToCamera = Mathf.Abs(starPosition.z - Camera.main.transform.position.z);
        touchOffset = starPosition - Camera.main.ScreenToWorldPoint
            (new Vector3(Input.mousePosition.x, Input.mousePosition.y, zDistanceToCamera));

    }

    public void OnDrag(PointerEventData eventData)
    {
        if (Input.touchCount > 1)
            return;

        transform.position = Camera.main.ScreenToWorldPoint
        (new Vector3(Input.mousePosition.x, Input.mousePosition.y, zDistanceToCamera))+touchOffset;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        mydraggablesprite = null;
        touchOffset = Vector3.zero;
    }


}