using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    PackingPuzzleManager manager;
    public GameObject button;
    public GameObject loreInfo;
    bool playable = true;

    private void Start()
    {
        manager = PackingPuzzleManager.Instance;
        loreInfo.SetActive(false);
        button.SetActive(false);
    }

    private void Update()
    {
        bool win = true;
        //If all grid pieces are covered
        foreach (GridPoint point in manager.gridPoints)
        {
            if (point.GetActivity())
            {
                win = false;
            }
        }

        if (win)
        {
            if (playable)
            {
                FindAnyObjectByType<AudioManager>().Play("Win");
                playable = false;
            }
            //button.SetActive(true);
            CompleteGame();
        }
    }

    public void CompleteGame()
    {
        loreInfo.SetActive(true);
    }
}
