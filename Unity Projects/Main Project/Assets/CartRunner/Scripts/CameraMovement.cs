using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject nextCam;
    bool playWin = true;
    public GameObject button;

    public GameObject loreInfo;

    private void Start()
    {
        loreInfo.SetActive(false);

        //button.SetActive(false);
    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(0.1f, 0, 0);

        if (gameObject.transform.position.x >= nextCam.transform.position.x)
        {
            nextCam.GetComponent<Camera>().enabled = true;
            gameObject.GetComponent<Camera>().enabled = false;
            button.SetActive(true);

            if (playWin )
            {
                FindAnyObjectByType<AudioManager>().Play("Win");
                CompletedGame();
            }
            FindAnyObjectByType<AudioManager>().AdjustVolume("HorseGalloping", -0.003f);
        }
    }

    public void CompletedGame()
    {
        playWin = false;
        loreInfo.SetActive(true);
    }
}
