using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    [SerializeField]
    GameObject startBoxes;

    [SerializeField]
    GameObject[] cartItems;

    [SerializeField]
    Sprite[] brokenCartItems;

    GameObject brokenTag;
    GameObject CorrectBoxes;

    [SerializeField]
    GameObject nextLevel;

    int winCon = 2;

    private bool winConPicked = false;
    bool winSound = true;

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
            pickedWinCon(GameObject.Find("ItemBoxes").transform);

            // If the grandchild is found, do something
            if (winConPicked)
            {
                startBoxes.SetActive(false);
                gameObject.GetComponent<Button>().enabled = false;
                GameObject.Find("WheelPin").GetComponent<Image>().raycastTarget = true;
            }
        }

        if (GameObject.Find("CorrectBoxes").transform.GetChild(1).gameObject.transform.childCount > 0)
        {
            checkWinCon();
        }

        
    }

    public void generateBrokenPart()
    {
        int partIndex = Random.Range(1, 4);
        GameObject whichPart = GameObject.Find("StartParent").transform.GetChild(partIndex - 1).gameObject;

        Debug.Log(partIndex);

        whichPart.GetComponent<Image>().sprite = brokenCartItems[partIndex - 1];

        brokenTag.transform.SetParent(whichPart.transform);
    }

    public void openStartBoxes()
    {
        if (!startBoxes.activeSelf)
        {
            startBoxes.SetActive(true);
        }
        else
        {
            startBoxes.SetActive(false);
        }


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
                GameObject.Find("Glow").SetActive(false);
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
            if (winSound)
            {
                FindAnyObjectByType<AudioManager>().Play("Win");
                winSound = false;
            }
            nextLevel.SetActive(true);
        }
        else if (winCon == 0)
        {
            SceneManager.LoadScene(4);
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
