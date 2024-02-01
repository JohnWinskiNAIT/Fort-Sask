using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point
{
    public Vector2 coordinates;
    Vector2 relativeToPieceCenter;

    public Point(Vector2 cords, Vector2 relativePosition)
    {
        coordinates = cords;
        relativeToPieceCenter = relativePosition;
    }

    public void Move(BoxCollider2D collider)
    {
        coordinates = (Vector2)collider.transform.position + relativeToPieceCenter;
    }
}
