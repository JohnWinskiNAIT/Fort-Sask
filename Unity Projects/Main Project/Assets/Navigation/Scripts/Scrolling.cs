using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour
{
    public static int panelNumber;

    public GameObject currentLevel;
    public GameObject levelsParent;

    public GameObject leftTransform;
    public GameObject centerTransform;
    public GameObject rightTransform;



    // Start is called before the first frame update
    void Start()
    {
        panelNumber = 2;
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Transform child in levelsParent.transform)
        {
            if (child.gameObject.activeSelf)
            {
                currentLevel = child.gameObject; // Return the first active child
            }
        }

        switch (panelNumber)
        {
            case 1:
                currentLevel.transform.position = leftTransform.transform.position;
                break;

            case 2:
                currentLevel.transform.position = centerTransform.transform.position;
                break;

            case 3:
                currentLevel.transform.position = rightTransform.transform.position;
                break;
        }
    }

    public void ScrollRight()
    {
        if (panelNumber > 1)
        {
            FindAnyObjectByType<AudioManager>().Play("Click");
            panelNumber--;
        }


    }

    public void ScrollLeft()
    {

        if (panelNumber < 3)
        {
            FindAnyObjectByType<AudioManager>().Play("Click");
            panelNumber++;
        }
    }
}
