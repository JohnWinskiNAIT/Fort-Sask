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
    public void MoveRight()
    {
        if (rb.position.x < 8)
        {
            rb.MovePosition(rb.position + Vector2.right);
        }

        if (rb.position.x > 8)
        {
            rb.position = new Vector2(8f, rb.position.y);
        }
    }
    public void MoveLeft()
    {
        if (rb.position.x > -8)
        {
            rb.MovePosition(rb.position + Vector2.left);
        }

        if (rb.position.x < -8)
        {
            rb.position = new Vector2(-8f, rb.position.y);
        }
    }

    
}
