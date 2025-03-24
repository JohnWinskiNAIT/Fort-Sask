using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class BoatBody : MonoBehaviour
{
    [SerializeField]
    public Rigidbody2D rb;

    //[SerializeField]
     AudioSource audioSource;

    [SerializeField] List<GameObject> buttons = new List<GameObject>();

    [SerializeField]
    public GameObject respawnPoint;

    [SerializeField] GameObject EndScreen;
    [SerializeField] GameObject LoseScreen;

    public bool gameOver = false;

    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        LifeSystem.Lives = 3;
        EndScreen.SetActive(false);
        gameOver = false;
    }
    void Update()
    {
        if (gameOver == false)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (rb.position.x < 8)
                {
                    rb.MovePosition(rb.position + Vector2.right);
                } 

                if (rb.position.x > 8)
                {
                    rb.position = new Vector2(8f, rb.position.y);
                }
            }

            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (rb.position.x > -8)
                {
                    rb.MovePosition(rb.position + Vector2.left);
                }

                if (rb.position.x < -8 )
                {
                    rb.position = new Vector2 (-8f, rb.position.y);
                }
            }

            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                rb.MovePosition(rb.position + Vector2.up);
            }

            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (rb.position.y < -5)
                {
                    rb.MovePosition(rb.position + Vector2.down);
                }
            }
        }

        #region keymovement
        
        #endregion

        if (LifeSystem.Lives == 0)
        {
            gameOver = true;
           
            foreach (GameObject gameobject in buttons)
            {
                gameobject.SetActive(false);
            }
            if (LifeSystem.Boats == 0)
            {
                LoseScreen.SetActive(true);
            }
            else 
            {
                EndScreen.SetActive(true);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Log")
        {
            audioSource.Play();
            
            Debug.Log("Live Lost!");
            //Scoring.Score = 0;
            LifeSystem.Lives -= 1;

            Respawn();

            //SceneManager.LoadScene(7); 
        }

        if (collision.tag == "Wall")
        {
            //Respawn();
        }
    }

    public void Respawn()
    {
        transform.position = respawnPoint.transform.position;
    }
}
