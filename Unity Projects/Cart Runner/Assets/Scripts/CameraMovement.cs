using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private void FixedUpdate()
    {
        transform.position += new Vector3(0.1f, 0, 0);
    }
}
