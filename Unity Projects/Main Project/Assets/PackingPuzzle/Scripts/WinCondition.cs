using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    PackingPuzzleManager manager;

    private void Start()
    {
        manager = PackingPuzzleManager.Instance;
    }

    private void Update()
    {
        bool win = true;
        foreach(GridPoint point in manager.gridPoints)
        {
            if (point.GetActivity())
            {
                win = false;
            }
        }
   }
}
