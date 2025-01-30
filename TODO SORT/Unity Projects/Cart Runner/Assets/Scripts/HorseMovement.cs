using System.Collections;
using UnityEngine;

public class HorseMovement : MonoBehaviour
{
    PositionState position;

    int positionValue = 0;

    private void Awake()
    {
        position = PositionState.Center;
    }

    private void Update()
    {
        GetPosition();

        switch (position)
        {
            case PositionState.Top:
                transform.position = new Vector3(transform.position.x, 0, transform.position.z);
                break;

            case PositionState.Center:
                transform.position = new Vector3(transform.position.x, -0.7f, transform.position.z);
                break;

            case PositionState.Bottom:
                transform.position = new Vector3(transform.position.x, -1.4f, transform.position.z);
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
        Debug.Log("Detected");
        if(collision.GetComponent<ObsticleManager>().thisObsticle.GetState() == position.ToString())
        {
            StartCoroutine(HorseDamage());
        }
    }

    IEnumerator HorseDamage()
    {
        for (int i = 0; i < 3; i++)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            yield return new WaitForSeconds(0.25f);
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
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
