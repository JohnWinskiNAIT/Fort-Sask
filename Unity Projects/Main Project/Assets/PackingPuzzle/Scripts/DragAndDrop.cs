using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    public List<BoxCollider2D> colliders;
    PackingPuzzleManager manager;
    Piece myPiece;
    GameObject myGameObject;
    Vector2 originPosition;

    private bool isDragging;


    private void Start()
    {
        manager = PackingPuzzleManager.Instance;
        manager.resetEvent.AddListener(Reset);

        //Class that represents the piece the script resides in
        myPiece = new Piece(colliders);

        myGameObject = this.gameObject;
        originPosition = myGameObject.transform.position;
    }

    void Update()
    {
        if (isDragging)
        {
            //Pieces move with the mouse when dragging
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(mousePosition);

            //Function to move point classes with the piece class
            myPiece.movePoints(colliders[0]);
        }
    }

    public void OnMouseDown()
    {
        isDragging = true;
        foreach (GridPoint gridPoint in myPiece.usedGridPoints)
        {
            foreach (GridPoint managerGridPoint in manager.gridPoints)
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

        //Snapping piece into the grid
        myPiece.SnapPiece(myGameObject);
    }

    public void Reset()
    {
        myGameObject.transform.position = originPosition;
    }
}