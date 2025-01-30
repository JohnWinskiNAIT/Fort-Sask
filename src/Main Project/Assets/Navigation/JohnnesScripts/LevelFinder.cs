using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFinder : MonoBehaviour
{
    public MatchingScript levelOne;
    public MatchingScript levelTwo;
    public MatchingScript levelThree;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void MSFinder()
    {
        if (levelOne.enabled == true)
        {
            levelOne.CompletedGame();
        }
        else if (levelTwo.enabled == true)
        {
            levelTwo.CompletedGame();
        }
        else
        {
            levelThree.CompletedGame();
        }
    }
}
