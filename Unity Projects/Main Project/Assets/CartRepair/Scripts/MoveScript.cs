using System.Collections;
using System.Collections.Generic;
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

        if (gameObject.tag == "Pin"  && parentAfterDrag.name == "CorrectPinBox")
        {
            FindAnyObjectByType<AudioManager>().Play("Slide");
        }
        else
        {
            int random;
            random = Random.Range(1, 3);
            switch (random)
            {
                case 1:
                    FindAnyObjectByType<AudioManager>().Play("WoodHit1");
                    break;
                case 2:
                    FindAnyObjectByType<AudioManager>().Play("WoodHit2");
                    break;
            }
        }

        image.raycastTarget = true;
    }
}

