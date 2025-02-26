using System;
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
	
	public Vector2 GetOffset()
	{
		return relativeToPieceCenter;
	}

    //Ensures the points always stay in the same position relative to the parenting pieces center
    public void Move(BoxCollider2D collider)
    {
        coordinates = (Vector2)collider.transform.position + relativeToPieceCenter;
    }
	
	//todo figure out where the other move func is used, use this instead
	public void Move(Transform tf)
	{
		coordinates = (Vector2)tf.position + relativeToPieceCenter;
	}

    // //Gets the closest grid point to this piece point class
    // public GridData GetClosestGridPoint(List<GridPoint> cords)
    // {
    //     GridData thisData = new GridData();
    //     thisData.SetDistance(new Vector2(10, 10));

    //     //Iterates through each grid point and stores the closest one
    //     foreach (GridPoint cord in cords)
    //     {
    //         if (cord.GetActivity())
    //         {
    //             if (Math.Abs(thisData.GetDistance().magnitude) > Math.Abs((cord.GetPosition() - coordinates).magnitude))
    //             {
    //                 thisData.SetDistance(cord.GetPosition() - coordinates);
    //                 thisData.SetGridPoint(cord);
    //             }
    //         }
    //     }
    //     return thisData;
    // }
	
	//same as above, but for the matrix
    public Tuple<GridData, int, int> GetClosestGridPoint(GridPoint[,] cords)
	{
        GridData thisData = new GridData();
        thisData.SetDistance(new Vector2(1000, 1000));
		// Debug.Log("start    " + cords.GetLength(0) + "  " + cords.GetLength(1));
        //Iterates through each grid point and stores the closest one
        int bestX = 0;
		int bestY = 0;
		for (int x = 0; x < cords.GetLength(0); x++)
		{
			for (int y = 0; y < cords.GetLength(1); y++)
			{
				GridPoint cord = cords[x,y];
	            if (cord is not null) // && cord.GetActivity()
	            {
					// Debug.Log(x + "  " + y);
	                if (Math.Abs(thisData.GetDistance().magnitude) > Math.Abs((coordinates - cord.GetPosition()).magnitude))
	                {
						// Debug.Log("yippee");
						// Debug.Log(x + "  " + y);
	                    thisData.SetDistance(coordinates - cord.GetPosition());
	                    thisData.SetGridPoint(cord);
						bestX = x;
						bestY = y;
	                }
	            }
			}
		}
		// Debug.Log(bestX + "  " + bestY);
        return new Tuple<GridData, int, int>(thisData, bestX, bestY);
	}
}
