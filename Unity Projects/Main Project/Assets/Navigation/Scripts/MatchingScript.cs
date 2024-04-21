using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MatchingScript : MonoBehaviour
{
    public string selectedDirection;
    public string selectedItem;

    public GameObject directionParent;
    public GameObject findItemsParent;

    public GameObject stopParent;

    [SerializeField]
    public GameObject[] levels;

    [SerializeField]
    public GameObject[] directions;

    public int levelCounter;

    public GameObject nextLevelButton;

    bool winSound;

    bool gameComplete;
    public GameObject gameCompleteCanvas;

    //public Animator transition;

    // Start is called before the first frame update
    void Start()
    {
        selectedDirection = "xd";
        selectedItem = "xdd";
        levelCounter = 1;
        winSound = true;

        gameComplete = false;
        gameCompleteCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Check current selected GUI item
        checkDirection();

        // Check current in-game item
        checkItems();

        if (selectedDirection == selectedItem)
        {

            //if matching make them non-interactible
            itemDone(selectedItem);

            if (stopParent.activeSelf == true && stopParent.transform.childCount == 3)
            {
                //refreshDirections();
                nextLevelButton.SetActive(true);
                if (winSound && levels[2].activeSelf)
                {
                    FindAnyObjectByType<AudioManager>().Play("Win");
                    winSound = false;
                }
            }

        }
    }

    public void checkDirection()
    {
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
                    selectedDirection = grandchild.parent.tag;

                }
            }
        }
    }

    public void checkItems()
    {
        Transform parentTransform = findItemsParent.transform; // Change this to the parent GameObject's transform
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
                    selectedItem = grandchild.parent.tag;

                }
            }
        }


    }

    public void itemDone(string itemTag)
    {
        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag(itemTag);

        // Iterate through each GameObject
        foreach (GameObject obj in taggedObjects)
        {

            if (obj.transform.parent == findItemsParent.transform)
            {
                obj.transform.SetParent(stopParent.transform);
            }


            // Try to get the Button component from the GameObject
            Button button = obj.GetComponent<Button>();

            // If the Button component exists, make it uninteractable
            if (button != null)
            {
                button.interactable = false;

            }
            else
            {
                Debug.LogWarning("No Button component found on: " + obj.name);
            }
        }
    }

    public void refreshDirection()
    {

        Transform parentTransform = directionParent.transform; // Change this to the parent GameObject's transform
        int childCount = parentTransform.childCount;

        // Iterate through each child
        for (int i = 0; i < childCount; i++)
        {
            Transform child = parentTransform.GetChild(i);

            // Try to get the Button component from the GameObject
            Button button = child.GetComponent<Button>();

            // If the Button component exists, make it uninteractable
            if (button != null)
            {
                button.interactable = true;

            }
            else
            {
                Debug.LogWarning("No Button component found on");
            }
        }

    }

    public void goNextLevel()
    {
        //transition.SetTrigger("Start");

        levels[levelCounter - 1].SetActive(false);
        directions[levelCounter - 1].SetActive(false);

        Scrolling.panelNumber = 2;

        if (levelCounter < 3)
        {
            levelCounter += 1;
            levels[levelCounter - 1].SetActive(true);
            directions[levelCounter - 1].SetActive(true);
        }
        else
        {
            levels[levelCounter - 1].SetActive(true);
            directions[levelCounter - 1].SetActive(true);
            CompletedGame();
        }

        nextLevelButton.SetActive(false);
    }

    public void CompletedGame()
    {
        gameComplete = true;
        gameCompleteCanvas.SetActive(true);
    }

}
