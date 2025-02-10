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
        myPiece.usedGridPoints = new List<GridPoint>();
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