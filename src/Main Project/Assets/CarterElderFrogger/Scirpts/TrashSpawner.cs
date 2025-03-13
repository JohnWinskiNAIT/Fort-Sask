using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashSpawner : MonoBehaviour
{
    private float Timer = 3.0f;

    [SerializeField] GameObject Trash;
    [SerializeField] GameObject log;

    int trashnumber;

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
            trashnumber = Random.Range(0, 2);
            if (trashnumber == 0)
            {
                Instantiate(Trash, gameObject.transform);
            }
            if (trashnumber == 1)
            {
                Instantiate(log, gameObject.transform);
            }

            Timer = 3.0f;
        }
    }
}
