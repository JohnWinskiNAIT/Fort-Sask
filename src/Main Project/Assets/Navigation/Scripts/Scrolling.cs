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

    public GameObject leftButton;
    public GameObject rightButton;

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
                // Removes button when on far right panel - Michael Taylor / Feb 12th 2025
                rightButton.SetActive(false);
                break;

            case 2:
                currentLevel.transform.position = centerTransform.transform.position;
                // Add buttons back in when on center panel - Michael Taylor / Feb 12th 2025
                leftButton.SetActive(true);
                rightButton.SetActive(true);
                break;

            case 3:
                currentLevel.transform.position = rightTransform.transform.position;
                // Removes button when on far left panel - Michael Taylor / Feb 12th 2025
                leftButton.SetActive(false);
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
