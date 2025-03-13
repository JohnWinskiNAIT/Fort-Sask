using UnityEngine;
using UnityEngine.UI;

public class LifeSystem : MonoBehaviour
{
    public static int Lives = 3;

    public Text livesText;

    private void Start()
    {
        
    }

    private void Update()
    {
        livesText.text = $"Lives: {Lives}";

        if (Lives < 0)
        {
            Lives = 0;
        }
    }
}
