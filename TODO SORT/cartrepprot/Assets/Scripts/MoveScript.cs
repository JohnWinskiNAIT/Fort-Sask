using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MoveScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image image;
    [HideInInspector] public Transform parentAfterDrag;

    public void OnBeginDrag(PointerEventData eventData)
    {
        //set original parent 
        parentAfterDrag = transform.parent;

        //set canvas as parent during the drag
        transform.SetParent(transform.root);

        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // move transform with mouse position
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    { 
        //set transform back
        transform.SetParent(parentAfterDrag);

        image.raycastTarget = true;
    }
}
