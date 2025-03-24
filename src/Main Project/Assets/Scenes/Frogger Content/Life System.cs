using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LifeSystem : MonoBehaviour
{
    public static int Lives = 3;
    public static int Boats = 0;

    public Text livesText;
    public TextMeshProUGUI BoatText;

    private void Start()
    {
        Lives = 3;
        Boats = 0;
    }

    private void Update()
    {
        livesText.text = $"Boats: {Lives}";
        BoatText.text = " You Have Made " + Boats + "/3 Boats Across";

        if (Lives < 0)
        {
            Lives = 0;
        }
    }
}
