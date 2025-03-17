using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class BoatBody : MonoBehaviour
{
    [SerializeField]
    public Rigidbody2D rb;

    //[SerializeField]
     AudioSource audioSource;

    [SerializeField]
    public GameObject respawnPoint;

    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }
    void Update()
    {
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
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Log")
        {
            audioSource.Play();
            Debug.Log("Live Lost!");
            Scoring.Score = 0;
            LifeSystem.Lives -= 1;
<<<<<<< Updated upstream
            Respawn();
=======
            SceneManager.LoadScene(8);
           
>>>>>>> Stashed changes
        }
    }

    public void Respawn()
    {
        transform.position = respawnPoint.transform.position;
    }
}
