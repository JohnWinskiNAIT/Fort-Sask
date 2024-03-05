using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemStacking : MonoBehaviour
{
    public GameObject currentItemLayer;
    public Image nextItemLayer;
    public GameObject inventoryBoxParent;
    public int happenOnce = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (happenOnce != 1)
        {
            if (IsObjectChild(currentItemLayer.transform))
            {
                nextItemLayer.raycastTarget = true;
                happenOnce += 1;
            }
        }
        
    }

    void SetRaycastTarget()
    {
        
        happenOnce += 1;
    }

    bool IsObjectChild(Transform childTransform)
    {
        // Use IsChildOf method to check if 'childTransform' is a child of the boxes
        return childTransform.IsChildOf(inventoryBoxParent.transform);
    }

    public void ResetGame()
    {
        
    }
}
