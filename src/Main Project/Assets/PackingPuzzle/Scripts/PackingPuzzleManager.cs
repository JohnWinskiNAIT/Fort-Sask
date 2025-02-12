using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PackingPuzzleManager : MonoBehaviour
{
    public static PackingPuzzleManager Instance;

    // public List<GridPoint> gridPoints = new List<GridPoint>();
	public GridPoint[,] grid;
    public float cellSize;

    public UnityEvent resetEvent;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    //Reset piece locations and enable all grint points
    public void InvokeReset()
    {
        resetEvent.Invoke();
        foreach (GridPoint p in grid)
        {
            p.SetActivity(true);
        }
    }
}

public class GridPoint
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

    public void SetActivity(bool newActivity)
    {
        active = newActivity;
    }
}

public struct GridData
{
    Vector2 distance;
    GridPoint gridPoint;

    public void SetDistance(Vector2 newDistance)
    {
        distance = newDistance;
    }

    public void SetGridPoint(GridPoint newGridPoint)
    {
        gridPoint = newGridPoint;
    }

    public Vector2 GetDistance()
    {
        return distance;
    }

    public GridPoint GetGridPoint()
    {
        return gridPoint;
    }
}
