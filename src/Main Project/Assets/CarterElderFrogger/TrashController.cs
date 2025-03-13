using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashController : MonoBehaviour
{
    [SerializeField] float speed;

    private float Timer = 15.0f;
    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(2f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        if (Timer <= 15)
        {
            Timer -= Time.deltaTime;
        }
        if (Timer < 0)
        {
            Destroy(gameObject);
           
        }
    }
   
}
