using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

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
