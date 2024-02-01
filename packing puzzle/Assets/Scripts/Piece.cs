using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
