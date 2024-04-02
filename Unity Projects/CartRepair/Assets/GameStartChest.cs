using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStartChest : MonoBehaviour
{
    [SerializeField]
    GameObject startBoxes;

    [SerializeField]
    GameObject[] cartItems;

    [SerializeField]
    Sprite[] brokenCartItems;

    GameObject brokenTag;
    GameObject CorrectBoxes;

    int winCon = 2;

    private bool winConPicked = false;

    // Start is called before the first frame update
    void Start()
    {
        startBoxes.SetActive(false);
        brokenTag = GameObject.Find("BrokenTag");
        CorrectBoxes = GameObject.Find("CorrectBoxes");
        GameObject.Find("WheelPin").GetComponent<Image>().raycastTarget = false;

        generateBrokenPart();
    }

    // Update is called once per frame
    void Update()
    {
        // for deactivating start boxes after something is picked
        if (startBoxes.activeSelf)
        {
            pickedWinCon(GameObject.Find("InventoryBoxes").transform);

            // If the grandchild is found, do something
            if (winConPicked)
            {
                startBoxes.SetActive(false);
                gameObject.GetComponent<Button>().enabled = false;
                GameObject.Find("WheelPin").GetComponent<Image>().raycastTarget = true;
            }
        }
    }

    public void generateBrokenPart()
    {
        int partIndex = Random.Range(1, 4);
        GameObject whichPart = GameObject.Find("GameStart").transform.GetChild(partIndex - 1).gameObject;

        Debug.Log(partIndex);

        whichPart.GetComponent<Image>().sprite = brokenCartItems[partIndex - 1];

        brokenTag.transform.SetParent(whichPart.transform);
    }

    public void openStartBoxes()
    {
        startBoxes.SetActive(true);

    }

    void pickedWinCon(Transform parent)
    {
        // Iterate through each child of the parent
        foreach (Transform child in parent)
        {
            // If the child has children, recursively search through them
            if (child.childCount > 0)
            {
                winConPicked = true;
            }
        }
    }

    void checkWinCon()
    {

        foreach (Transform child in CorrectBoxes.transform)
        {
            foreach (Transform grandChild in child)
            {
                if (grandChild.childCount > 0)
                {
                    winCon = 0;
                }
            }
        }

        showEnd();
    }

    void showEnd()
    {
        if (winCon == 2)
        {
            winCon = 1;
        }

        if (winCon == 1)
        {
            Debug.Log("Win");
        }
        else if (winCon == 0)
        {
            Debug.Log("Fail");
        }
    }

    int CountGrandchildren(Transform parent)
    {
        int count = 0;
        foreach (Transform child in parent)
        {
            foreach (Transform grandchild in child)
            {
                count++;
            }
        }
        return count;
    }
}
