using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CorrectBoxManager : MonoBehaviour
{
    [SerializeField] GameObject WheelBox;
    [SerializeField] GameObject JointBox;
    [SerializeField] GameObject PinBox;
   //public static GameObject GameWin;

    // Start is called before the first frame update
    void Start()
    {
        //GameWin = GameObject.Find("nextLevel");
    }

    // Update is called once per frame
    void Update()
    {
        if (WheelBox.transform.childCount > 0)
        {
            ////WheelBox.transform.GetChild(0).gameObject.transform.localScale = new Vector3(5.4f, 5.4f, 5.4f);
            WheelBox.transform.GetChild(0).gameObject.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            WheelBox.transform.GetChild(0).gameObject.transform.GetComponent<Image>().raycastTarget = false;
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
}
