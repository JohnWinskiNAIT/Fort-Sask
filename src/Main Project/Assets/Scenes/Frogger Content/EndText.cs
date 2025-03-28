using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndText : MonoBehaviour
{
    public TextMeshProUGUI endtext;
    // Start is called before the first frame update
    void Start()
    {
        endtext.text = LifeSystem.Boats.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
       
    }
}
