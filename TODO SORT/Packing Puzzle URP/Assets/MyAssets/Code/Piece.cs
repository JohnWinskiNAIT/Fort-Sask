using System;
using System.Collections.Generic;
using UnityEngine;

public class Piece
{
    Manager manager;

    List<Point> points = new List<Point>();

    public Piece(List<BoxCollider2D> colliders)
    {
        manager = Manager.Instance;
        FindPoints(colliders);
    }

    //Breaks down the piece to find grid block sized portions and puts a point class in the middle
    void FindPoints(List<BoxCollider2D> colliders)
    {
        foreach (BoxCollider2D collider in colliders)
        {
            //Gets point amount by dividing the collider size by the grid cell size
            int x_Boxes = (int)(Math.Round(collider.size.x / manager.cellSize));
            float y_Boxes = (int)(Math.Round(collider.size.y / manager.cellSize));
            
            //Finds starting point for iteration
            Vector2 originPoint = (Vector2)collider.transform.position + collider.offset;
            originPoint -= new Vector2(collider.size.x / 2, -collider.size.y / 2);
            originPoint += new Vector2(manager.cellSize / 2, -manager.cellSize / 2);

            //Loops through each "Cell" in the piece
            for(int i = 0; i < y_Boxes; i++)
            {
                for (int j = 0; j < x_Boxes; j++)
                {
                    //Gets the position relative to the center of the total piece
                    Vector2 relativeToCenter = originPoint - (Vector2)collider.transform.position;

                    //Adds a child point class
                    Point newPoint = new Point(originPoint, relativeToCenter);
                    points.Add(newPoint);

                    //Moves starting position for next point
                    originPoint.x += manager.cellSize;
                }
                originPoint.x -= (manager.cellSize * x_Boxes);
                originPoint.y -= manager.cellSize;
            }
        }
    }

    //Moves points with the piece using a function in each point class
    public void movePoints(BoxCollider2D collider)
    {
        foreach (Point point in points)
        {
            point.Move(collider);
        }
    }

    //Function to snap the piece into the grid
    public void SnapPiece(GameObject piece)
    {
        bool canSnap = true;
        List<Vector2> distances = new List<Vector2>();

        //Calls the function in each point to get the closest grid point
        foreach (Point point in points)
        {
            distances.Add(point.GetClosestGridPoint(manager.gridPoints));
        }

        Vector2 avgDistance = new Vector2();
        Vector2 expectedDistance = new Vector2();

        //Gets the distances between each point and their closest grid point
        foreach (Vector2 distance in distances)
        {
            avgDistance += distance;

            //Expected distance that all points should follow to ensure they dont go for the same grid point
            if (expectedDistance.magnitude == 0)
            {
                expectedDistance = distance;
            }

            //Round compared variables
            expectedDistance = new Vector2((float)Math.Round(expectedDistance.x), (float)Math.Round(expectedDistance.y));
            Vector2 tempDistance = new Vector2((float)Math.Round(distance.x), (float)Math.Round(distance.y));

            //If points try to go different direction the piece does not snap to the grid
            if (expectedDistance != tempDistance)
            {
                canSnap = false;
            }
        }

        //Gets average distance between points and grid points to get a cleaner snap
        avgDistance /= distances.Count;

        //Snaps if conditions are met
        if (canSnap)
        {
            if (avgDistance.magnitude < manager.cellSize)
            {
                piece.transform.position += (Vector3)avgDistance;
            }
        }
    }
}
