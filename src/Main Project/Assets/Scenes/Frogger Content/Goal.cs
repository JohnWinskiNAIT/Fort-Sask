using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;


public class Goal : MonoBehaviour
{
    [SerializeField] GameObject Winscreen;
    [SerializeField] GameObject Boat;
    [SerializeField] GameObject respawnPoint;
    [SerializeField] GameObject life1;
    [SerializeField] GameObject life2;
    [SerializeField] GameObject life3;

    private void Start()
    {
        life1.SetActive(true);
        life2.SetActive(true);
        life3.SetActive(true);
    }

    private void Update()
    {
        if (LifeSystem.Lives == 2)
        {
            life1.SetActive(false);
        }

        if (LifeSystem.Lives == 1)
        {
            life2.SetActive(false);
        }

        if (LifeSystem.Lives == 0)
        {
            life3.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Raft")
        {
            Debug.Log("You Win!");
            //Scoring.Score += 100;
            LifeSystem.Boats++;
            LifeSystem.Lives--;
            Boat.transform.position = respawnPoint.transform.position;
            //Winscreen.SetActive(true);
            //SceneManager.LoadScene(7);
        }
    }

    public void GoToEndScreen()
    {
        //SceneManager.LoadScene(7);
        SceneManager.LoadScene(2);
    }
}
