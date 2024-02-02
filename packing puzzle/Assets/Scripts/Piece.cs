using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class Piece
{
    GameManager manager;

    List<Point> points = new List<Point>();

    public Piece(List<BoxCollider2D> colliders)
    {
        manager = GameManager.Instance;
        FindPoints(colliders);
    }

    void FindPoints(List<BoxCollider2D> colliders)
    {
        foreach (BoxCollider2D collider in colliders)
        {
            int x_Boxes = (int)(Math.Round(collider.size.x / manager.cellSize));
            float y_Boxes = (int)(Math.Round(collider.size.y / manager.cellSize));

            Vector2 originPoint = (Vector2)collider.transform.position + collider.offset;
            originPoint -= new Vector2(collider.size.x / 2, -collider.size.y / 2);
            originPoint += new Vector2(manager.cellSize / 2, -manager.cellSize / 2);

            for(int i = 0; i < y_Boxes; i++)
            {
                for (int j = 0; j < x_Boxes; j++)
                {
                    Vector2 relativeToCenter = originPoint - (Vector2)collider.transform.position;
                    Point newPoint = new Point(originPoint, relativeToCenter);
                    points.Add(newPoint);
                    originPoint.x += manager.cellSize;
                }
                originPoint.x -= (manager.cellSize * x_Boxes);
                originPoint.y -= manager.cellSize;
            }
        }
    }

    public void movePoints(BoxCollider2D collider)
    {
        foreach (Point point in points)
        {
            point.Move(collider);
        }
    }

    public void SnapPiece(GameObject piece)
    {
        bool snap = true;
        List<Vector2> distances = new List<Vector2>();
        foreach (Point point in points)
        {
            distances.Add(point.GetClosestGridPoint(manager.gridPoints));
        }

        Vector2 avgDistance = new Vector2();
        Vector2 presumedAvg = new Vector2();
        foreach (Vector2 distance in distances)
        {
            avgDistance += distance;
            presumedAvg += new Vector2(Math.Abs(distance.x), Math.Abs(distance.y));

            if (Math.Abs(avgDistance.magnitude) < presumedAvg.magnitude) { snap = false; }
        }
        avgDistance /= distances.Count;
        if (avgDistance.magnitude < manager.cellSize)
        {
            if (snap)
            {
                piece.transform.position += (Vector3)avgDistance;
            }
        }
    }
}
