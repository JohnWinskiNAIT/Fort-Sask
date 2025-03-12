using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpMovement : MonoBehaviour
{
    [SerializeField]
    public Rigidbody2D rb;
    public void MoveUp()
    {
        rb.MovePosition(rb.position + Vector2.up);
    }
}
