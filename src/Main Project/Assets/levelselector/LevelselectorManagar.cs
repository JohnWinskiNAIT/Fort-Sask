using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class LevelselectorManagar : MonoBehaviour
{
    public GameSceneManager gsm;
    VideoPlayer player;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<VideoPlayer>();
        player.Pause();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Game1()
    {
        gsm.LoadPacking();
       
    }
    public void Game2()
    {
        gsm.LoadNavagation();
       
    }
    public void Game3()
    {
        gsm.LoadRepair();
    }
    public void Game4()
    {
        gsm.LoadHorse();
    }
    public void Game5()
    {
        gsm.LoadRiverCrossing();
    }

    public void NewGame()
    {
        gsm.LoadStartScene();
    }
}
