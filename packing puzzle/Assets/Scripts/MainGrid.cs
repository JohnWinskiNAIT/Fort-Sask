using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGrid : MonoBehaviour
{
    int widthCellNum = 7;
    int heightCellNum = 5;

    private void Start()
    {
        float gridWidth = gameObject.transform.localScale.x;
        float gridHeight = gameObject.transform.localScale.y;
        Vector2 centerPoint = transform.position;

        float cellWidth = gridWidth / widthCellNum;
        float cellHeight = gridHeight / heightCellNum;
        
        Vector2 originPoint = centerPoint - new Vector2(gridWidth / 2, -gridHeight / 2);
        originPoint.y -= cellHeight / 2;
        originPoint.x += cellWidth / 2;
        
        for (int i = 0; i < heightCellNum; i++)
        {
            for (int j = 0; j < widthCellNum; j++)
            {

            }
        }
    }
}
