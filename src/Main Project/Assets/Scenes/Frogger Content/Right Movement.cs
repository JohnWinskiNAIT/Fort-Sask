using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightMovement : MonoBehaviour
{
    [SerializeField]
    public Rigidbody2D rb;
    public void MoveRight()
    {
        rb.MovePosition(rb.position + Vector2.right);
    }
}
