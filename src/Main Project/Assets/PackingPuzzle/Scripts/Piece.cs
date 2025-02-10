using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class Piece
{
    PackingPuzzleManager manager;

    // List<Point> points = new List<Point>();
	public Point[,] points;
    public List<GridPoint> usedGridPoints = new List<GridPoint>();
	
	public Piece(bool[,] shape)
	{
		manager = PackingPuzzleManager.Instance;
		manager.cellSize = 1.55f;
		points = new Point[shape.GetLength(0),shape.GetLength(1)];
		ComputePoints(shape, manager.cellSize);
	}
	
	void ComputePoints(bool[,] shape, float spacing)
	{
		float offX = shape.GetLength(0) / 2f * -spacing;
		float offY = shape.GetLength(1) / 2f * -spacing;
		for (int x = 0; x < shape.GetLength(0); x++)
		{
			for (int y = 0; y < shape.GetLength(1); y++)
			{
				if (shape[x,y])
				{
					Vector2 pos = new Vector2(x * spacing + offX, (shape.GetLength(1) - y - 1) * spacing + offY);
					points[x,y] = new Point(pos, pos);
				}
			}
		}
	}

    // public Piece(List<BoxCollider2D> colliders)
    // {
    //     manager = PackingPuzzleManager.Instance;
    //     manager.cellSize = 1.55f;
    //     FindPoints(colliders);
    // }

    // //Breaks down the piece to find grid block sized portions and puts a point class in the middle
    // void FindPoints(List<BoxCollider2D> colliders)
    // {
    //     foreach (BoxCollider2D collider in colliders)
    //     {
    //         //Gets point amount by dividing the collider size by the grid cell size
    //         int x_Boxes = (int)(Math.Round(collider.size.x / manager.cellSize));
    //         float y_Boxes = (int)(Math.Round(collider.size.y / manager.cellSize));
            
    //         //Finds starting point for iteration
    //         Vector2 originPoint = (Vector2)collider.transform.position + collider.offset;
    //         originPoint -= new Vector2(collider.size.x / 2, -collider.size.y / 2);
    //         originPoint += new Vector2(manager.cellSize / 2, -manager.cellSize / 2);

    //         //Loops through each "Cell" in the piece
    //         for(int i = 0; i < y_Boxes; i++)
    //         {
    //             for (int j = 0; j < x_Boxes; j++)
    //             {
    //                 //Gets the position relative to the center of the total piece
    //                 Vector2 relativeToCenter = originPoint - (Vector2)collider.transform.position;

    //                 //Adds a child point class
    //                 Point newPoint = new Point(originPoint, relativeToCenter);
    //                 points.Add(newPoint);

    //                 //Moves starting position for next point
    //                 originPoint.x += manager.cellSize;
    //             }
    //             originPoint.x -= (manager.cellSize * x_Boxes);
    //             originPoint.y -= manager.cellSize;
    //         }
    //     }
    // }

    // //Moves points with the piece using a function in each point class
    // public void movePoints(BoxCollider2D collider)
    // {
    //     foreach (Point point in points)
    //     {
    //         point.Move(collider);
    //     }
    // }
	
	//update point positions
	public void MovePoints(Transform tf)
	{
		for (int x = 0; x < points.GetLength(0); x++)
		{
			for (int y = 0; y < points.GetLength(1); y++)
			{
				Point point = points[x,y];
				if (point is not null)
				{
					point.Move(tf);
				}
			}
		}
	}

    //Function to snap the piece into the grid
    public void SnapPiece(GameObject piece)
    {
		//ok so im thinking like
		//find point closest to an unoccupied valid snap point
		//snap the entire piece based on that and navigating around the grid
		
		Tuple<GridData, int, int> bestData = null;
		Point bestPoint = null;
		int bestX = 0;
		int bestY = 0;
		
		for (int x = 0; x < points.GetLength(0); x++)
		{
			for (int y = 0; y < points.GetLength(1); y++)
			{
				Point point = points[x,y];
				if (point is not null)
				{
					point.Move(piece.transform);
					Tuple<GridData, int, int> data = point.GetClosestGridPoint(manager.grid);
					if (bestData is null || bestData.Item1.GetDistance().magnitude > data.Item1.GetDistance().magnitude)
					{
						bestPoint = point;
						bestData = data;
						bestX = x;
						bestY = y;
					}
				}
			}
		}
		
		//dont snap if its really far away or if its fake
		if (bestData is not null && (bestData.Item1.GetDistance().magnitude > manager.cellSize || bestData.Item1.GetGridPoint() is null))
		{
			bestData = null;
		}
		
		//todo make better
		if (bestData is not null)
		{
			//ok so we need to verify that everything is a) fully in bounds and b) not occupied
			//position of piece in board
			Debug.Log(bestData.Item2 + " a " + bestData.Item3);
			Debug.Log(bestX + " b " + bestY);
			int pieceX = bestData.Item2 - bestX;
			int pieceY = bestData.Item3 - bestY;
			Debug.Log(pieceX + " p " + pieceY);
			//verify that we're in bounds
			if (pieceX > -1 && pieceY > -1 && pieceX + points.GetLength(0) <= manager.grid.GetLength(0) && pieceY + points.GetLength(1) <= manager.grid.GetLength(1))
			{
				
				//snap
				piece.transform.position = bestData.Item1.GetGridPoint().GetPosition() - bestPoint.GetOffset();
				foreach (Point p in points)
				{
					p?.Move(piece.transform);
				}
				//todo mark points as occupied
			}
		}
		
		
        // bool canSnap = true;
        // List<Vector2> distances = new List<Vector2>();

        // //Calls the function in each point to get the closest grid point
        // foreach (Point point in points)
        // {
        //     GridData thisData = point.GetClosestGridPoint(manager.gridPoints);
        //     distances.Add(thisData.GetDistance());
        //     usedGridPoints.Add(thisData.GetGridPoint());
        // }

        // Vector2 avgDistance = new Vector2();
        // Vector2 expectedDistance = new Vector2();

        // //Gets the distances between each point and their closest grid point
        // foreach (Vector2 distance in distances)
        // {
        //     avgDistance += distance;

        //     //Expected distance that all points should follow to ensure they dont go for the same grid point
        //     if (expectedDistance.magnitude == 0)
        //     {
        //         expectedDistance = distance;
        //     }

        //     //Round compared variables
        //     expectedDistance = new Vector2((float)Math.Round(expectedDistance.x,1), (float)Math.Round(expectedDistance.y,1));
        //     Vector2 tempDistance = new Vector2((float)Math.Round(distance.x,1), (float)Math.Round(distance.y,1));

        //     //If points try to go different direction the piece does not snap to the grid
        //     if (expectedDistance != tempDistance)
        //     {
        //         canSnap = false;
        //     }
        // }

        // //Gets average distance between points and grid points to get a cleaner snap
        // avgDistance /= distances.Count;

        // //Snaps if conditions are met
        // if (canSnap)
        // {
        //     if (avgDistance.magnitude < manager.cellSize)
        //     {
        //         piece.transform.position += (Vector3)avgDistance;
        //         LockGridPoints();
        //     }
        // }
    }

    //Disables the activity of the occupied grids so other objects cannot be placed over already placed ones
    void LockGridPoints()
    {
        // foreach (GridPoint gridPoint in usedGridPoints)
        // {
        //     foreach (GridPoint managerGridPoint in manager.gridPoints)
        //     {
        //         if (gridPoint.GetPosition() == managerGridPoint.GetPosition())
        //         {
        //             managerGridPoint.SetActivity(false);
        //         }
        //     }
        // }
    }
}
