using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSceneScript : MonoBehaviour
{
    public GameSceneManager gsm;

    private void Start()
    {
        if (GameProgress.gpInstance != null)
        {
            GameProgress.gpInstance.locationCount = -1;
        }

        StartCoroutine(ResetGame());
    }

    private IEnumerator ResetGame()
    {
        yield return new WaitForSeconds(35f);
        gsm.LoadStartScene();
    }
}
