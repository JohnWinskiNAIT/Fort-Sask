using System;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    public List<BoxCollider2D> colliders;
    PackingPuzzleManager manager;
    Piece myPiece;
    GameObject myGameObject;
    Vector2 originPosition;
	Vector2 dragOffset;

    private bool isDragging;
	
	[TextArea(5,5)]
	public string collisionGrid; //parsed into bool[,] later
	
	//used for fixing relative z ordering of drag n droppable objects
	const float Z_ORDER_MAX = 0f;
	const float Z_ORDER_MIN = -1f;

    private void Start()
    {
        manager = PackingPuzzleManager.Instance;
        manager.resetEvent.AddListener(Reset);

        // //Class that represents the piece the script resides in
        // myPiece = new Piece(colliders);
		
		//parse collision grid into actual grid (unity doesnt show bool[,] in editor)
		int width = 0;
		int newWidth = 0;
		int height = 1;
		foreach (char c in collisionGrid)
		{
			if (c == '\n')
			{
				width = System.Math.Max(newWidth, width);
				newWidth = 0;
				height++;
			}
			else
			{
				newWidth++;
			}
		}
		width = System.Math.Max(newWidth, width);
		bool[,] points = new bool[width,height];
		string[] rows = collisionGrid.Split('\n');
		for (int y = 0; y < rows.Length; y++)
		{
			for (int x = 0; x < rows[y].Length; x++)
			{
				if (rows[y][x].Equals('X'))
				{
					// Debug.Log(x + "  " + y);
					points[x,y] = true;
				}
			}
		}
		myPiece = new Piece(points);

        myGameObject = this.gameObject;
        originPosition = myGameObject.transform.position;
    }

    void Update()
    {
        if (isDragging)
        {
            //Pieces move with the mouse when dragging
            // Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            // transform.Translate(mousePosition);
			Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + (Vector3)dragOffset;
			newPos.z = transform.position.z;
			transform.position = newPos;

            //Function to move point classes with the piece class
            // myPiece.movePoints(colliders[0]);
            myPiece.MovePoints(transform);
        }
    }
	
	int CompareDragDroppable(DragAndDrop a, DragAndDrop b)
	{
		float ia = a.gameObject.transform.position.z;
		float ib = b.gameObject.transform.position.z;
		return ia > ib ? 1 : ia == ib ? 0 : -1;
	}

    public void OnMouseDown()
    {
        isDragging = true;
		dragOffset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Re-enable Grid point activity when the corelating piece is moved
        foreach (GridPoint gridPoint in myPiece.usedGridPoints)
        {
            // foreach (GridPoint managerGridPoint in manager.gridPoints)
			foreach (GridPoint managerGridPoint in manager.grid)
            {
                if (gridPoint.GetPosition() == managerGridPoint.GetPosition())
                {
                    managerGridPoint.SetActivity(true);
                }
            }
        }
        myPiece.ClearGridPoints();
		
		//re-shuffle z ordering of all drag n drop things so that the more recently clicked objects are layered on top
		this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, Z_ORDER_MIN - 1f);
		
		DragAndDrop[] draggables = FindObjectsByType<DragAndDrop>(FindObjectsSortMode.None);
		Array.Sort(draggables, CompareDragDroppable);
		
		for (int i = 0; i < draggables.Length; i++)
		{
			Vector3 pos = draggables[i].gameObject.transform.position;
			draggables[i].gameObject.transform.position = new Vector3(pos.x, pos.y, Z_ORDER_MIN + (Z_ORDER_MAX - Z_ORDER_MIN) * (i / (float)(draggables.Length - 1)));
		}
    }

    public void OnMouseUp()
    {
        isDragging = false;
        FindAnyObjectByType<AudioManager>().Play(gameObject.name);
        //Snapping piece into the grid
        myPiece.SnapPiece(myGameObject);
    }

    //Move pieces back to there original position
    public void Reset()
    {
        myGameObject.transform.position = originPosition;
    }
}