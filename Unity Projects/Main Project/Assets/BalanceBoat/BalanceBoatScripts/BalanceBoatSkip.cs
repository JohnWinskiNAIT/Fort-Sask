using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalanceBoatSkip : MonoBehaviour
{
    public BalanceGameManager bgm;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    
    public void SkipToMaxTimer()
    {
        bgm.gameCurrentTimer = bgm.gameCountTimer;
    }
}
