using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class CorrectSlot : MonoBehaviour,IDropHandler
{


    [SerializeField]
    public string correctObjectTag;

   
    public void OnDrop(PointerEventData eventData)
    {
        // prevent 2 items from stacking
        if (transform.childCount == 0)
        {
            GameObject dropped = eventData.pointerDrag;
            MoveScript draggableItem = dropped.GetComponent<MoveScript>();
            if (draggableItem.CompareTag(correctObjectTag) && draggableItem.transform.childCount == 0)
            {
                draggableItem.parentAfterDrag = transform;
            }

        }

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
