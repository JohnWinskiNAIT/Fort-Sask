using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    public List<BoxCollider2D> colliders;
    Piece myPiece;

    private bool isDragging;


    private void Start()
    {
        myPiece = new Piece(colliders);
    }

    void Update()
    {
        if (isDragging)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(mousePosition);
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
    }
}