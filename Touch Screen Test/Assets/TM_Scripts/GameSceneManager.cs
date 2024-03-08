using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    public void LoadMainScene() { SceneManager.LoadScene(0); }
    public void LoadPlayScene() { SceneManager.LoadScene(1); }
    public void LoadEndScene() { SceneManager.LoadScene(2); }
}
