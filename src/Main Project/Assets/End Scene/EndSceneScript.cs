using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSceneScript : MonoBehaviour
{
    public GameSceneManager gsm;
    public GameObject skipButton;

    private void Start()
    {
        if (GameProgress.gpInstance != null)
        {
            GameProgress.gpInstance.locationCount = -1;
        }

        StartCoroutine(ResetGame());
    }
	
	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			skipButton.SetActive(true);
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
