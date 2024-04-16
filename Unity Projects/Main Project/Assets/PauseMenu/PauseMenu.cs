using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    private bool isPaused;
    private bool isMuted;

    [SerializeField]
    public GameObject PauseMenuParent;

    public Sprite[] audioSprites;

    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        isMuted = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!PauseMenuParent.activeSelf)
            {
                openPauseMenu();
            }
            else
            {
                ResumeButton();
            }
            
        }
    }

    public void ResumeButton()
    {
        Time.timeScale = 1f;
        PauseMenuParent.SetActive(false);
        isPaused = false;
    }

    public void ResetButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SkipButton()
    {
        SceneManager.LoadScene("MainMap");
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void MuteButton()
    {


        if (!isMuted)
        {
            isMuted = true;
            GameObject.Find("MuteButton").GetComponent<Image>().sprite = audioSprites[1]; // muted
        }
        else
        {
            isMuted = false;
            GameObject.Find("MuteButton").GetComponent<Image>().sprite = audioSprites[0]; // default, not muted
        }
       
    }

    public void openPauseMenu()
    {
        
        if (!PauseMenuParent.activeSelf)
        {
            Time.timeScale = 0f;
            PauseMenuParent.SetActive(true);
            isPaused = true;
        }
        else
        {
            ResumeButton();
        }
    }


}
