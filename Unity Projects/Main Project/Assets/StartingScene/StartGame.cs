using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class StartGame : MonoBehaviour
{
    public GameObject cam;
    public GameObject button;
    public GameObject logo;
    public GameObject credits;
    public GameObject credsButton;

    public GameSceneManager gsm;

    public void PlayGame()
    {
        cam.GetComponent<VideoPlayer>().playbackSpeed = 1;
        button.SetActive(false);
        logo.SetActive(false);
        credsButton.SetActive(false);

        StartCoroutine(MoveToPacking());
    }

    private IEnumerator MoveToPacking()
    {
        yield return new WaitForSeconds(16.7f);
        gsm.GoNext();
    }

    public void ShowCreds()
    {
        credits.SetActive(true);
    }

    public void CloseCreds()
    {
        credits.SetActive(false);
    }
}
