
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashSpawner : MonoBehaviour
{
    private float Timer = 0.0f;

    private float randomtime;

    [SerializeField] GameObject Trash;
    [SerializeField] GameObject Trash2;
    [SerializeField] GameObject log;

    [SerializeField] float minvalue;
    [SerializeField] float maxvalue;

    int trashnumber;

    // Start is called before the first frame update
    void Start()
    {
        randomtimecreater();
    }

    // Update is called once per frame
    void Update()
    {
        if (Timer <= randomtime)
        {
            Timer += Time.deltaTime;
        }
        if (Timer > randomtime)
        {
            trashnumber = Random.Range(0, 3);
            if (trashnumber == 0)
            {
                Instantiate(Trash, gameObject.transform);
            }
            if (trashnumber == 1)
            {
                Instantiate(log, gameObject.transform);
            }
            if (trashnumber == 2)
            {
                Instantiate(Trash2, gameObject.transform);
            }

            Timer = 0.0f;
            randomtimecreater();
        }


    }

    public void randomtimecreater()
    {
        Debug.Log("test");
        randomtime = Random.Range(minvalue, maxvalue);
    }
}
