using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class itemSlot : MonoBehaviour, IDropHandler
{


    public void OnDrop(PointerEventData eventData)
    {   
        // prevent 2 items from stacking
        if (transform.childCount == 0)
        {
            GameObject dropped = eventData.pointerDrag;
            MoveScript draggableItem = dropped.GetComponent<MoveScript>();
            
           
            draggableItem.parentAfterDrag = transform;

            
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (transform.childCount > 0)
        //{
        //    if (transform.GetChild(0).CompareTag("Pin") && transform.GetChild(0).CompareTag("Pin"))
        //    {
        //        gameObject.GetComponent<GridLayoutGroup>().cellSize = new Vector2(200f, 200f);
        //    }
        //}
    }
}
