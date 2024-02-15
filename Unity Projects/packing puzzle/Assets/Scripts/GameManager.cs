using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public List<GridPoint> gridPoints = new List<GridPoint>();
    public float cellSize;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
}

public struct GridPoint
{
    Vector2 position;
    bool active;

    public GridPoint(Vector2 _position)
    {
        this.position = _position;
        active = true;
    }

    public Vector2 GetPosition()
    {
        return position;
    }

    public bool GetActivity()
    {
        return active;
    }
}