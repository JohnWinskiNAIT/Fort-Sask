using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Video;

public class EndSceneScript : MonoBehaviour
{
    public GameSceneManager gsm;
    public GameObject skipButton;
	
	public string[] subtitlesText;
	public float[] subtitlesTime;
	public TMP_Text subtitles;
	int subtitlesIndex = 0;
	
	VideoPlayer video;

    private void Start()
    {
        if (GameProgress.gpInstance != null)
        {
            GameProgress.gpInstance.locationCount = -1;
        }

        StartCoroutine(ResetGame());
		
		video = GetComponent<VideoPlayer>();
		
		//fix mute not working on this
		video.SetDirectAudioMute(0, AudioManager.isMuted);
    }
	
	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			skipButton.SetActive(true);
		}
		
		//handle subtitles
		if (subtitlesIndex < subtitlesTime.Length && subtitlesTime[subtitlesIndex] < video.clockTime)
		{
			subtitles.text = subtitlesText[subtitlesIndex];
			subtitlesIndex++;
		}
	}

    private IEnumerator ResetGame()
    {
        yield return new WaitForSeconds(35f);
        gsm.LoadStartScene();
    }
	
	public void ResetGameInstant()
	{
		StopCoroutine(ResetGame());
		gsm.LoadStartScene();
	}
}
