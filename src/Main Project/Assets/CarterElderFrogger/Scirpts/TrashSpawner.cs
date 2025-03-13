using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashSpawner : MonoBehaviour
{
    private float Timer = 3.0f;

    [SerializeField] GameObject Trash;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Timer <= 3)
        {
            Timer -= Time.deltaTime;
        }
        if (Timer < 0)
        {
            Instantiate(Trash, gameObject.transform);
            Timer = 3.0f;
        }
    }
}
