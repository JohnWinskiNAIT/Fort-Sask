using UnityEngine;

public class MainGrid : MonoBehaviour
{
    Manager manager;
    int widthCellNum = 7;
    int heightCellNum = 5;

    //Positioning grid points
    private void Start()
    {
        manager = Manager.Instance;

        //Getting grid dimentions off of invisable gameObject
        float gridWidth = gameObject.transform.localScale.x;
        float gridHeight = gameObject.transform.localScale.y;
        Vector2 centerPoint = transform.position;

        float cellWidth = gridWidth / widthCellNum;
        float cellHeight = gridHeight / heightCellNum;

        manager.cellSize = (cellHeight + cellWidth) / 2;
        
        //Starting point of the grid (top left)
        Vector2 originPoint = centerPoint - new Vector2(gridWidth / 2, -gridHeight / 2);
        originPoint.y -= cellHeight / 2;
        originPoint.x += cellWidth / 2;
        
        //Iterate through grid cells to make each grid point and stores in a list in the game manager script
        for (int i = 0; i < heightCellNum; i++)
        {
            for (int j = 0; j < widthCellNum; j++)
            {
                Vector2 newPoint = new Vector2(originPoint.x, originPoint.y);
                manager.gridPoints.Add(newPoint);
                originPoint.x += cellWidth;
            }
            originPoint.x -= cellWidth * (widthCellNum);
            originPoint.y -= cellHeight;
        }
    }
}
