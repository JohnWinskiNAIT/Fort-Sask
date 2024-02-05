using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    GameObject m_Camera;
    public TMP_Text text;

    public void ButtonPress()
    {
        m_Camera = GameObject.Find("Main Camera");

        m_Camera.GetComponent<Camera>().backgroundColor = new Color(0.25f, 1, 0.25f);
        text.SetText("Working!");
    }
}
