using UnityEngine;

public class Object : MonoBehaviour
{
    [SerializeField]
    public Rigidbody2D rb;

    public float minSpeed = 8f;
    public float maxSpeed = 12f;
    public float speed = 1f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = Random.Range(minSpeed, maxSpeed);
    }
    void FixedUpdate()
    {
        Vector2 forward = new Vector2(transform.right.x , transform.right.y);
        rb.MovePosition(rb.position + forward * Time.deltaTime * speed);
    }
}
