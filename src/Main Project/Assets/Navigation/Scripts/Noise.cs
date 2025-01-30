using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Noise : MonoBehaviour
{
    void Start()
    {
        FindAnyObjectByType<AudioManager>().Play("Background");
    }
}
