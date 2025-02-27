using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMovement : MonoBehaviour
{
    [Header("Distance the Boat Moves")]
    [SerializeField] private float moveDistance = 1f;

    [Header("Boat Cool down between movements")]
    [SerializeField] private float moveCoolDown = 0.2f;

    private Rigidbody2D rb;
    private float lastMoveTime;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Move(Vector2 direction)
    {
        if (Time.time - lastMoveTime < moveCoolDown) return;
        rb.MovePosition(rb.position + direction * moveDistance);

        lastMoveTime = Time.time;

    }

    public void MoveUp()
    {
        Move(Vector2.up);
    }

    public void MoveLeft()
    {
        Move(Vector2.left);
    }

    public void MoveRight()
    {
        Move(Vector2.right);
    }
}
