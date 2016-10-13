using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

    public float speed;
    public float paceLength;
    public float originalXPosition;
    public bool facingRight = true;

    public Transform target;
    public float targetDistance;

    private SpriteRenderer sp;
    private Rigidbody rb;
    private Animator anim;
    private NavMeshAgent agent;


	// Use this for initialization
	void Start () {

        sp = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate ()
    {
        targetDistance = Vector3.Distance(target.position, transform.position);
        if (targetDistance < 20)
        {
            agent.enabled = true;
            agent.updateRotation = false;
            agent.SetDestination(target.position);
        }
        else if (targetDistance < 5)
        {
            Attack();
        }
        else
        {
            agent.enabled = false;
            Walking();
        }
    }

    void Walking()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
        if (Mathf.Abs(originalXPosition - transform.position.x) > paceLength)
        {
            speed *= -1;
            transform.position = new Vector3(transform.position.x + 2 * speed * Time.deltaTime,
                                             transform.position.y,
                                             transform.position.z);
            Flip();
        }
    }

    void Attack()
    {
        
    }


    void Flip()
    {
        facingRight = !facingRight;
        sp.flipX = !sp.flipX;
    }
}
