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
    public GameObject exitButton;
    public GameObject skipButton;
	
	public GameObject[] hideInCredits;

    public GameSceneManager gsm;
	
	bool isPlayingCutscene;

    public void PlayGame()
    {
        cam.GetComponent<VideoPlayer>().playbackSpeed = 1;
        button.SetActive(false);
        logo.SetActive(false);
        credsButton.SetActive(false);
        exitButton.SetActive(false);
       
        StartCoroutine(MoveToPacking());
		
		isPlayingCutscene = true;
    }
	
	void Update()
	{
		if (isPlayingCutscene && Input.GetMouseButtonDown(0))
		{
			skipButton.SetActive(true);
		}
	}
	
	public void MoveToPackingInstant()
	{
		StopCoroutine(MoveToPacking());
		gsm.GoNext();
	}

    private IEnumerator MoveToPacking()
    {
        yield return new WaitForSeconds(16.7f);
        gsm.GoNext();
    }

    public void ShowCreds()
    {
        credits.SetActive(true);
		exitButton.SetActive(false);
        button.SetActive(false);
        logo.SetActive(false);
        credsButton.SetActive(false);
    }

    public void CloseCreds()
    {
        credits.SetActive(false);
		exitButton.SetActive(true);
        button.SetActive(true);
        logo.SetActive(true);
        credsButton.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
