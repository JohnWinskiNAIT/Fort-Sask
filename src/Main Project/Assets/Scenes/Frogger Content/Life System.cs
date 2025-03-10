using UnityEngine;
using UnityEngine.UI;

public class LifeSystem : MonoBehaviour
{
    public static int Lives = 3;

    public Text livesText;

    private void Start()
    {
        livesText.text = $"Lives: {Lives}";
    }

    private void Update()
    {
        if (Lives < 0)
        {
            Lives = 0;
        }
    }
}
