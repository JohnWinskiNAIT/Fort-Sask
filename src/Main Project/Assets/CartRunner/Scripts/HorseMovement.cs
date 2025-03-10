using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HorseMovement : MonoBehaviour
{
    PositionState position;

    float positionValue = 0;
	public float rowYOffset = 1.9f;
	
	CartRunnerManager manager;
	
	int health = 3;
	public Image[] hearts;
	public Sprite heartFull;
	public Sprite heartEmpty;
	
    private void Awake()
    {
        position = PositionState.Center;
    }
	
	void UpdateHealthHearts()
	{
		for (int i = 0; i < hearts.Length; i++)
		{
			hearts[i].sprite = i >= health ? heartEmpty : heartFull;
		}
	}

    private void Start()
    {
        FindObjectOfType<AudioManager>().Play("HorseGalloping");
		manager = FindAnyObjectByType<CartRunnerManager>();
		UpdateHealthHearts();
    }

    private void Update()
    {
        GetPosition();

        switch (position)
        {
            case PositionState.Top:
                transform.position = new Vector3(transform.position.x, manager.topRowY + rowYOffset, transform.position.z);
                break;

            case PositionState.Center:
                transform.position = new Vector3(transform.position.x, manager.middleRowY + rowYOffset, transform.position.z);
                break;

            case PositionState.Bottom:
                transform.position = new Vector3(transform.position.x, manager.bottomRowY + rowYOffset, transform.position.z);
                break;
        }
    }

    void GetPosition()
    {
        switch (positionValue)
        {
            case 1:
                position = PositionState.Top;
                break;

            case 0:
                position = PositionState.Center;
                break;

            case -1:
                position = PositionState.Bottom;
                break;

            default:
                break;
        }
    }

    public void moveUp()
    {
        if (positionValue != 1)
        {
            positionValue++;
        }
    }

    public void moveDown()
    {
        if (positionValue != -1)
        {
            positionValue--;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
		if (health == 0) return; //skip visual stuff if we're already game over'd
		
		health--;
		UpdateHealthHearts();
		
		if (health == 0)
		{
			// Destroy(gameObject);
			//todo tell cam to stop moving
			FindAnyObjectByType<CameraMovement>().GameOver();
			// return;
			GetComponent<Animator>().enabled = false;
		}
		
        StartCoroutine(HorseDamage());
    }

    IEnumerator HorseDamage()
    {
        int val = Random.Range(1, 4);
        switch (val)
        {
            case 1:
                FindObjectOfType<AudioManager>().Play("HorseSqueel6");
                break;

            case 2:
                FindObjectOfType<AudioManager>().Play("HorseSqueel7");
                break;

            case 3:
                FindObjectOfType<AudioManager>().Play("HorseSqueel8");
                break;

            case 4:
                FindObjectOfType<AudioManager>().Play("HorseSqueel9");
                break;
        }
      
        for (int i = 0; i < 3; i++)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(0.9f,0.7f,0.7f);
            yield return new WaitForSeconds(0.25f);
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            yield return new WaitForSeconds(0.25f);
        }
    }

    enum PositionState
    {
        Bottom,
        Center,
        Top
    }
}
