using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalanceGameManager : MonoBehaviour
{
    [Header("Start Timer")]
    public float startCountTimer = 3.0f;
    public float startCurrentTimer;
    private bool startCountdownStarted = false;
    bool winSound = true;

    [Header("Game Timer")]
    public float gameCountTimer = 50.0f;
    public float gameCurrentTimer;
    private bool gameCountdownStarted = false;

    [Header("Object References")]
    public Animator hgr;
    public Animator hgl;
    public GameObject mouseTracker;
    public GameObject lobbyButton;

    void Start()
    {
        hgl.enabled = false;
        hgr.enabled = false;
        mouseTracker.SetActive(false);

        startCountdownStarted = true;
        gameCountdownStarted = false;

        lobbyButton.SetActive(false);

        FindAnyObjectByType<AudioManager>().Play("River");
    }

    void Update()
    {
        if (startCountdownStarted)
        {
            startCurrentTimer += Time.deltaTime;
            if (startCurrentTimer >= startCountTimer)
            {
                hgl.enabled = true;
                hgr.enabled = true;
                mouseTracker.SetActive(true);

                startCountdownStarted = false;
                gameCountdownStarted = true;
            }
        }

        if (gameCountdownStarted)
        {
            gameCurrentTimer += Time.deltaTime;
            if (gameCurrentTimer >= gameCountTimer)
            {
                hgl.enabled = false;
                hgr.enabled = false;
                mouseTracker.SetActive(false);


                gameCountdownStarted = false;

                if (winSound)
                {
                    FindAnyObjectByType<AudioManager>().Play("Win");
                    winSound = false;
                }

                lobbyButton.SetActive(true);
            }
        }
    }
}
