using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour
{
    public static int Score = 0;

    public Text scoreText;

    private void Start()
    {
        
    }

    private void Update()
    {
        scoreText.text = $"Score: {Score}";
    }
}
