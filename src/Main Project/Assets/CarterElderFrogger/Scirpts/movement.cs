using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class movement : MonoBehaviour
{
    private Vector3 upPositionAdded;
    private Vector3 leftPositionAdded;
    private Vector3 rightPositionAdded;

    [SerializeField] Transform startLocation;

    [SerializeField] Button upbutton;
    [SerializeField] Button leftButton;
    [SerializeField] Button rightButton;

    [SerializeField] GameObject endPannel;

   
    [SerializeField] TextMeshProUGUI endText;

    [SerializeField] TextMeshProUGUI BoatNumberText;

    [SerializeField] int Boatnumber;
    [SerializeField] int BoatsThatMadeIt;

    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        Boatnumber = 3;
        BoatsThatMadeIt = 0;
        upPositionAdded = new Vector3(0, 1);
        rightPositionAdded = new Vector3(1,0);
        leftPositionAdded = new Vector3(-1, 0);
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        #region buttons
        // for the buttons showing up
        if (gameObject.GetComponent<Transform>().position.x >= 10)
        {
            rightButton.gameObject.SetActive(false);
        }
        else
        {
            rightButton.gameObject.SetActive(true);
        }
 
        if (gameObject.GetComponent<Transform>().position.x <= -10)
        {
            leftButton.gameObject.SetActive(false);
        }
        else 
        {
            leftButton.gameObject.SetActive(true);
        }
        #endregion
        #region end text and pannel

        if (Boatnumber == 0)
        {
            endPannel.SetActive(true);
            endText.text = "you have made "+ BoatsThatMadeIt.ToString() + " Boats";
            upbutton.interactable = false;
           leftButton.interactable = false;
            rightButton.interactable = false;

        }

        #endregion

        BoatNumberText.text = "Boats Left = " + Boatnumber.ToString();
    }
    public void moveup()
    {
        //gameObject.transform.Translate(upPositionAdded);
        Vector3 direction = transform.position + upPositionAdded;
        StartCoroutine(Move(direction));
    }
    public void moveright()
    {
        Vector3 direction = transform.position + rightPositionAdded;
        StartCoroutine(Move(direction));
    }

    public void moveleft()
    {
        Vector3 direction = transform.position + leftPositionAdded;
        StartCoroutine(Move(direction));

    }

    private IEnumerator Move(Vector3 destination )
    {
        Vector3 stratlocation = transform.position;

        float elapsted = 0f;
        float duration = 0.12f;
        

        while (elapsted < duration)
        {
            float t = elapsted/duration;
            transform.position = Vector3.Lerp(stratlocation, destination, t);
           
            elapsted += Time.deltaTime;
            yield return null;
        }
       transform.position = destination;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Trash")
        {
            //destory the trash
            audioSource.Play();
            Destroy(collision.gameObject);
            Debug.Log("hit");

            //rest the location
            transform.position = startLocation.GetComponent<Transform>().position;

            //boat number
            Boatnumber--;


        }
        if (collision.gameObject.tag == "Finish")
        {
            //rest the location
            transform.position = startLocation.GetComponent<Transform>().position;

            Boatnumber--;

            BoatsThatMadeIt++;
        }
    }
}
