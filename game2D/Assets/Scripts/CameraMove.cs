using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour
{

    public float moveSpeed = 50f;
    public float maxSpeed = 3f;

    private Rigidbody2D rb2d;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        MoveAxis();
    }

    void MoveAxis()
    {
        float h = Input.GetAxis("Horizontal");

        if (h * rb2d.velocity.x < maxSpeed)
        {
            rb2d.AddForce(Vector2.right * h * moveSpeed);
        }
    }
}
