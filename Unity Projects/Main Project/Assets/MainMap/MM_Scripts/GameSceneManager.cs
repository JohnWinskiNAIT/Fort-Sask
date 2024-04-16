using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    public GameProgress gameProgress;

    private void Start()
    {
        gameProgress = FindFirstObjectByType<GameProgress>();
    }

    public void LoadMapScene() { SceneManager.LoadScene(2); }
    //public void LoadBalanceBoatScene() { SceneManager.LoadScene(3); }
    //public void LoadCartRepairScene() { SceneManager.LoadScene(4); }
    //public void LoadEndingScene() { SceneManager.LoadScene(5); }
    //public void LoadDummy() { SceneManager.LoadScene(2); }

    public void LoadGameScene()
    {
        SceneManager.LoadScene(gameProgress.locationCount + 3);
    }
}
