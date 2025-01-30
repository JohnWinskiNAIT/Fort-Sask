using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CorrectBoxManager : MonoBehaviour
{
    [SerializeField] GameObject WheelBox;
    [SerializeField] GameObject JointBox;
    [SerializeField] GameObject PinBox;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (WheelBox.transform.childCount > 0)
        {
            WheelBox.transform.GetChild(0).gameObject.transform.localScale = new Vector3(5.4f, 5.4f, 5.4f);
            WheelBox.transform.GetChild(0).gameObject.transform.GetComponent<Image>().raycastTarget = false;    
            JointBox.SetActive(true);
            

            if (JointBox.transform.childCount > 0)
            {
                JointBox.transform.GetChild(0).gameObject.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
                PinBox.SetActive(true);

                if (PinBox.transform.childCount > 0)
                {
                    PinBox.transform.GetChild(0).gameObject.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
                    
                    
                }
            }
        }
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(0);
    }
}
