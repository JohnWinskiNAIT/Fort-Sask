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

    public void LoadMapScene() {
       
        SceneManager.LoadScene(2);

    }
    //public void LoadBalanceBoatScene() { SceneManager.LoadScene(3); }
    //public void LoadCartRepairScene() { SceneManager.LoadScene(4); }
    //public void LoadEndingScene() { SceneManager.LoadScene(5); }
    //public void LoadDummy() { SceneManager.LoadScene(2); }

    public void GoNext() { SceneManager.LoadScene(1); }

    public void LoadStartScene() { SceneManager.LoadScene(0); GameProgress.gpInstance = null; }

    public void LoadGameScene()
    {
        SceneManager.LoadScene(gameProgress.locationCount + 3);
    }

    public void LoadLevelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    public void LoadPacking()
    {

        SceneManager.LoadScene(1);

    }
    public void LoadNavagation()
    {
        
        SceneManager.LoadScene(3);
    }
    public void LoadRepair()
    {

        SceneManager.LoadScene(4);
    }
    public void LoadHorse()
    {

        SceneManager.LoadScene(5);
    }
    public void LoadRiverCrossing()
    {

        SceneManager.LoadScene(6);
    }
}
