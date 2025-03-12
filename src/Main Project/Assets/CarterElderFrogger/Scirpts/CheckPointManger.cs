using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointManger : MonoBehaviour
{
   public List<GameObject> Lines = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < Lines.Count; i++)
        {
            Lines[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.tag == "Player")
        {
            for (int i = 0; i < Lines.Count; i++)
            {
                Lines[i].SetActive(true);
            }
        }
    }
}
