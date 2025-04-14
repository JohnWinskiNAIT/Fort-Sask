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

    [SerializeField] GameObject Cross1;
    [SerializeField] GameObject Cross2;
    [SerializeField] GameObject Cross3;

    public AudioManager audioManager;

    public bool gameOver = false;

    [SerializeField]
    public Goal goal;

    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        LifeSystem.Lives = 3;
        Cross1.SetActive(false);
        Cross2.SetActive(false);
        Cross3.SetActive(false);
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
                audioManager.Play("Win");
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Log")
        {
            audioManager.Play("Crash");
            Debug.Log("Live Lost!");
            boathit();
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

    public void boathit()
    {
        if (LifeSystem.Lives == 3)
        {
            Cross1.SetActive(true);
        }
        if (LifeSystem.Lives == 2)
        {
            Cross2.SetActive(true);
        }
        if (LifeSystem.Lives == 1)
        {
            Cross3.SetActive(true);
        }
    }

    public void Respawn()
    {
        transform.position = respawnPoint.transform.position;
    }
}
