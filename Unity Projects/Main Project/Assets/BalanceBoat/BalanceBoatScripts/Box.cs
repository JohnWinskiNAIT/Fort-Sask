using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public PressureMeterManager pmm;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindAnyObjectByType<AudioManager>().Play("Splash");
        Debug.Log("Splash");

        pmm.boxKept--;
    }
}
