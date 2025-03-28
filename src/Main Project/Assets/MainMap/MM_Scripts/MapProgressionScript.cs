using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MapProgressionScript : MonoBehaviour
{
    public List<GameObject> mapMarkers;

    public GameObject miniGameScene;
    public GameObject endCreditScene;
    public GameObject FinalMapMarker;

    public GameObject playerCart;

    public Animator playerIcon;

    public InputAction progressClick;
    //public int clickCount;
    bool moving;
    bool completed;
    public bool textRunning;
    public bool textLaidOut;

    void Start()
    {
        // Hide all current markers at start
        for (int i = 0; i < mapMarkers.Count; i++)
        {
            mapMarkers[i].SetActive(false);
        }
        completed = false;
        textRunning = false;
        textLaidOut = false;

        miniGameScene.SetActive(false);
        endCreditScene.SetActive(false);
        GameProgress.gpInstance.played = false;

        // Will not work until a player has progressed
        if (GameProgress.gpInstance.locationCount > -1)
        {
            LoadProgress();
        }
    }

    void Update()
    {
        // Progresses after clicking anywhere
        if (true //progressClick.WasPressedThisFrame() //needing to explicitly click to move to the next area is odd.
            && GameProgress.gpInstance.locationCount < 5 
            && !textLaidOut // Prevents the player from spam tapping/clicking
            && !GameProgress.gpInstance.played) // Hard stop for players from progressing until they play
        {
            if (!completed && !moving)
            {
                GameProgress.gpInstance.locationCount++;
                mapMarkers[GameProgress.gpInstance.locationCount].SetActive(true);
                moving = true;
                textRunning = true;
                textLaidOut = true;
            }
        }
        
        // Will constantly shift the player icon until it reaches the main location
        if (moving)
        {
            playerIcon.StopPlayback();
            MovePlayer();
           
        }
       
        /* 
         * Activates once the texts are finished displaying
         * Refer to TextDisplay.Update()
         */
        if (GameProgress.gpInstance.played)
        {
            if (GameProgress.gpInstance.locationCount == 5)
            {
                endCreditScene.SetActive(true);
            }
            else
            {
                miniGameScene.SetActive(true);
            }
        }
    }

    /*
     * The player will be represented by an icon (currently as a cart)
     * This code will move the cart to the next lcoation.
     */
    void MovePlayer()
    {
       
        // Moves the icon towards the designated location
        playerCart.transform.position = Vector3.MoveTowards(playerCart.transform.position, 
            mapMarkers[GameProgress.gpInstance.locationCount].transform.position,
            2 * Time.deltaTime);
       

        // Will constantly shift the player icon until it reaches the main location
        if (playerCart.transform.position == mapMarkers[GameProgress.gpInstance.locationCount].transform.position)
        {
           
            moving = false;
            playerIcon.StartPlayback();
        }
    }

    /*
     * Loads the player progress after playing a minigame
     */
    void LoadProgress()
    {
        for (int i = -1; i < GameProgress.gpInstance.locationCount + 1; i++)
        {
            if (i != -1)
            {
                mapMarkers[i].SetActive(true);
            }
        }
        
        playerCart.transform.position = mapMarkers[GameProgress.gpInstance.locationCount].transform.position;
        
    }

    private void OnEnable()
    {
        progressClick.Enable();
    }
    private void OnDisable()
    {
        progressClick.Disable();
    }
}
