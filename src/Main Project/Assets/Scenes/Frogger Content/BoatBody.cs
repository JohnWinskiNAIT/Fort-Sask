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

    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        LifeSystem.Lives = 3;
        EndScreen.SetActive(false);
    }
    void Update()
    {
        #region keymovement
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rb.MovePosition(rb.position + Vector2.right);
        }

        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rb.MovePosition(rb.position + Vector2.left);
        }

        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.MovePosition(rb.position + Vector2.up);
        }

        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            rb.MovePosition(rb.position + Vector2.down);
        }
        #endregion

        if (LifeSystem.Lives == 0)
        {
            EndScreen.SetActive(true);
            foreach (GameObject gameobject in buttons)
            {
                gameobject.SetActive(false);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Log")
        {
            audioSource.Play();
            Debug.Log("Live Lost!");
            Scoring.Score = 0;
            LifeSystem.Lives -= 1;

            Respawn();

            //SceneManager.LoadScene(7);
           

        }
    }

    public void Respawn()
    {
        transform.position = respawnPoint.transform.position;
    }
}
