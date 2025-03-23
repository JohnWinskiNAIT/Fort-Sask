using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;


public class Goal : MonoBehaviour
{
    [SerializeField] GameObject Winscreen;
    [SerializeField] GameObject Boat;
    [SerializeField] GameObject respawnPoint;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("You Win!");
        Scoring.Score += 100;
        LifeSystem.Boats++;
        LifeSystem.Lives--;
        Boat.transform.position = respawnPoint.transform.position;
        //Winscreen.SetActive(true);
        //SceneManager.LoadScene(7);
    }

    public void GoToEndScreen()
    {
        SceneManager.LoadScene(7);
    }
}
