using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CorrectBoxManager : MonoBehaviour
{
    [SerializeField] GameObject WheelBox;
    [SerializeField] GameObject Wheel;
    [SerializeField] GameObject JointBox;
    [SerializeField] GameObject Joint;
    [SerializeField] GameObject PinBox;
    [SerializeField] GameObject Pin;
    [SerializeField] GameObject startParent;
    //public static GameObject GameWin;



    // Start is called before the first frame update
    void Start()
    {
        //GameWin = GameObject.Find("nextLevel");
    }

    // Update is called once per frame
    void Update()
    {
        if (startParent.transform.childCount == 1)
        {
            WheelBox.SetActive(true);
        }

        if (Wheel.transform.childCount == 0)
        {
            
            WheelBox.SetActive(true);
            Wheel.transform.SetParent(WheelBox.transform, false);
            if (Joint.transform.childCount == 0)
            {
                JointBox.SetActive(true);
                Joint.transform.SetParent(JointBox.transform, false);
            }

        }
        
       


        Checkcorrectpalcement();
       
       
       
    }

    public void Checkcorrectpalcement()
    {
        if (WheelBox.transform.childCount > 0)
        {
            ////WheelBox.transform.GetChild(0).gameObject.transform.localScale = new Vector3(5.4f, 5.4f, 5.4f);
            WheelBox.transform.GetChild(0).gameObject.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            WheelBox.transform.GetChild(0).gameObject.transform.GetComponent<Image>().raycastTarget = false;
            //if (WheelBox.transform.GetChild(0).gameObject.transform.childCount == 1)
            //{
            //    Debug.Log("Test");
            //}
            //else
            //{
            //    JointBox.SetActive(true);
            //}
            JointBox.SetActive(true);


            if (JointBox.transform.childCount > 0)
            {
                //JointBox.transform.GetChild(0).gameObject.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
                PinBox.SetActive(true);
                if (PinBox.transform.childCount > 0)
                {
                    //PinBox.transform.GetChild(0).gameObject.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
                    //GameWin.SetActive(true);

                }

            }

        }
    }

    public void GoNext()
    {
        SceneManager.LoadScene(1);
    }

    //void checkWinCon()
    //{

    //    foreach (Transform child in GameObject.Find("CorrectBoxes").transform)
    //    {
    //        foreach (Transform grandChild in child)
    //        {
    //            if (grandChild.childCount > 0)
    //            {
    //                winCon = 0;
    //            }
    //        }
    //    }

    //    showEnd();
    //}
}
