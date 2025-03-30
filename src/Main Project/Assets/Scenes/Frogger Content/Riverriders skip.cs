using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Riverridersskip : MonoBehaviour
{

    // Start is called before the first frame update
    public void SkipGame5()
    {
        LifeSystem.Boats = 3;
        LifeSystem.Lives = 0;
    }
}
