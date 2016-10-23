using UnityEngine;
using System.Collections;

public class NewPlayerMovement : MonoBehaviour
{

    public float moveForce = 50.0f;
    public float maxSpeed = 3.0f;
    public float jumpHeight = 0.0f;

    private bool facingRight = true;
    private Rigidbody rb;
    private Animator anim;
    private SpriteRenderer sprite;

    private bool isGrounded = false;
    [HideInInspector] public bool jump = false;
    public Transform groundCheck;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));
        //Debug.Log(isGrounded);
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            jump = true;
            isGrounded = false;
        }
    }

    void FixedUpdate()
    {
        MoveAxis();
    }

    void MoveAxis()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        if (horizontalMovement * rb.velocity.x < maxSpeed)
            rb.AddForce(Vector3.right * horizontalMovement * moveForce);

        if (Mathf.Abs(rb.velocity.x) > maxSpeed)
            rb.velocity = new Vector3(Mathf.Sign(rb.velocity.x) * maxSpeed, rb.velocity.y, rb.velocity.z);

        if (verticalMovement * rb.velocity.z < maxSpeed)
            rb.AddForce(Vector3.forward * verticalMovement * moveForce);
        if (Mathf.Abs(rb.velocity.z) > maxSpeed)
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, Mathf.Sign(rb.velocity.z) * maxSpeed);

        rb.velocity = new Vector3(0f,rb.velocity.y, 0f);

        if (horizontalMovement > 0 && !facingRight)
            Flip();
        if (horizontalMovement < 0 && facingRight)
            Flip();

        if (jump)
        {
            //Debug.Log("jump");
            rb.AddForce(new Vector3(0.0f, jumpHeight, 0.0f));
            jump = false;
        }
        // Check if the body's current velocity will result in a collision
        RaycastHit hit;
        if (rb.SweepTest(transform.forward, out hit, 0.1f))
        {
            // If so, stop the movement
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
        }
    }



    void Flip()
    {
        facingRight = !facingRight;
        sprite.flipX = !sprite.flipX;
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "ground")
        {
            isGrounded = true;
        } 
    }
}

