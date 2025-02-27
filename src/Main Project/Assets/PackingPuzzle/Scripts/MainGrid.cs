using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGrid : MonoBehaviour
{
    PackingPuzzleManager manager;
    public int widthCellNumber = 7;
    public int heightCellNumber = 5;

    //Positioning grid points
    private void Start()
    {
		Screen.SetResolution(1920, 1080, true);
		
        manager = PackingPuzzleManager.Instance;

        //Getting grid dimentions off of invisable gameObject
        float gridWidth = gameObject.transform.localScale.x;
        float gridHeight = gameObject.transform.localScale.y;
        Vector2 centerPoint = transform.position;

        float cellWidth = gridWidth / widthCellNumber;
        float cellHeight = gridHeight / heightCellNumber;

        manager.cellSize = (cellHeight + cellWidth) / 2;
        
        //Starting point of the grid (top left)
        Vector2 originPoint = centerPoint - new Vector2(gridWidth / 2, -gridHeight / 2);
        originPoint.y -= cellHeight / 2;
        originPoint.x += cellWidth / 2;
		
		manager.grid = new GridPoint[widthCellNumber, heightCellNumber];
        
        //Iterate through grid cells to make each grid point and stores in a list in the game manager script
        for (int x = 0; x < widthCellNumber; x++)
        {
            for (int y = 0; y < heightCellNumber; y++)
            {
                GridPoint newPoint = new GridPoint(new Vector2(originPoint.x + cellWidth * (x - 0.5f), originPoint.y - cellHeight * (y + 0.5f)));
                // manager.gridPoints.Add(newPoint);
				manager.grid[x,y] = newPoint;
                // originPoint.x += cellWidth;
            }
            // originPoint.x -= cellWidth;
            // originPoint.y -= cellHeight;
        }
    }
}
