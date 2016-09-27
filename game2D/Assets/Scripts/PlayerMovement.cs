using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public float moveSpeed = 50f;
    public float maxSpeed = 3f;
    
    private bool facingRight = true;
    private Rigidbody2D rb2d;
    private Animator anim;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Mathf.Abs(Input.GetAxis("Horizontal")) != 0 || Mathf.Abs(Input.GetAxis("Vertical")) != 0)
        {
            anim.SetBool("Movement", true);
        }
        else
        {
            anim.SetBool("Movement", false);
        }

	
	}

    void FixedUpdate()
    {
        MoveAxis();
    }

    void MoveAxis()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (h * rb2d.velocity.x < maxSpeed)
        {
            rb2d.AddForce(Vector2.right * h * moveSpeed);
        }
        
        if (Mathf.Abs(rb2d.velocity.x) > maxSpeed)
        {
            rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);
        }

        if (v * rb2d.velocity.y < maxSpeed)
        {
            rb2d.AddForce(Vector2.up * v * moveSpeed);
        }

        if (Mathf.Abs(rb2d.velocity.y) > maxSpeed)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, Mathf.Sign(rb2d.velocity.y));
        }

        if (h > 0 && !facingRight)
            flip();

        if (h < 0 && facingRight)
            flip();
        /*
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            rb2d.AddForce(Vector2.up * jumpHeight);
            canJump = false;
        }
        */
    }

    void flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        /*if (coll.gameObject.tag == "ground")
        {
            canJump = true;
        }
        */
    }
}
