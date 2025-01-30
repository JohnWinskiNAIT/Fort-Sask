using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateTransitions : MonoBehaviour
{
    public GameObject fadeTransitions;

    // Start is called before the first frame update
    void Start()
    {
        fadeTransitions.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
