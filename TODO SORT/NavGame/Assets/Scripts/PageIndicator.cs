using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageIndicator : MonoBehaviour
{

    [SerializeField]
    public int panelNumber;

    public Vector2 normalScale;

    // Start is called before the first frame update
    void Start()
    {
        normalScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (panelNumber == Scrolling.panelNumber)
        {
            transform.localScale = new Vector2(1.3f, 1.3f); 
        }
        else
        {
            transform.localScale = normalScale;
        }
    }
}
