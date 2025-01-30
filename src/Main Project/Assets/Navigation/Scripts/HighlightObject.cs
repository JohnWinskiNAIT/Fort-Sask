using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightObject : MonoBehaviour
{
    public GameObject highlight;
    public GameObject directionParent;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void HighlightThisThing()
    {
        bool isActive = highlight.activeSelf;

        Transform parentTransform = directionParent.transform; // Change this to the parent GameObject's transform
        int childCount = parentTransform.childCount;

        // Iterate through each child
        for (int i = 0; i < childCount; i++)
        {
            Transform child = parentTransform.GetChild(i);

            // Check if the child has any children
            int grandchildCount = child.childCount;

            // Iterate through each grandchild
            for (int j = 0; j < grandchildCount; j++)
            {
                Transform grandchild = child.GetChild(j);

                // Check if the grandchild is active and deactivate it if true
                if (grandchild.gameObject.activeSelf)
                {
                    grandchild.gameObject.SetActive(false);
                    Debug.Log("Deactivated: " + grandchild.gameObject.name);
                }
            }
        }

        // Toggle the activation status (if it's active, set to inactive; if it's inactive, set to active)
        highlight.SetActive(!isActive);

    }
}
