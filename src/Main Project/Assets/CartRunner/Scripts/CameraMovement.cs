using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject nextCam;
    bool playWin = true;
    public GameObject button;

    public GameObject loreInfo;
    public GameObject gameOverScreen;
	
	bool isMoving = true;
	
	public float topRowY = -3.3f;
	public float middleRowY = -3.7f;
	public float bottomRowY = -4.2f;

    private void Start()
    {
        loreInfo.SetActive(false);
		gameOverScreen.SetActive(false);

        //button.SetActive(false);
    }

    private void FixedUpdate()
    {
		if (isMoving)
		{
	        transform.position += new Vector3(0.1f, 0, 0);

	        if (gameObject.transform.position.x >= nextCam.transform.position.x)
	        {
	            nextCam.GetComponent<Camera>().enabled = true;
	            gameObject.GetComponent<Camera>().enabled = false;
	            //button.SetActive(true);

	            if (playWin )
	            {
	                FindAnyObjectByType<AudioManager>().Play("Win");
	                CompletedGame();
					isMoving = true;
	            }
	            FindAnyObjectByType<AudioManager>().AdjustVolume("HorseGalloping", -0.003f);
	        }
		}
    }

    public void CompletedGame()
    {
        playWin = false;
        loreInfo.SetActive(true);
		isMoving = false;
    }
	
	public void GameOver()
	{
		FindAnyObjectByType<AudioManager>().Pause("HorseGalloping");
        isMoving = false;
		gameOverScreen.SetActive(true);
	}
}
