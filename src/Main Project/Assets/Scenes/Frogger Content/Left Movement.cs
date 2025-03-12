using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftMovement : MonoBehaviour
{
    [SerializeField]
    public Rigidbody2D rb;
    public void MoveLeft()
    {
        rb.MovePosition(rb.position + Vector2.left);
    }
}
