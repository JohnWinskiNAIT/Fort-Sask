using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    public void LoadMapScene() { SceneManager.LoadScene(1); }
    public void LoadPackingScene() { SceneManager.LoadScene(2); }
    public void LoadBalanceBoatScene() { SceneManager.LoadScene(3); }
    public void LoadCartRepairScene() { SceneManager.LoadScene(4); }
    public void LoadEndingScene() { SceneManager.LoadScene(5); }
    public void LoadDummy() { SceneManager.LoadScene(2); }
}
