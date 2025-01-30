using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenWheelScaleDown : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if(transform.IsChildOf())
        
        if(gameObject.transform.parent != null && gameObject.transform.parent.CompareTag("ItemBox"))
        {
            transform.localScale = new Vector3(3.5f, 3.5f, 3.5f);
        }

        if (gameObject.transform.childCount > 0)
        {
            transform.localScale = new Vector3(2.0f, 2.0f, 2.0f);
        }

    }
}
