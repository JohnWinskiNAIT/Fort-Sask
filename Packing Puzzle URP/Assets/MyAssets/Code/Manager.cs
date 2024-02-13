using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager Instance;

    public List<Vector2> gridPoints;
    public float cellSize;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
}
