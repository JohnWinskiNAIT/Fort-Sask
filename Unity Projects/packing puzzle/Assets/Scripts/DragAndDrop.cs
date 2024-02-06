using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    public List<BoxCollider2D> colliders;
    Piece myPiece;
    GameObject myGameObject;

    private bool isDragging;


    private void Start()
    {
        //Class that represents the piece the script resides in
        myPiece = new Piece(colliders);

        myGameObject = this.gameObject;
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
    }

    public void OnMouseUp()
    {
        isDragging = false;

        //Snapping piece into the grid
        myPiece.SnapPiece(myGameObject);
    }
}