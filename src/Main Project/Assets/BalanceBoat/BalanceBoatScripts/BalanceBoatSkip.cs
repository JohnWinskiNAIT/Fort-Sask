using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalanceBoatSkip : MonoBehaviour
{
    public BalanceGameManager bgm;

    public void SkipToMaxTimer()
    {
        bgm.gameCurrentTimer = bgm.gameCountTimer;
    }
}
