using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            JointBox.SetActive(true);

            if (JointBox.transform.childCount > 0)
            {
                PinBox.SetActive(true);

                if (PinBox.transform.childCount > 0)
                {
                    PinBox.SetActive(true);
                    SceneManager.LoadScene(0);
                }
            }
        }
    }
}
