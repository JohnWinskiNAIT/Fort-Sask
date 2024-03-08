using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameProgress : MonoBehaviour
{
    public static GameProgress gpInstance = null;

    public int locationCount;
    public bool played;

    private void Awake()
    {
        played = false;

        if (gpInstance == null)
        {
            gpInstance = this;
            locationCount = -1;

            DontDestroyOnLoad(this.gameObject);
        }
        else if (gpInstance != this)
        {
            Destroy(gameObject);
        }
    }

    //public void LoadMainScene()
    //{
    //    SceneManager.LoadScene(0);
    //    played = false;
    //}
    //public void LoadPlayScene()
    //{
    //    SceneManager.LoadScene(1);
    //}
}
