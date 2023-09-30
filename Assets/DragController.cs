/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragController : MonoBehaviour,IBeginDragHandler,IEndDragHandler
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
}*/
using UnityEngine;

public class Drag : MonoBehaviour {
  private bool dragging = false;
  private Vector3 offset;

  // Update is called once per frame
  void Update() {
    if (dragging) {
      // Move object, taking into account original offset.
      transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
    }
  }

  private void OnMouseDown() {
    // Record the difference between the objects centre, and the clicked point on the camera plane.
    offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    dragging = true;
  }

  private void OnMouseUp() {
    // Stop dragging.
    dragging = false;
  }
}