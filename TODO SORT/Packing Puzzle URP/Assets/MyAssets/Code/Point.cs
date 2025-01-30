using System;
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

    //Ensures the points always stay in the same position relative to the parenting pieces center
    public void Move(BoxCollider2D collider)
    {
        coordinates = (Vector2)collider.transform.position + relativeToPieceCenter;
    }

    //Gets the closest grid point to this piece point class
    public Vector2 GetClosestGridPoint(List<Vector2> cords)
    {
        Vector2 distance = new Vector2(10,10);
        
        //Iterates through each grid point and stores the closest one
        foreach(Vector2 cord in cords)
        {
            if (Math.Abs(distance.magnitude) > Math.Abs((cord - coordinates).magnitude))
            {
                distance = cord - coordinates;
            }
        }

        return distance;
    }
}
